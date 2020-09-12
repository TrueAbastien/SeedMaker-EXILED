using System;
using System.Collections.Generic;
using System.Text;
using GameCore;
using UnityEngine;
using HarmonyLib;
using Mirror;

namespace SeedMaker.Patches
{
	[HarmonyPatch(typeof(RandomSeedSync), nameof(RandomSeedSync.Start))]
	public class FixSeedPatch
	{
		public static bool Prefix(RandomSeedSync __instance)
		{
			try
			{
				if (__instance.isLocalPlayer && NetworkServer.active)
				{
					WorkStation[] array = UnityEngine.Object.FindObjectsOfType<WorkStation>();
					foreach (WorkStation workStation in array)
					{
						workStation.Networkposition = new Offset
						{
							position = workStation.transform.localPosition,
							rotation = workStation.transform.localRotation.eulerAngles,
							scale = Vector3.one
						};
					}

					if (Data.isRandom.value)
                    {
						__instance.Networkseed = ConfigFile.ServerConfig.GetInt("map_seed", -1);
					}
					else
                    {
						__instance.Networkseed = Data.currentSeed.value;
                    }

					while (NetworkServer.active && __instance.seed == -1)
					{
						__instance.Networkseed = UnityEngine.Random.Range(-999999999, 999999999);
						Data.isRandom.value = true;
					}
					Data.currentSeed.value = __instance.Networkseed;
				}

				return false;
			}
			catch
			{
				Exiled.API.Features.Log.Error("RandomSeedSync couldn't be patched...");
				return true;
			}
		}
	}
}
