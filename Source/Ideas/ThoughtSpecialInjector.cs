using Verse;

namespace AdrenalineRush
{
    public class DetourInjector : SpecialInjector
    {
        public override bool Inject()
        {
            MethodInfo method1 = typeof(ThoughtUtility).GetMethod("GiveThoughtsForPawnDied", BindingFlags.Static | BindingFlags.Public);
            MethodInfo method2 = typeof(Detour._ThoughtUtility).GetMethod("_GiveThoughtsForPawnDied", BindingFlags.Static | BindingFlags.NonPublic);
            if (!Detours.TryDetourFromTo(method1, method2))
            {
                return false;
            }
            return true;
        }
    }
}
