using UnityEngine;
using UnityEngine.SceneManagement;

namespace ThirdPersonPlayground
{
	public class Mod : Mix.Mod
	{
		public override void OnLoad(string id)
		{
			Debug.Log("ThirdPersonPlayground mod loaded");
			var scenePaths = this.sceneAssetBundle.GetAllScenePaths();
			SceneManager.LoadScene(scenePaths[0]);
		}
	}
}
