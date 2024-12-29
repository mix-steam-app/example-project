![Mix Logo](docs/logo.png)

Build custom experiences by combining content modules. Share and collaborate via the Steam Workshop, and monetize your work with an upcoming microtransactions system. Join now to shape the future of modular gaming!

# Mix

Mix strives to empower you to craft your ultimate gaming experience by combining content from thousands of creators and universes. With the platform still growing and few modules available, creators have a unique opportunity to be among the first in the Mix Steam Workshop.

Combine modules into modpacks to create custom experiences in Unity. Load modules from assemblies to add features ranging from small additions like new items or animations to larger ones like multiplayer support, open-world maps, or advanced physics. Collaborate with other creators via Steam Workshop and module dependencies. Build modules in Unity and monetize your work independently or through Mix's upcoming microtransactions system.

Join now to start creating your own modules and get ready to sell them through the upcoming Module Microtransactions system. Let's pioneer the future of modular gaming and community-driven development!

## Why Create Modules for Mix?

**Monetize With Low Fees**  
Monetize your modules or use Mix’s upcoming microtransactions system, powered by Steam. With Steam's 30% fee and Mix’s 5% platform fee, you keep 65% of your earnings.

**Low Overhead**  
Creating modules is less resource-intensive than developing full games, allowing creators with limited resources to participate and start earning without a huge investment.

**Leverage the Unity Editor**  
Take advantage of Unity Editor’s powerful tools to efficiently create, test, and refine your modules, speeding up development and ensuring quality.

**Expand on Existing Ideas**  
Modify and build upon existing modules, introducing new features, refining mechanics, or adapting them to new contexts, unlocking endless creative possibilities.

**Increased Product Lifespan through Dependency Modules**  
Design dependency modules that maintain value across projects. With Mix's "Own to Use" model, players must own dependencies to access dependent mods, creating ongoing monetization. As your modules are integrated into more projects, they boost your reputation and provide lasting value.

**Flexibility**  
Create modules that can be used across various games or modpacks, expanding your reach, increasing utility, and offering reusability.

**Early Market Advantage**  
By being an early creator on the platform, you have the opportunity to establish yourself and potentially become a leading figure in this growing ecosystem.

## Upcoming Features

- **Sell modules** through Module Microtransactions, allowing creators to earn money, foster premium content, and gain financial support. Utilize Steam Inventory Service Items dynamically linked to Steam Workshop Items for a streamlined shopping experience, including automatic dependency purchasing and installation.

## New Features (Dec 27)

- **Manage module dependencies** and ensure they load in the correct order to minimize conflicts and enable creators to build on each other's work.
- **Install missing dependencies** automatically when playing a modpack.
- **Prepare modules** for sharing with the Module Exporter/Builder script. Export assets and metadata to a folder for upload to the Steam Workshop.
- **Download example modules** ("HarmonyMod", "ThirdPersonPlayground", and "FallingCubes") to learn how modules can be created and used.
- **Receive feedback** through snackbar notifications for improved user interaction with the mod manager.

## Features (Dec 21)

- **Download, publish, update modules, and create modpacks** with the Module Manager.
- **Load modules** within the game through the Module Loader, instantiating a subclass of `Mix.Mod` defined in each mod's assembly.
- **Create modules** in Unity (version 6000.0.23f1) using powerful tools and workflows.
- **Monetize modules** independently with no fees from Mix.
- **Browse, download, and share modules** through Steam Workshop integration.
- **Encourage asset sharing** while retaining control over redistribution, benefiting creators whose assets are referenced by other modules.
- **Access documentation** on GitHub to get started with module creation.

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
1. Create a C# script in the `Scripts` folder that extends `Mix.Mod`. For example, `Mod.cs`:
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
1. Create an Assembly Definition file in the folder's `Scripts` folder. For example, `Scripts/MyPlayground.asmdef`:
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
