using HarmonyLib;
using RimWorld;
using Verse;

namespace Vexine
{
    [HarmonyPatch(typeof(PregnancyUtility))]
    [HarmonyPatch("GetInheritedGeneSet")]
    public static class PregnancyUtility_GetInheritedGeneSet_Patch
    {
        private class BoolRefHolder { public bool Value; }

        private static bool Prefix(Pawn father, Pawn mother, BoolRefHolder success, ref GeneSet __result)
        {
            if (mother?.def.defName == "Vexi" || father?.def.defName == "Vexi")
            {
                success.Value = true;
                __result = new GeneSet();
                // Add Vexi genes to the geneSet here
                return false; // Skip the original method
            }

            success.Value = false; // Set success to false if not Vexi
            return true; // Proceed with the original method
        }

        [HarmonyPrepare]
        public static bool HarmonyPrepare()
        {
            return false;
        }
    }
}
