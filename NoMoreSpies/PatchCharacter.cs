using System.Diagnostics.CodeAnalysis;
using DistantWorlds.Types;
using DistantWorlds2;
using HarmonyLib;
using JetBrains.Annotations;

namespace NoMoreSpies;

[PublicAPI]
[HarmonyPatch(typeof(Character))]
[SuppressMessage("ReSharper", "InconsistentNaming")]
[SuppressMessage("ReSharper", "RedundantAssignment")]
public static class PatchCharacter
{
    [HarmonyPrefix]
    [HarmonyPatch(nameof(Character.GenerateCharacter),
        typeof(Galaxy), typeof(Empire), typeof(CharacterRole), typeof(short), typeof(StellarObject), typeof(bool),
        typeof(CharacterEventType), typeof(StellarObject), typeof(int), typeof(BonusType), typeof(CharacterTraitType), typeof(string))]
    public static bool GenerateCharacter(ref Character? __result, Galaxy galaxy, Empire empire, CharacterRole role, short raceId,
        StellarObject location, bool sendMessage, CharacterEventType eventType, StellarObject eventLocation, int eventId, BonusType eventSkill,
        CharacterTraitType eventTrait, string name)
    {
        if (role != CharacterRole.Spy)
            return true;

        __result = null!;
        return false;
    }
}