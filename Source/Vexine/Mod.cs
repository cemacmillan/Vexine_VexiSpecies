using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using RimWorld;
using Verse;

namespace Vexine
{
    [StaticConstructorOnStartup]
    public static class First
    {
        static First()
        {
            var harmony = new Harmony("rimworld.Vexine");

            Log.Message("VexiSpecies 0.1");


            harmony.PatchAll();
        }


        //cf. TFM
        private static bool IsThisThingLoaded(string mod)
        {
            return LoadedModManager.RunningModsListForReading.Any(x => x.Name == mod);
        }
    }
}
