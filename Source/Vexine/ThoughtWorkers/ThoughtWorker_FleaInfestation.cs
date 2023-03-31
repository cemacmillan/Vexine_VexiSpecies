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
    public class ThoughtWorker_FleaInfestation: ThoughtWorker
	{
		protected override ThoughtState CurrentStateInternal(Pawn pawn)
    {

        /*
        if(!pawn.VexiUtil.isVexine(pawn))
        {
          return ThoughtState.Inactive;
        }
        */
        // Get the hediff on the pawn with the specified hediffDef.
        var hediff = pawn.health.hediffSet.GetFirstHediffOfDef(Def.Hediff_FleaInfestation);
        if (hediff == null)
        {
            // If the hediff is not present on the pawn, return "inactive" state.
            return ThoughtState.Inactive;
        }

        // If the hediff is present and its severity is 1,
        // return the "active" state for the severity1ThoughtDef.
        if (hediff.Severity == 1)
        {
            return ThoughtState.ActiveAtStage(0);
        }

        // If the hediff is present and its severity is 2,
        // return the "active" state for the severity2ThoughtDef.
        if (hediff.Severity == 2)
        {
            return ThoughtState.ActiveAtStage(1);
        }

        if (hediff.Severity == 3)
        {
            return ThoughtState.ActiveAtStage(2);
        }

        if (hediff.Severity == 4)
        {
            return ThoughtState.ActiveAtStage(3);
        }


        // If the hediff is present but its severity is not 1 or 2,
        // return the "inactive" state for both thoughtDefs.
        return ThoughtState.Inactive;
    }
}


}
