_"Imagine the power to mix and match thousands of mods to craft your ultimate gaming experience."_


**Mix: A New Modding Platform in Early Access**

Mix is a brand-new modding platform designed for creative gamers and developers eager to pioneer modding in Unity. While the platform is still in its early stages and lacks existing mods, it offers a unique opportunity to shape the future of modular gaming.

**Key Highlights:**
- **Mod Manager**: Supports downloading, publishing, updating mods, and creating modpacks, with plans for expanded features.
- **Unity Editor Integration**: Modders can build mods entirely in Unity (version 6000.0.23f1).
- **Commercial Mod Support**: Create and monetize mods with Mix taking 0% of earnings, though monetization workflows are still being developed.
- **Steam Workshop Integration**: Allows seamless browsing and mixing of mods from the Steam Workshop.
- **Basic Documentation**: Guides on GitHub to help users get started.

Mix currently includes limited examples, such as the Unity Third Person Playground scene, to demonstrate mod interactions. Developers are encouraged to join and innovate as the platform evolves, with new tools and features being added regularly.

## Mod loading

Mix operates by loading the assemblies of mods and instantiating a subclass of `Mix.Mod` defined in each mod's assembly. The process begins in the `Assets/Mix/Scenes/Main` scene. Non-script assets in Unity can be exported using AssetBundles and loaded by mods.


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

