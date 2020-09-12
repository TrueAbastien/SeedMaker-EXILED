using System;
using Exiled.API.Enums;
using Exiled.API.Features;

namespace SeedMaker
{
    public class Plugin : Plugin<Config>
    {
        public override string Name { get; } = "SeedMaker";
        public override string Author { get; } = "Abastien";

        private HarmonyLib.Harmony instance;
        private static int counter;

        public override void OnEnabled()
        {
            if (Config.IsEnabled)
            {
                instance = new HarmonyLib.Harmony($"abastien.seedmaker.{++counter}");
                instance.PatchAll();
            }
            else
            {
                Data.isRandom.Reset();
                Data.currentSeed.Reset();
            }
        }
        public override void OnDisabled()
        {
            instance?.UnpatchAll();
        }
    }
}
