# Mix Documentation
Mix works by loading the Assemblies of mods and instantiating a subclass of `Mix.Mod` defined in the mod's assembly. This starts at the scene `Assets/Mix/Scenes/Main`. 
Non-script assets in Unity can be exported via AssetBundles.

## Pre-requisites
1. Install Unity 6000.0.23f1 from https://unity.com/releases/editor/archive

## Testing your modpack directly in the Unity Editor:
You can test-run your modpack directly in the Unity Editor by playing `Assets/Mix/Scenes/Main` after clicking the `LOAD ON START` in the Mix Launcher. `LOAD ON START` writes the modpack's configuration to Mix's `persistentDataPath`, which is then read in the `Main` scene.

## How to export Unity's Third Person Controller Starter Playground to Mix as a mod.
1. Clone this example Unity project.
1. Open the project with Unity 6000.0.23f1.
1. Import the Unity's Third Person Controller Starter Asset.
1. Create a `Mod.cs` in `Assets/StarterAssets` containing a subclass of `Mix.Mod`, which acts as the entrypoint for this mod.
	1. In the constructor, access Mix.Main to get the path to your mod's directory. Then load the AssetBundles and load the Playground scene.
1. Generate AssetBundles and Assemblies for the Third Person Controller Starter Playground.
	1. Be sure to add Unity Input System to the assembly definition's references.
1. Open the `items` folder at `LocalLow/Team Mix/Mix/items` via the folder button on the left sidebar in Mix. 
1. Subscribe to and copy one of the sample mods in the Steam Workshop to the `items` folder. Use this as a template for your mod.
1. Copy the generated AssetBundles and Assemblies to your mod's folder.
	1. The Playground assembly also needs `Cinemachine.dll`
1. Configure `item.json` and `mod.json` to match your mod.
1. You're done! Mix should detect your mod and you should be able add it to your modpacks.


## How to export Unity's Third Person Controller Starter Asset to Mix as a mod (OUTDATED)
This guide assumes that you have a basic understanding of Unity and Github.
1. Create the project and import prerequisites.
	1. Create a new Unity 6000.0.23f1 3D URP project.
	1. Copy the `MixSDK` folder from this repo to the `Assets` folder of your project.
	1. Import the Unity's Third Person Controller Starter Asset.
	1. Copy the `ModEntryExample` C# script from this repo to the `StarterAssets` folder.
1. Generate AssetBundles and Assemblies. 
	1. Assign `Assets/StarterAssets/ThirdPersonController/Scenes/Playground` to an AssetBundle.
	1. On the toolbar, click `Mix` > `Build AssetBundles`.
	1. Create a Scripting Assembly Definition for the `StarterAssets` folder called `ThirdPersonExampleMod`. This generates a `ThirdPersonExampleMod.dll` file in the `Library/ScriptAssemblies` folder.
1. Copy the generated AssetBundles and Assemblies to the mod's folder.
	1. Copy the `ModExample` folder from this repo to Mix's `items` folder.
	1. Copy your asset bundle from `Assets/AssetBundles` to `ModExample/AssetBundles`.
	1. Copy the `ThirdPersonExampleMod.dll` from `YourProject/Library/ScriptAssemblies` to `ModExample/Assemblies`.
1. You're done! Mix should detect your mod and you should be able add it to your modpacks.
