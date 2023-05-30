using System;
using HarmonyLib;
using RimWorld;
using Verse;
using Vexine;

namespace Vexine
{
    [HarmonyPatch(typeof(MemoryThoughtHandler))]
    [HarmonyPatch("TryGainMemory", new Type[] { typeof(Thought_Memory), typeof(Pawn) })]
    public static class MemoryThoughtHandler_Patch
    {
        [HarmonyPrefix]
        public static bool Prefix(MemoryThoughtHandler __instance, ref Thought_Memory newThought, Pawn otherPawn)
        {
            Pawn pawn = __instance.pawn;
            ThoughtDef def = newThought.def;

            if (def == ThoughtDefOf.SleptInBarracks && pawn.genes.HasGene(VexiDefOf.Vexi_SkulkInstinct))
            {
                // Replace the 'SleptInBarracks' thought with the custom 'SleptInBarracksVexi' thought before it's added
                newThought = ThoughtMaker.MakeThought(DefDatabase<ThoughtDef>.GetNamed("SleptInBarracksVexi"), newThought.CurStageIndex);
            }

            // Proceed with the original method
            return true;
        }
    }
}
