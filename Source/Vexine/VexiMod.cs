using HarmonyLib;
using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using UnityEngine;
using Verse;

namespace Vexine
{
    class Vexi_SpeciesMod : Mod
    {
        public static Vexi_SpeciesMod mod;

        public Vexi_SpeciesMod(ModContentPack pack) : base(pack)
        {

           mod = this;
           Harmony harmony = new Harmony("Vexine.HarmonyPatches");
           harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
        /*
        public static Vexi_SpeciesSettings settings;
        public Vexi_SpeciesMod(ModContentPack pack) : base(pack)
        {
            settings = GetSettings<Vexi_SpeciesSettings>();
            ApplySettings();
        }

        public override void DoSettingsWindowContents(Rect inRect)
        {
            base.DoSettingsWindowContents(inRect);
            settings.DoSettingsWindowContents(inRect);
        }

        public override string SettingsCategory()
        {
            return "Vexi Species v0.5";
        }

        public override void WriteSettings()
        {
            base.WriteSettings();
            ApplySettings();
        }

        private void ApplySettings()
        {

        }
        */
    }
}
