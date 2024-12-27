
using HarmonyLib;

namespace HarmonyMod
{
	public class Mod : Mix.Mod
	{
		public override void OnLoad(string id)
		{
			var harmony = new Harmony("com.mixteam.mix.harmony");
			harmony.PatchAll();
		}
	}
}
