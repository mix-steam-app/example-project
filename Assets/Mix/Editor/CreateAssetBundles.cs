using UnityEditor;
using System.IO;
using UnityEngine;

namespace Mix
{
	public class CreateAssetBundles
	{
		[MenuItem("Mix/Build AssetBundles")]
		static void BuildAllAssetBundles()
		{
			string assetBundleDirectory = "Assets/AssetBundles";
			if (!Directory.Exists(assetBundleDirectory))
				Directory.CreateDirectory(assetBundleDirectory);

			BuildPipeline.BuildAssetBundles(assetBundleDirectory,
				BuildAssetBundleOptions.None,
				BuildTarget.StandaloneWindows);
		}
		static void CopyFilesRecursively(string sourcePath, string targetPath)
		{
			//Now Create all of the directories
			foreach (string dirPath in Directory.GetDirectories(sourcePath, "*", SearchOption.AllDirectories))
			{
				Directory.CreateDirectory(dirPath.Replace(sourcePath, targetPath));
			}

			//Copy all the files & Replaces any files with the same name
			foreach (string newPath in Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories))
			{
				File.Copy(newPath, newPath.Replace(sourcePath, targetPath), true);
			}
		}
		static void ExportMod(string path)
		{
			Debug.Log("Exporting mod: " + path);
			// var buildPath = "Build/Mix/items/";
			string modName = Path.GetFileName(path);
			var buildPath = Path.Join("Build/Mix/items/", modName);
			if (!Directory.Exists(buildPath))
			{
				Debug.Log("Creating directory: " + buildPath);
				Directory.CreateDirectory(buildPath);
			}
			// check if path/metadata.json exists
			if (!File.Exists(Path.Join(path, "metadata.json")))
			{
				Debug.Log("metadata.json not found in " + path);
				return;
			}
			// copy metadata.json to buildPath
			File.Copy(Path.Join(path, "metadata.json"), Path.Join(buildPath, "metadata.json"), true);

			// var buildPath = "Assets/Mix/Build/";
			// var buildPath = Path.Join(Application.persistentDataPath, "items");

			string destinationAssemblyPath = Path.Join(buildPath, "Assemblies");
			if (!Directory.Exists(destinationAssemblyPath))
			{
				Debug.Log("Creating directory: " + destinationAssemblyPath);
				Directory.CreateDirectory(destinationAssemblyPath);
			}

			var sourceAssemblyPath = Path.Join("Library/ScriptAssemblies", modName + ".dll");
			if (File.Exists(sourceAssemblyPath))
			{
				File.Copy(sourceAssemblyPath, Path.Join(destinationAssemblyPath, modName + ".dll"), true);
			}


			var outputAssetBundlePath = Path.Join(buildPath, "AssetBundles");
			var sourceAssetBundlePath = Path.Join(path, "Assets");

			if (Directory.Exists(sourceAssetBundlePath))
			{
				if (!Directory.Exists(outputAssetBundlePath))
					Directory.CreateDirectory(outputAssetBundlePath);
				var builds = new AssetBundleBuild[1];
				builds[0].assetBundleName = "assets";
				builds[0].assetNames = new string[] { sourceAssetBundlePath };
				BuildPipeline.BuildAssetBundles(outputAssetBundlePath, builds, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows);
			}

			var sourceSceneAssetBundlePath = Path.Join(path, "Scenes");
			if (Directory.Exists(sourceSceneAssetBundlePath))
			{
				if (!Directory.Exists(outputAssetBundlePath))
					Directory.CreateDirectory(outputAssetBundlePath);
				var builds = new AssetBundleBuild[1];
				builds[0].assetBundleName = "scenes";
				builds[0].assetNames = new string[] { sourceSceneAssetBundlePath };
				BuildPipeline.BuildAssetBundles(outputAssetBundlePath, builds, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows);
			}

			var internalAssemblyPath = Path.Join(path, "Assemblies");
			if (Directory.Exists(internalAssemblyPath))
			{
				if (!Directory.Exists(destinationAssemblyPath))
					Directory.CreateDirectory(destinationAssemblyPath);
				CopyFilesRecursively(internalAssemblyPath, destinationAssemblyPath);
			}

			

			// var itemsPath = Path.Join(Application.persistentDataPath, "items");
			// CopyFilesRecursively(Path.Join(buildPath), Path.Join(itemsPath, modName));
		}

		[MenuItem("Mix/BuildMods")]
		static void ExportMods()
		{
			ExportMod("Assets/FallingBodies");
			ExportMod("Assets/ThirdPersonPlayground");
			ExportMod("Assets/HarmonyMod");
		}
	}
}