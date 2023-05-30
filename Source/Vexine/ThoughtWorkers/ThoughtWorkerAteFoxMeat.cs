ThoughtWorkerAteFoxMeat.cs

using RimWorld;
using Verse;

namespace Vexine
{
    public class ThoughtWorker_WhatIsCannibal : ThoughtWorker
    {
        protected override ThoughtState CurrentStateInternal(Pawn p)
        {
            // Check if the pawn has the Cannibal trait or is not a VexiSpecies
            if (p.story.traits.HasTrait(TraitDefOf.Cannibal) || p.def != VexineDefOf.Vexine_VexiSpecies)
            {
                return false;
            }

            // Check if the pawn has recently consumed cooked fox meat
            var lastMeal = p.needs.food.CurLevelPercentage;
            if (lastMeal != null && lastMeal.IngestedFood != null && lastMeal.IngestedFood.def == ThingDef.Named("MealSimple"))
            {
                var ingredients = lastMeal.IngestedFood.TryGetComp<CompIngredients>();
                if (ingredients != null && ingredients.ingredients.Any(i => i.def == ThingDef.Named("Fox_Meat")))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
