using System;
using System.Collections.Generic;
using System.Text;
using GameCore;
using UnityEngine;
using HarmonyLib;
using Mirror;
using System.Linq;
using UnityEditor;
using Exiled.API.Enums;

namespace SeedMaker.Patches
{
    [HarmonyPatch(typeof(ImageGenerator), nameof(ImageGenerator.GeneratorTask_SetRooms))]
    public class ImageGenPingPatch
    {
        public static bool Prefix(ImageGenerator __instance)
        {
            ZoneType zone = __instance.height < 0 ? __instance.height < -1000 ? ZoneType.Entrance : ZoneType.HeavyContainment : ZoneType.LightContainment;
            GameCore.Console.AddDebugLog("MAPGEN_PATCH", $"\n-= {zone} =-", MessageImportance.Normal);

            for (int i = 0; i < __instance.map.height; i++)
            {
                GameCore.Console.AddDebugLog("MAPGEN_PATCH",
                    string.Join(" ", __instance.map.GetPixels(0, i, __instance.map.width, 1, 0).Select(e => (e.r > 0.39f && e.r < 0.4f) ? "-" : "X")), MessageImportance.Normal);
            }

            return true;
        }
    }
}
