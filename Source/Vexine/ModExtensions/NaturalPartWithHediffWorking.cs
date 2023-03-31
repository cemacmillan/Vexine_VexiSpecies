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

		public List<Hediff> LinkedHediff
		{
			get
			{
				List<Hediff> foundHd = new List<Hediff>();
				List<Hediff> hediffs = this.pawn.health.hediffSet.hediffs;
				for (int i = 0; i < hediffs.Count; i++)
				{


					if (hediffs[i].def == def.GetModExtension<GenomeExtension>().linkedHediff)
					{
						foundHd.Add(hediffs[i]);
					}
				}
				return foundHd;
			}
		}

		public override void PostAdd()
		{
			base.PostAdd();
			List<BodyPartRecord> hands = this.pawn.def.race.body.GetPartsWithDef(def.GetModExtension<GenomeExtension>().affectedPart);

			foreach (BodyPartRecord hd in hands)
			{
				if (!this.pawn.health.hediffSet.PartIsMissing(hd))
				{
					this.pawn.health.AddHediff(def.GetModExtension<GenomeExtension>().linkedHediff, hd, null, null);

				}
			}
		}

		public override void Tick()
		{
			base.Tick();
			ticksToRegrow--;
			if (ticksToRegrow <= 0)
			{
				ticksToRegrow = 60000;

				foreach (Hediff h in LinkedHediff)
				{
					this.pawn.health.RemoveHediff(h);
				}

				List<BodyPartRecord> hands = this.pawn.def.race.body.GetPartsWithDef(def.GetModExtension<GenomeExtension>().affectedPart);

				foreach (BodyPartRecord hd in hands)
				{
					if (!this.pawn.health.hediffSet.PartIsMissing(hd))
					{
						Hediff h = this.pawn.health.AddHediff(def.GetModExtension<GenomeExtension>().linkedHediff, hd, null, null);

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

		private int ticksToRegrow = 60000;

	}
}
