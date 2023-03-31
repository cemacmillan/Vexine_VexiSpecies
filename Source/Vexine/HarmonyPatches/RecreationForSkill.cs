using HarmonyLib;
using RimWorld;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
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
            if(xp > 0 && ___pawn.genes.HasGene(VexiDefOf.dIl_Vexi_Body))
            {
                ___pawn.needs?.joy?.GainJoy(xp * 0.001f, VexiDefOf.Gaming_Cerebral);

            }

            //if(!VexiUtil.GotIt()) {
            //    Log.Message("Not yet got it !");
            //    VexiUtil.DumpObject(___pawn.RaceProps);
            //
            //}


        }
    }




}
