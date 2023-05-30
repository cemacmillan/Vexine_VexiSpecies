using HarmonyLib;
using RimWorld;
using Verse;

namespace Vexine
{
    [HarmonyPatch(typeof(Pawn_SkillTracker))]
    [HarmonyPatch("Learn")]
    public static class dIl_PleasureInLearning_Patch
    {
        [HarmonyPostfix]
        public static void GiveRecreation(Pawn ___pawn, SkillDef sDef, float xp)
        {
            if (xp > 0 && ___pawn.genes.HasGene(VexiDefOf.dIl_Vexi_Body))
            {
                // Check if the current job is a research job
                var isResearchJob = ___pawn.CurJob?.def == JobDefOf.Research;

                if (isResearchJob)
                {
                    ___pawn.needs?.joy?.GainJoy(xp * 0.001f, VexiDefOf.Gaming_Cerebral);
                }
            }
        }
    }
}

