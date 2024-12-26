using System.Reflection;
using HarmonyLib;
using StarterAssets;
using UnityEngine;

namespace FallingBodies
{
	[HarmonyPatch(typeof(ThirdPersonPlayground.Instance), nameof(ThirdPersonPlayground.Instance.Start))]
	class Patch
	{
		static void Postfix()
		{
			var controllerComponent = GameObject.FindAnyObjectByType<ThirdPersonController>();
			if (controllerComponent == null)
			{
				Debug.LogError("Could not find a ThirdPersonController in the scene.");
				return;
			}

			var spawner = controllerComponent.gameObject.AddComponent<Spawner>();
			spawner.SpawnInterval = 1.0f;
			spawner.SpawnHeight = 5.0f;
			spawner.SpawnPrefab = Mod.Instance.assetBundle.LoadAsset<GameObject>("Assets/FallingBodies/Assets/Prefabs/Cube.prefab");
		}
	}
	public class Mod : Mix.Mod
	{
		public static Mod Instance { get; private set; }
		public override void OnLoad(string id)
		{
			Instance = this;
			var harmony = new Harmony("com.mix.mix.fallingbodies");
			harmony.PatchAll(Assembly.GetExecutingAssembly());
			Debug.Log("FallingBodies mod loaded");
		}
	}
}
