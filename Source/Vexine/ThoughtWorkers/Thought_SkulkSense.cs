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
    public class Thought_SkulkSense : Thought_SituationalSocial
	{
		public override float OpinionOffset()
		{
            return pawn.genes.HasGene(VexiDefOf.Vexi_SkulkInstinct) ?
			(VexiUtil.SameXenotype(pawn, OtherPawn()) ?
			(OtherPawn().Faction == pawn.Faction ?
			(OtherPawn().genes.HasGene(VexiDefOf.Vexi_SkulkInstinct) ? 12 : 6) : 3) : 0) : 0;

            /*
             * return VexiUtil.SameXenotype(pawn, OtherPawn()) && (OtherPawn().Faction == pawn.Faction) ? 12 : 0;
            return VexiUtil.SameXenotype(pawn, OtherPawn()) ? (OtherPawn().genes.HasGene(VexiDefOf.Vexi_SkulkInstinct) ? 3 : 0) : 0;
			*/
		}
	}
}
