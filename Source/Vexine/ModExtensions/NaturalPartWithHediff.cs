using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RimWorld;
using Verse;

namespace Vexine
{
	public class NaturalPartWithHediff : Gene
	{

		public List<Hediff> LinkedHediff => this.pawn.health.hediffSet.hediffs.Where(hediff => hediff.def == def.GetModExtension<GenomeExtension>().linkedHediff).ToList();


		public override void PostAdd()
		{
		    base.PostAdd();

				var affectedBodyParts = new List<BodyPartRecord>(
				    this.pawn.def.race.body.AllParts
				        .Where(part => part.def == def.GetModExtension<GenomeExtension>().affectedPart)
				);

		    var hediffDef = def.GetModExtension<GenomeExtension>().linkedHediff;

		    for (int i = 0; i < affectedBodyParts.Count; i++)
		    {
		        var bodyPart = affectedBodyParts[i];
		        if (!this.pawn.health.hediffSet.PartIsMissing(bodyPart))
		        {
		            this.pawn.health.AddHediff(hediffDef, bodyPart, null, null);
		        }
		    }
		}


		public override void Tick()
		{
		    base.Tick();

		    ticksToRegrow--;
		    if (ticksToRegrow <= 0)
		    {
		        ticksToRegrow = 180000; // 3 game days

                var affectedBodyParts = new List<BodyPartRecord>(
                     this.pawn.def.race.body.AllParts
                         .Where(part => part.def == def.GetModExtension<GenomeExtension>().affectedPart)
                 );

                var hediffDef = def.GetModExtension<GenomeExtension>().linkedHediff;

		        for (int i = 0; i < affectedBodyParts.Count; i++)
		        {
		            var bodyPart = affectedBodyParts[i];
		            if (this.pawn.health.hediffSet.PartIsMissing(bodyPart))
		            {
		                // Remove any existing hediffs on the missing body part
		                var existingHediffs = this.pawn.health.hediffSet.hediffs
		                    .Where(hediff => hediff.Part == bodyPart && hediff.def == hediffDef).ToList();
		                for (int j = 0; j < existingHediffs.Count; j++)
		                {
											existingHediffs[j].Severity = 0;
											this.pawn.health.RemoveHediff(existingHediffs[j]);
										}

											// Add the hediff to the missing body part
											this.pawn.health.AddHediff(hediffDef, bodyPart, null, null);
								}
						}
				}
		}






		public override void PostRemove()
		{

			foreach (Hediff h in LinkedHediff)
			{
				this.pawn.health.RemoveHediff(h);
			}
			base.PostRemove();
		}

		public override void Reset()
		{
		}

		private int ticksToRegrow = 180000;

	}
}
