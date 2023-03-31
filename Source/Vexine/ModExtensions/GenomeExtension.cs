using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;
using HarmonyLib;

namespace Vexine
{
    public class GenomeExtension : DefModExtension
    {
        public HediffDef linkedHediff;

        public BodyPartDef affectedPart;

          public GenomeExtension() {}
    }
}
