using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommandSystem;

namespace SeedMaker.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class SetSeedCmd : ICommand
    {
        public string Command { get; } = "seed.set";

        public string[] Aliases { get; } = { };

        public string Description { get; } = "Set the 'currentSeed' to the given value & lock the seed if need be.";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (arguments.Count > 0)
            {
                if (int.TryParse(arguments.ElementAt(0), out int value))
                {
                    if (Methods.CheckSeedValidity(value))
                    {
                        Data.currentSeed.value = value;
                        response = $"Seed was set to {value} successfully !";

                        if (Data.isRandom.value)
                        {
                            Data.isRandom.value = false;
                            response += "\n[INFO] Seed was locked on set.";
                        }

                        return true;
                    }
                    else response = "Seed shouldn't be 10 digits long (or more) nor equal to -1...";
                }
                else response = "Seed couldn't be parsed, try sending a valid Integer...";
            }
            else response = "No argument was found, expecting the seed to set...";

            return false;
        }
    }
}
