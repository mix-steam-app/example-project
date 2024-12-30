![Mix Logo](docs/logo.png)

Build custom experiences by combining content modules. Share and collaborate via the Steam Workshop, and monetize your work with an upcoming microtransactions system. Join now to shape the future of modular gaming!

# Attention, Creators and Gamers!

Mix is kicking off with a bang, but let's keep it real – we're just at the starting line. Expect a lean launch with limited Workshop content, but don't let that hold you back. This platform is a playground for the creative minds out there, offering you a chance to dive in and shape the future of gaming!

## Unleash Your Creativity

### **Mix and Match**
Combine different creators' content, genres, and gameplay styles to craft unique gaming experiences. Whether it's a quirky indie puzzle or an epic battle royale, your imagination is the limit.

### **Modular Magic**
With Mix, you can stitch together modules into modpacks using Unity. From simple enhancements like new weapons or dance moves to grand features like multiplayer modes, expansive open worlds, or mind-bending physics – it’s all possible.

### **Community Collaboration**
Get involved with the Steam Workshop community. Share, collaborate, and expand on others' modules with tools like **Harmony**. The collective brainpower of creators is your superpower here.

### **Monetize Your Genius**
Start building your modules today in Unity, and prepare to profit. With Mix's upcoming microtransactions system, you can turn your passion into your paycheck.

## Early Bird Gets the Worm

Be among the first to contribute to Mix's Steam Workshop. Your creations could set the standard for what modular, community-driven gaming looks like. We're not just building games; we're pioneering a new era where every player can be a creator.

## Get Involved Now!

Join Mix now to start crafting your modules. Get ready to sell them through our soon-to-launch **Module Microtransactions** system. 

Let’s redefine gaming together – where every piece you create adds to an ever-evolving, player-crafted universe!


# Why Create Modules for Mix?
## Monetize With Low Fees, Keep More Dough  
Monetize your modules or tap into Mix's upcoming microtransactions, powered by Steam. With Steam's 30% cut and Mix’s modest 4% fee, you pocket a sweet 66% of your earnings. More cash for you, less for the man.

## Low Development Overhead, Maximum Impact  
Why break the bank on an entire game when you can make modules? It's like the fast food of game development—quick, affordable, and you still get to eat. Perfect for creators who aren't swimming in venture capital but still want to make a splash.

## Leverage the Unity Editor, Your Creative Beast  
Use Unity Editor's badass tools to whip up, test, and polish your modules. It's like having a Swiss Army knife for game development—versatile, efficient, and it never runs out of blades.

## Reuse Your Assets, Play the Field  
Got Unity assets? Use them to create modules on Mix without starting over. If Mix isn't your fit, no worries - your assets are adaptable and can work across multiple platforms. Flexibility is key.

## Expand on Existing Ideas, Get Creative  
Take what's out there and make it better. Add features, tweak mechanics, or shove concepts into new scenarios. With dependency modules and modding tools like Harmony, you're not just building; you're expanding the universe, one module at a time.

## Increased Sales via Dependencies, Own to Use  
Craft dependency modules that everyone wants. In Mix's "Own to Use" model, owning your dependencies becomes a status symbol, boosting both your bank account and your street cred as other creators use your work.

## Early Market Advantage, Be the Big Fish  
Get in early, become the big fish in a small pond. Establish your name, your style, and your modules. As Mix grows, so does your legend. This is your chance to be the pioneer, the one everyone talks about.

---

If you're looking to make some noise in the gaming world without breaking your back or your bank, Mix might just be the playground you need. Get creative, get paid, and get known.


## Upcoming Features

- **Sell modules** through Module Microtransactions, enabling creators to earn money, promote premium content, and receive financial support. The system includes automatic purchasing and installation of dependencies for a seamless user experience.

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
