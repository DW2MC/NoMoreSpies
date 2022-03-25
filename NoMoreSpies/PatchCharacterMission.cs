using System.Diagnostics.CodeAnalysis;
using DistantWorlds.Types;
using HarmonyLib;
using JetBrains.Annotations;

namespace NoMoreSpies;

[PublicAPI]
[HarmonyPatch(typeof(CharacterMission))]
[SuppressMessage("ReSharper", "InconsistentNaming")]
[SuppressMessage("ReSharper", "RedundantAssignment")]
public static class PatchCharacterMission
{
    [HarmonyPrefix]
    [HarmonyPatch(nameof(CompleteMission), typeof(Galaxy), typeof(Character), typeof(CharacterMissionOutcome), typeof(bool))]
    public static bool CompleteMission(CharacterMission __instance, Galaxy galaxy, Character agent, ref CharacterMissionOutcome outcome, ref bool sendMessages)
    {
        __instance.MissionType = CharacterMissionType.Undefined;
        outcome = CharacterMissionOutcome.FailNotDetect;
        sendMessages = false;
        return true;
    }
}
