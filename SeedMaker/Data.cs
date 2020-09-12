using System;
using System.Collections.Generic;
using System.Text;

namespace SeedMaker
{
    public static class Data
    {
        public class DataWrapper<T>
        {
            private T __value, __safe;
            public DataWrapper(T val)
            {
                __value = val;
                __safe = val;
            }
            public void Reset() => __value = __safe;
            public T defaultValue { set { __safe = value; } }
            public T value
            {
                get { return __value; }
                set { __value = value; }
            }
        }

        public static DataWrapper<bool> isRandom = new DataWrapper<bool>(true);
        public static DataWrapper<int> currentSeed = new DataWrapper<int>(-1);
    }
}
