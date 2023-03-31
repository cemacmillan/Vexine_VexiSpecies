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
    public class Thought_HasFleas : Thought_SituationalSocial
	{
		public override float OpinionOffset()
		{
      var hediff = pawn.health.hediffSet.HasHediff(Hediff_FleaInfestation.HediffDef,true);
      // If the hediff is present and its severity is 2,
      // return the "active" state for the severity2ThoughtDef.
 
      if (hediff == true)
      {
          //return ThoughtState.ActiveAtStage(1);
          return (float) -0.25;
      }

            return (float)0.00;

		}
	}
}
