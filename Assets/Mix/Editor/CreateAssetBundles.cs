using UnityEditor;
using System.IO;

namespace Mix
{
	public class CreateAssetBundles
	{
		[MenuItem("Mix/Build AssetBundles")]
		static void BuildAllAssetBundles()
		{
			string assetBundleDirectory = "Library/AssetBundles";
			if (!Directory.Exists(assetBundleDirectory))
				Directory.CreateDirectory(assetBundleDirectory);

			BuildPipeline.BuildAssetBundles(assetBundleDirectory,
											BuildAssetBundleOptions.None,
											BuildTarget.StandaloneWindows);
		}
	}
}