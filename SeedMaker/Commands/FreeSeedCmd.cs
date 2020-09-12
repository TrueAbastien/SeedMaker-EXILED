using System;
using System.Collections.Generic;
using System.Text;
using CommandSystem;

namespace SeedMaker.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class FreeSeedCmd : ICommand
    {
        public string Command { get; } = "seed.free";

        public string[] Aliases { get; } = { };

        public string Description { get; } = "Free the 'currentSeed' to be set randomly, as usual, for each round.";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!Data.isRandom.value)
            {
                Data.isRandom.value = true;
                response = "Seed freed successfully !";
                return true;
            }

            response = "Seed has already been freed...";
            return false;
        }
    }
}
