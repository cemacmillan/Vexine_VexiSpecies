using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using RimWorld;
using Verse;
//using static System.Net.Mime.MediaTypeNames;

namespace Vexine
{
    [StaticConstructorOnStartup]
    public static class ButcherVexi
    {
        static ButcherVexi()
        {
            //append new descriptions
            if (ModsConfig.BiotechActive)
            {
                GeneDef d1 = DefDatabase<GeneDef>.GetNamed("dIl_Vexi_Fur", true);
                if (d1.label == "furred")
                {
                    d1.description = d1.description + " Creatures with this gene are occassionally murdered for their fur.";
                }

            }
            //harmony patch
            var harmony = new Harmony("Vexine.furHorror");
            harmony.PatchAll();
        }
    }

    [HarmonyPatch(typeof(Pawn))]
    [HarmonyPatch(nameof(Pawn.ButcherProducts))]
    static class Pawn_ButcherProducts
    {
        static IEnumerable<Thing> Postfix(IEnumerable<Thing> values, Thing __instance)
        {
            foreach (Thing thing in values)
            {
                if (__instance.def == ThingDefOf.Human)
                {
                    Pawn human = __instance as Pawn;
                    if (thing.def == DefDatabase<ThingDef>.GetNamed("Leather_Human"))
                    {
                        if (ModsConfig.BiotechActive)
                        {
                            if (human.genes != null)
                            {
                                bool hasFur = human.genes.HasGene(DefDatabase<GeneDef>.GetNamed("dIl_Vexi_Fur"));
                                //bool hasHeat = human.genes.HasGene(DefDatabase<GeneDef>.GetNamed("FireResistant"));
                                if (hasFur)
                                {
                                    Thing newthing = ThingMaker.MakeThing(DefDatabase<ThingDef>.GetNamed("dIl_Vexilour"), null);
                                    newthing.stackCount = thing.stackCount;
                                    thing.Destroy();
                                    newthing.SetColor(human.story.SkinColor);
                                    yield return newthing;
                                }
                                else
                                {
                                    thing.SetColor(human.story.SkinColor);
                                    yield return thing;
                                }
                            }
                            else
                            {
                                thing.SetColor(human.story.SkinColor);
                                yield return thing;
                            }
                        }
                        else
                        {
                            thing.SetColor(human.story.SkinColor);
                            yield return thing;
                        }
                    } //else not human leather
                    else
                    {
                        yield return thing;
                    }
                }
                else
                {
                    yield return thing;
                }
            }
        }
    }

}
