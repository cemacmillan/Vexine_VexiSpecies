using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;

namespace Vexine
{
    [DefOf]
    public static class VexiDefOf
    {
        static VexiDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(VexiDefOf));
        }

        public static XenotypeDef Vexi;

        public static ThoughtDef dIl_SkulkSenseThought;
        
    
        /*
        -- moved to DarkStory  
        public static ThoughtDef Pragmatism_AnimalMassPerCapita;
        */

        /* public static HediffDef dIl_Hediff_FleaInfestation; */

        /* does this have to be in Vexi_Species_HediffDefOf ? */
        public static HediffDef dIl_VexiClaws;
        public static HediffDef dIl_VexiFangs;


        public static GeneDef Vexi_SkulkInstinct;
        public static GeneDef dIl_Vexi_Body;
        public static GeneDef dIl_Vexi_Fur;
        public static GeneDef dIl_Clawed_Hands;
        public static GeneDef dIl_Fanged_Dentition;
        public static JoyKindDef Gaming_Cerebral;

        /*
        [MayRequireIdeology]
        public static IssueDef Pragmatism;

        */

    }
}
