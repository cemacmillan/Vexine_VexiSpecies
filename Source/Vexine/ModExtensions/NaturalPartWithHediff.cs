using System.Collections.Generic;
using System.Linq;
using Verse;

namespace Vexine
{
    public class NaturalPartWithHediff : Gene
    {
        private int ticksToRegrow = 180000;

        private List<Hediff> LinkedHediff
        {
            get
            {
                if (this.pawn?.health?.hediffSet?.hediffs == null)
                    return new List<Hediff>();

                return this.pawn.health.hediffSet.hediffs
                    .Where(hediff => hediff.def == def.GetModExtension<GenomeExtension>()?.linkedHediff).ToList();
            }
        }

        public override void PostAdd()
        {
            base.PostAdd();
            ProcessParts(false);
        }

        public override void Tick()
        {
            base.Tick();

            ticksToRegrow--;
            if (ticksToRegrow <= 0)
            {
                ticksToRegrow = 180000; // 3 game days
                ProcessParts(true);
            }
        }

        private void ProcessParts(bool regrow)
        {
            if (this.pawn?.def?.race?.body?.AllParts == null)
                return;

            var genomeExtension = def.GetModExtension<GenomeExtension>();
            if (genomeExtension == null)
                return;

            var affectedBodyParts = this.pawn.def.race.body.AllParts
                .Where(part => part.def == genomeExtension.affectedPart).ToList();

            foreach (var bodyPart in affectedBodyParts)
            {
                if (!regrow && !this.pawn.health.hediffSet.PartIsMissing(bodyPart))
                {
                    this.pawn.health.AddHediff(genomeExtension.linkedHediff, bodyPart, null, null);
                }

                if (regrow && this.pawn.health.hediffSet.PartIsMissing(bodyPart))
                {
                    var existingHediffs = this.pawn.health.hediffSet.hediffs
                        .Where(hediff => hediff.Part == bodyPart && hediff.def == genomeExtension.linkedHediff).ToList();

                    foreach (var existingHediff in existingHediffs)
                    {
                        existingHediff.Severity = 0;
                        this.pawn.health.RemoveHediff(existingHediff);
                    }

                    this.pawn.health.AddHediff(genomeExtension.linkedHediff, bodyPart, null, null);
                }
            }
        }

        public override void PostRemove()
        {
            var hediffsToRemove = LinkedHediff.ToList();
            foreach (Hediff h in hediffsToRemove)
            {
                this.pawn.health.RemoveHediff(h);
            }
            base.PostRemove();
        }

        public override void Reset() { }
    }
}
