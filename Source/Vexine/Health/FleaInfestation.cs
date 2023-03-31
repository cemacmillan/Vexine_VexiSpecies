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
    public class Hediff_FleaInfestation : HediffWithComps
    {
        public static HediffDef HediffDef { get; internal set; }

        #region Properties

        public Hediff_FleaInfestation Def
        {
            get
            {
                return this.Def as Hediff_FleaInfestation;
            }
        }

        #endregion
        public override void ExposeData()
        {
            base.ExposeData();
            // Save
        }

        public override void PostRemoved()
        {
            // Do something when the hediff is removed from a pawn, such as removing a comp or hediff giver.
        }

        public override void PostTick()
        {
            // Do something every tick while the hediff is present on the pawn.
            // For example, you could apply damage to the pawn or reduce their mood.
        }



        public override void Tick()
        {
            // Do something every tick while the hediff is present on the pawn.
            // For example, you could apply damage to the pawn or reduce their mood.
        }
    }
}
