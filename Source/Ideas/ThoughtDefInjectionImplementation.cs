namespace AdrenalineRush.Detour
{
    internal static class _ThoughtUtility
    {
        internal static void _GiveThoughtsForPawnDied(Pawn victim, DamageInfo? dinfo, Hediff hediff)
        {
            if (PawnGenerator.IsBeingGenerated(victim) || Current.ProgramState != ProgramState.MapPlaying)
                return;
            bool flag1 = dinfo.HasValue && dinfo.Value.Def == DamageDefOf.ExecutionCut || hediff != null && (hediff.def == HediffDefOf.Euthanasia || hediff.def == HediffDefOf.ShutDown);
            bool flag2 = victim.IsPrisonerOfColony && !PrisonBreakUtility.IsPrisonBreaking(victim) && !victim.InAggroMentalState;
            if (!victim.RaceProps.Humanlike)
                return;
            if (dinfo.HasValue && dinfo.Value.Def.externalViolence && dinfo.Value.Instigator != null)
            {
                Pawn pawn = dinfo.Value.Instigator as Pawn;
                if (pawn != null && !pawn.Dead && (pawn.needs.mood != null && pawn.story != null))
                {
                    pawn.needs.mood.thoughts.memories.TryGainMemoryThought(ThoughtDefOf.KilledHumanlikeBloodlust, (Pawn)null);
                    if (victim.Faction.HostileTo(pawn.Faction) && !flag1 && !flag2)
                        pawn.needs.mood.thoughts.memories.TryGainMemoryThought(ThoughtDefOfAdrenaline.KilledHumanlikeEnemy, (Pawn)null);
                }
            }
            List<Pawn> allPawnsSpawned = Find.MapPawns.AllPawnsSpawned;
            for (int index = 0; index < allPawnsSpawned.Count; ++index)
            {
                Pawn p = allPawnsSpawned[index];
                if (p.needs.mood != null && !flag1 && (p.MentalStateDef != MentalStateDefOf.SocialFighting || ((MentalState_SocialFighting)p.MentalState).otherPawn != victim))
                {
                    if (victim.Spawned && (p.Position.InHorDistOf(victim.Position, 12f) && GenSight.LineOfSight(victim.Position, p.Position, false) && (p.Awake() && p.health.capacities.CapableOf(PawnCapacityDefOf.Sight))))
                    {
                        if (p.Faction == victim.Faction)
                            p.needs.mood.thoughts.memories.TryGainMemoryThought(ThoughtDefOf.WitnessedDeathAlly, (Pawn)null);
                        //else
                        //    p.needs.mood.thoughts.memories.TryGainMemoryThought(ThoughtDefOf.WitnessedDeathNonAlly, (Pawn)null);
                        if (p.relations.FamilyByBlood.Contains<Pawn>(victim))
                            p.needs.mood.thoughts.memories.TryGainMemoryThought(ThoughtDefOf.WitnessedDeathFamily, (Pawn)null);
                        p.needs.mood.thoughts.memories.TryGainMemoryThought(ThoughtDefOf.WitnessedDeathBloodlust, (Pawn)null);
                    }
                    else if (victim.Faction == Faction.OfPlayer && victim.Faction == p.Faction && victim.HostFaction != p.Faction)
                        p.needs.mood.thoughts.memories.TryGainMemoryThought(ThoughtDefOf.KnowColonistDied, (Pawn)null);
                    if (flag2 && p.Faction == Faction.OfPlayer && !p.IsPrisoner)
                        p.needs.mood.thoughts.memories.TryGainMemoryThought(ThoughtDefOf.KnowPrisonerDiedInnocent, (Pawn)null);
                }
            }
        }
    }
}
