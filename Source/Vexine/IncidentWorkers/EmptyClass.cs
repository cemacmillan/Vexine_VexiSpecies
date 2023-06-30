using RimWorld;
using System.Collections.Generic;
using System.Linq;
using System;
using Verse;



namespace Vexine.VexiSpecies
{
    public class IncidentWorker_FleaInfestation : IncidentWorker_DiseaseHuman
    {
        protected override bool TryExecuteWorker(IncidentParms parms)
        {
            int fleaInfected = 0;
            Map map = parms.target as Map;
            if (map == null)
            {
                return false;
            }

            // Get all pawns in the map
            IEnumerable<Pawn> potentialVictims = map.mapPawns.AllPawns.Where(p => p.RaceProps.Humanlike);

            // Filter pawns based on our criteria
            IEnumerable<Pawn> filteredVictims = potentialVictims.Where(pawn =>
               HasFurOrVexiGene(pawn)  // Add this line
            );

            // If no pawns fit the criteria, return false
            if (!filteredVictims.Any())
                return false;

            Random random = new Random();

            foreach (Pawn pawn in filteredVictims)
            {
               
                double randomValue = random.NextDouble();
                if (randomValue <= 0.5)
                {
                    pawn.health.AddHediff(HediffDef.Named("Hediff_FleaInfestation"));
                    fleaInfected++;
                }
                
            }

            if(fleaInfected > 0)
            {
                Find.LetterStack.ReceiveLetter("Flea Infestation!", "Fleas have infested some of the colonists.", LetterDefOf.NegativeEvent);
            }


            return true;
        }

        // Define a helper method to check for the presence of specific genes
        private bool HasFurOrVexiGene(Pawn pawn)
        {
            if (pawn?.genes == null)
            {
                return false;
            }

            GeneDef furskinGene = DefDatabase<GeneDef>.GetNamed("Furskin", false);
            GeneDef vexiFurGene = VexiDefOf.dIl_Vexi_Fur; // Replace with your actual GeneDef

            return (furskinGene != null && pawn.genes.HasGene(furskinGene)) || (vexiFurGene != null && pawn.genes.HasGene(vexiFurGene));
        }

    }

}
