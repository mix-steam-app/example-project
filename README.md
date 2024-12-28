![Mix Logo](docs/logo.png)

# Mix

Blend modules into modpacks to create custom experiences. Create complex modpacks with module dependencies. Create your modules in the Unity Editor, and share them on the Steam Workshop. Monetize your modules with no fees from Mix.

_"Imagine the power to mix together content from thousands of creators to craft your ultimate gaming experience."_

Mix enables you to blend modules containing game assets into modpacks to make custom experiences in the Unity Engine. Modules are loaded from assemblies with dependency management, and thus could potentially add a large variety of new features such as new game modes, multiplayer, cutting-edge graphics, massive worlds, and more. With the Steam Workshop and Mix's dependency management, you can work with other creators by sharing assets and mods to create a vast library of interconnected modules. You can create modules in the Unity Editor, which allows you to leverage the engine's powerful tools and workflows, and gives you the flexibility to reuse your modules outside of Mix. There are no fees from Mix if you choose to monetize your modules. Join Mix to push the boundaries of modular gaming and community-sourced game development!

### Upcoming Features
- **Module Microtransactions**: A platform where creators can sell modules, enabling them to earn money from their creations, foster the development of premium content, and receive financial support. This will be done with Steam Workshop microtransactions.

### New Features (2.0.0)
- **Module Dependencies**: A system to manage module dependencies and ensure they load in the correct order, minimizing conflicts and allowing creators to build upon each other's work.
- **Automatic Dependency Installation**: Automatically install missing dependencies when playing a modpack.
- **Module Exporter/Builder**: A Unity script is provided to help prepare modules for sharing. This script exports the module's assets and metadata to a folder, which can then be uploaded to the Steam Workshop.
- **Example Modules**: Three example modules ("HarmonyMod", "ThirdPersonPlayground", and "FallingCubes") are included to demonstrate how modules can be created and used. These modules can be downloaded from the Steam Workshop.
- **Snackbar Notifications**: Improved user feedback when using the mod manager with snackbar notifications.

### Features
- **Module Manager**: Supports downloading, publishing, updating modules, and creating modpacks.
- **Module Loader**: A system for loading modules within the game. Mix loads the assemblies of modules and instantiates a subclass of `Mix.Mod` defined in each mod's assembly.
- **Create in the Unity Editor**: Creators can build modules entirely in Unity (version 6000.0.23f1), leveraging the engine's powerful tools and workflows.
- **Module Monetization**: Monetize your modules with no fees from Mix, though Module Microtransactions are in development.
- **Steam Workshop Integration**: Use the Steam Workshop to browse, download, and share modules.
- **Asset Sharing**: Creators are recommended to allow others to use and reference their assets in modules, but redistribution is not permitted. This means players must own the dependency module to use dependent modules that reference it, so the creators of the dependency benefit from the dependent's popularity. This optional policy supports Mix’s vision of fostering a vast and ever-growing library of content by promoting the free flow of ideas and resources, encouraging collaboration and accelerating development. 
- **Documentation**: Material on GitHub to help users get started.

## Pre-requisites
1. Install Unity version 6000.0.23f1 from [Unity Editor Archive](https://unity.com/releases/editor/archive).

## HOW-TO: Create and publish a module that loads Unity's ThirdPersonController Playground scene
1. See the `Assets/ThirdPersonPlayground` folder to see the reference module.
1. Clone this repository and open it in Unity.
1. Re-import Unity's Starter Assets: ThirdPersonController from the Asset Store.
1. Create a folder for your module in the `Assets` folder. For example, `Assets/MyPlayground`.
1. Create a file called `metadata.json` in that folder. This file should contain the following:
   ```json
   {
	 "title": "MyPlayground",
	 "description": "A module that loads Unity's ThirdPersonController Playground scene.",
	 "dependencies": []
   }
   ```
	1. `dependencies` is an array of the ID of the modules that this module depends on. For example, if your module depends on another module called `HarmonyMod`, you would write `"dependencies": ["HarmonyMod"]`. If depending on a Workshop module, use the Workshop ID. If depending on a local module, use the module's folder name.
1. Create a C# script in the folder that extends `Mix.Mod`. For example, `Mod.cs`:
   ```csharp
	using UnityEngine;
	using UnityEngine.SceneManagement;

	namespace MyPlayground
	{
		public class Mod : Mix.Mod
		{
			public override void OnLoad(string id)
			{
				var scenePaths = this.sceneAssetBundle.GetAllScenePaths();
				SceneManager.LoadScene(scenePaths[0]);
			}
		}
	}
   ```
	1. `OnLoad` is called when the module is loaded. In this example, it loads the first scene in the module's asset bundle. `OnLoad` is called after this module's dependencies' `OnLoad` methods are called.
	1. `this.sceneAssetBundle` is a loaded AssetBundle containing the module's scenes at `Assets/MyPlayground/Scenes`.
	1. `this.assetBundle` is a loaded AssetBundle containing the module's non-scene assets at `Assets/MyPlayground/Assets`.
1. Create an Assembly Definition file in the folder. For example, `MyPlayground.asmdef`
	1. Unity will generate a `.dll` file for this module at `Library/ScriptAssemblies/MyPlayground.dll`. This file is required for the module to be loaded by Mix.
1. Copy the `Playground` scene from the ThirdPersonController asset to the module's `Scenes` folder. (`Assets/Starters/ThirdPersonController/Scenes/Playground.unity`).
	1. This is for convenience with Mix's module exporter.
1. Create a Assembly Definition for at `StarterAssets/StarterAssets.asmdef` since it contains logic that is used the `Playground` scene.
	1. Add `Unity.InputSystem` to the references.
1. Edit `Assets/Mix/Editor/CreateAssetBundles.cs`'s `BuildModules` method to include your module:
   ```csharp
	[MenuItem("Mix/BuildMods")]
	public static void BuildModules()
	{
		ExportMod("Assets/MyPlayground");
	}
   ```
1. On the toolbar, click `Mix` -> `BuildMods` to export the module to a `Build/Mix/items` folder.
1. Copy `Library/ScriptAssemblies/StarterAssets.dll` to the `Build/Mix/items/MyPlayground/Assemblies` folder.
1. Copy `Library/ScriptAssemblies/Cinemachine.dll` to the `Build/Mix/items/MyPlayground/Assemblies` folder.
1. Copy `Build/Mix/items/MyPlayground` to the `AppData/LocalLow/Mix Team/Mix/items` folder so Mix can detect the module.
1. In the Mix Launcher, click the module's gear button and publish to the Workshop!

## Testing Your Modpack in the Unity Editor
You can test your modpack directly within the Unity Editor:

1. Click the `LOAD ON START` option in the Mix Launcher.
   - This option writes the modpack configuration to `AppData/LocalLow/Mix Team/Mix/modIdAndPaths.json`.
   - This list of mods will be loaded in order when the scene is played.
1. Play the `Assets/Mix/Scenes/Main` scene to load and test your modpack.
