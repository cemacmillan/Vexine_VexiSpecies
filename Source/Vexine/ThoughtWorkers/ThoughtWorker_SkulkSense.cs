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
    public class ThoughtWorker_SkulkSense : ThoughtWorker
	{
		protected override ThoughtState CurrentSocialStateInternal(Pawn p, Pawn otherPawn)
		{
			if (!VexiUtil.SameXenotype(p, otherPawn) || !RelationsUtility.PawnsKnowEachOther(p, otherPawn))
			{
				return false;
			}
			if (otherPawn.genes.HasGene(VexiDefOf.Vexi_SkulkInstinct))
			{
				return ThoughtState.ActiveAtStage(1);
			}
			return false;
		}
	}
}
