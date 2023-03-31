public class IncidentWorker_RefugeeGroup : IncidentWorker_NeutralGroup
{
    protected override PawnGroupKindDef PawnGroupKindDef => PawnGroupKindDefOf.Refugee;

    protected override void ResolveParmsPoints(IncidentParms parms)
    {
        // Here we can set the points scale for the incident based on the specific needs of the refugee group
        parms.points = Rand.Range(500, 1000);
    }

    protected override void SendStandardLetter(TaggedString letterLabel, TaggedString letterText, LetterDef letterType, IncidentParms parms, Pawn anyPawn)
    {
        // We can use this method to send a custom letter specific to the refugee group incident
        Find.LetterStack.ReceiveLetter(letterLabel, letterText, letterType, anyPawn);
    }

    protected override bool FactionCanBeGroupSource(Faction f, Map map, bool desperate = false)
    {
        // We can use this method to check if the faction can be the source of the refugee group, and if the faction is desperate
        if (!base.FactionCanBeGroupSource(f, map, desperate) || f.def.caravanTraderKinds.Count == 0)
        {
            return false;
        }
        return f.def.caravanTraderKinds.Any((TraderKindDef t) => TraderKindCommonality(t, map, f) > 0f) && f.IsDesperate();
    }

    protected List<Pawn> SpawnPawns(IncidentParms parms)
    {
      Map map = (Map)parms.target;
      /* List<Pawn> list = PawnGroupMakerUtility.GeneratePawns(IncidentParmsUtility.GetDefaultPawnGroupMakerParms(PawnGroupKindDef, parms, ensureCanGenerateAtLeastOnePawn: true), warnOnZeroResults: false).ToList(); */
      List<Pawn> list = PawnGroupMakerUtility.GeneratePawns(IncidentParmsUtility.GetDefaultPawnGroupMakerParms(PawnGroupKindDefOf.Refugee, parms, ensureCanGenerateAtLeastOnePawn: true), warnOnZeroResults: false).ToList();
      foreach (Pawn item in list)
      {
        IntVec3 loc = CellFinder.RandomClosewalkCellNear(parms.spawnCenter, map, 5);
        GenSpawn.Spawn(item, loc, map);
        parms.storeGeneratedNeutralPawns?.Add(item);
      }
      return list;
    }

}
