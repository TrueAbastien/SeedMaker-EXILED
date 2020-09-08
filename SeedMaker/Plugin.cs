using System;
using Exiled.API.Enums;
using Exiled.API.Features;

namespace SeedMaker
{
    public class Plugin : Plugin<Config>
    {
        public override string Name { get; } = "SeedMaker";
        public override string Author { get; } = "Abastien";
        public override PluginPriority Priority { get; } = PluginPriority.Lowest;

        public override void OnEnabled()
        {
            if (!Config.IsEnabled)
            {
                Data.isRandom = true;
                Data.currentSeed = -1;
            }
        }
    }
}
