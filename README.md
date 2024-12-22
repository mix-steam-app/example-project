# Mix Documentation
Mix works by loading the Assemblies of mods and instantiating a subclass of `Mix.Mod` defined in the mod's assembly. This starts at the scene `Assets/Mix/Scenes/Main`. 
Non-script assets in Unity can be exported via AssetBundles.

## Pre-requisites
1. Install Unity 6000.0.23f1 from https://unity.com/releases/editor/archive

## ThirdPersonPlayground example mod
See https://github.com/mix-steam-app/ThirdPersonPlayground

## Testing your modpack directly in the Unity Editor:
You can test-run your modpack directly in the Unity Editor by playing `Assets/Mix/Scenes/Main` after clicking the `LOAD ON START` in the Mix Launcher. `LOAD ON START` writes the modpack's configuration to Mix's `persistentDataPath`, which is then read in the `Main` scene.

