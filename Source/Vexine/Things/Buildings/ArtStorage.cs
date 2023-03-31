using RimWorld;
using Verse;

namespace MyMod
{
    public class ArtStorage : Building
    {
        public CompStorage StorageComp
        {
            get
            {
                return this.GetComp<CompStorage>();
            }
        }

        public override void SpawnSetup(Map map, bool respawningAfterLoad)
        {
            base.SpawnSetup(map, respawningAfterLoad);
            this.StorageComp.StorageSettings.filter.SetAllow(ThingCategoryDefOf.Art, true);
        }
    }
}

/*
This class extends the Building class and defines a CompStorage property which allows access to the CompStorage component of the building. It also overrides the SpawnSetup method to enable storing of art objects in the storage.

Note that this is just a sample implementation and you may want to customize it further to fit your specific needs. For example, you could add more properties or methods to the ArtStorage class, or add more XML data to the BuildingDef element in the XML file.

*/
