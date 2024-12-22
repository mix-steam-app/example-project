# Mix Documentation

Mix operates by loading the assemblies of mods and instantiating a subclass of `Mix.Mod` defined in each mod's assembly. The process begins in the `Assets/Mix/Scenes/Main` scene. Non-script assets in Unity can be exported using AssetBundles.

## Pre-requisites
1. Install Unity version 6000.0.23f1 from [Unity Editor Archive](https://unity.com/releases/editor/archive).

## ThirdPersonPlayground Example Mod
Explore the example mod at [ThirdPersonPlayground Repository](https://github.com/mix-steam-app/ThirdPersonPlayground).

## Testing Your Modpack in the Unity Editor
You can test your modpack directly within the Unity Editor:

1. Open the `Assets/Mix/Scenes/Main` scene.
2. Enable the `LOAD ON START` option in the Mix Launcher.
   - This option writes the modpack configuration to Mix’s `persistentDataPath`.
   - The configuration is then read when the `Main` scene is launched.
3. Play the scene in the Unity Editor to load and test your modpack.

