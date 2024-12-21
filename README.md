# Mix Documentation
Mix works by loading the Assemblies and AssetBundles of mods and injecting them into the game.

## Pre-requisites
1. Install Unity 6000.0.23f1 from https://unity.com/releases/editor/archive

## How to export Unity's Third Person Controller Starter Playground to Mix as a mod.
1. Clone this example Unity project.
1. Open the project with Unity 6000.0.23f1.
1. Import the Unity's Third Person Controller Starter Asset.



## How to export Unity's Third Person Controller Starter Asset to Mix as a mod
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