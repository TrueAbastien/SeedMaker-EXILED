using System;
using System.Collections.Generic;
using System.Text;

namespace SeedMaker
{
    public static class Methods
    {
        public static bool CheckSeedValidity(int seed)
        {
            return seed > -999999999 && seed <= 999999999 && seed != -1;
        }
    }
}
