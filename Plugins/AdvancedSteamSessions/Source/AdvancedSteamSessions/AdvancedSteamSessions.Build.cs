using UnrealBuildTool;
using System.IO;
 
public class AdvancedSteamSessions : ModuleRules
{
    public AdvancedSteamSessions(ReadOnlyTargetRules Target) : base(Target)
    {
        DefaultBuildSettings = BuildSettingsVersion.Latest;
        IncludeOrderVersion = EngineIncludeOrderVersion.Latest;

        PCHUsage = PCHUsageMode.UseExplicitOrSharedPCHs;
        //bEnforceIWYU = true;

        PublicDefinitions.Add("WITH_ADVANCED_STEAM_SESSIONS=1");

        PublicDependencyModuleNames.AddRange(new string[] { "Core", "CoreUObject", "Engine", "InputCore", "OnlineSubsystem", "CoreUObject", "OnlineSubsystemUtils", "Networking", "Sockets", "AdvancedSessions"/*"Voice", "OnlineSubsystemSteam"*/ });
        PrivateDependencyModuleNames.AddRange(new string[] { "OnlineSubsystem", "Sockets", "Networking", "OnlineSubsystemUtils" /*"Voice", "Steamworks","OnlineSubsystemSteam"*/});

        /// ---- Steamworks SDK PATHS (Environment Variable version) ----
        string SteamworksPath = System.Environment.GetEnvironmentVariable("STEAMWORKS_SDK");

        if (!string.IsNullOrEmpty(SteamworksPath))
        {
            PublicIncludePaths.Add(Path.Combine(SteamworksPath, "public"));
            PublicIncludePaths.Add(Path.Combine(SteamworksPath, "public", "steam"));

            PublicAdditionalLibraries.Add(
                Path.Combine(SteamworksPath, "redistributable_bin", "win64", "steam_api64.lib")
            );
        }
        else
        {
            System.Console.WriteLine("Warning: STEAMWORKS_SDK environment variable is not set — AdvancedSteamSessions will build without Steam support.");
        }

        // Add Steam-specific modules ONLY if SDK exists
        if (!string.IsNullOrEmpty(SteamworksPath) &&
            (Target.Platform == UnrealTargetPlatform.Win64 ||
             Target.Platform == UnrealTargetPlatform.Linux ||
             Target.Platform == UnrealTargetPlatform.Mac))
        {
            PublicDependencyModuleNames.AddRange(new string[] { "SteamShared", "Steamworks", "OnlineSubsystemSteam" });
        }
    }
}