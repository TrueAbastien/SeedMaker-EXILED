using System;
using System.Collections.Generic;
using System.Text;
using CommandSystem;

namespace SeedMaker.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class InfoSeedCmd : ICommand
    {
        public string Command { get; } = "seed.info";

        public string[] Aliases { get; } = { };

        public string Description { get; } = "Display info related to the current state of Seed making.";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            response = Data.isRandom ?
                $"Seed is currently randomized to {Data.currentSeed}." :
                $"Seed has been locked to {Data.currentSeed}.";
            return true;
        }
    }
}
