using System;
using System.Collections.Generic;
using System.Text;
using CommandSystem;

namespace SeedMaker.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class LockSeedCmd : ICommand
    {
        public string Command { get; } = "seed.lock";

        public string[] Aliases { get; } = { };

        public string Description { get; } = "Lock the seed to be set on the 'currentSeed' (if different from -1).";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (Data.isRandom.value)
            {
                Data.isRandom.value = false;
                response = "Seed locked successfully !";
                return true;
            }

            response = "Seed has already been locked...";
            return false;
        }
    }
}
