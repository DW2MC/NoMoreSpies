using DistantWorlds2;
using HarmonyLib;
using JetBrains.Annotations;

namespace NoMoreSpies;

[PublicAPI]
public class Mod
{
    public Mod(DWGame game)
    {
        Console.WriteLine("NoMoreSpies Patching");
        var harmony = new Harmony(nameof(NoMoreSpies));
        harmony.PatchAll();

        foreach (var m in harmony.GetPatchedMethods())
            Console.WriteLine($"NoMoreSpies Patched {m.Name}");

        Console.WriteLine("NoMoreSpies Done Patching");
    }
}
