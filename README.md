![Mix Logo](docs/logo.png)

# Mix

Combine game assets into modpacks to play in the Unity Engine. Download and share mods on the Steam Workshop. Create mods in the Unity Editor. Monetize mods with no fees from Mix.

_"Imagine the power to mix together thousands of mods to craft your ultimate gaming experience."_

Mix allows you to combine game assets (mods) into modpacks to play in the Unity Engine, though currently, mods must be entirely self-contained as there's no dependency system yet. Download and share mods on the Steam Workshop. Create your mods in the Unity Editor. You are allowed to monetize your mods with no fees from Mix.

### Key Highlights
- **Mod Manager**: Supports downloading, publishing, updating mods, and creating modpacks, with plans for expanded features.
- **Unity Editor Integration**: Creators can build mods entirely in Unity (version 6000.0.23f1).
- **Commercial Mod Support**: Create and monetize mods with Mix taking 0% of earnings, though monetization workflows are still being developed.
- **Steam Workshop Integration**: Allows seamless browsing and mixing of mods from the Steam Workshop.
- **Basic Documentation**: Guides on GitHub to help users get started.
- **Mod Loader**: A foundational system for loading and managing mods within the game, with future improvements planned, including automated dependency resolution and better compatibility handling.
- **Suggested Asset Reuse Policy**: Creators are suggested to allow others to reference their assets in mods, but redistribution is not permitted. This means players must own the original asset to use mods that reference it. This optional policy supports Mix’s vision of fostering a vast and ever-growing library of content by promoting the free flow of ideas and resources, encouraging collaboration and accelerating development. 

### Upcoming Features (In-order)
- **Mod Dependencies**: A system to manage mod dependencies and ensure they load in the correct order, minimizing conflicts and improving compatibility. This should allow large modpacks to be created and shared, with the ability to automatically download and install dependencies from the Steam Workshop.
- **Mod Microtransactions**: A system for creators to sell mods and modpacks. This feature will provide a way for creators to monetize their work and encourage the creation of high-quality content.
- **Expanded Modding Tools**: Additional features and APIs to simplify asset creation and offer more customization options for creators.

### Join the Community
Mix is just beginning, and we’re excited for you to be part of this journey. Jump into the early access version today, share your creations, and help us build the future of modular gaming. The community will shape how Mix grows, and your feedback will help make it even better.


## Pre-requisites
1. Install Unity version 6000.0.23f1 from [Unity Editor Archive](https://unity.com/releases/editor/archive).

## ThirdPersonPlayground Example Mod
Explore the example mod at [ThirdPersonPlayground Repository](https://github.com/mix-steam-app/ThirdPersonPlayground).

## Typical Mod Development Workflow

1. **Create a New Project**: Modders start a new Unity project based on Mix's template, which includes the necessary assets and scripts.
1. **Design Game Logic**: Custom C# scripts are written to define the mod's game mechanics—this could involve new abilities, interactions, or gameplay systems.
1. **Create Assets**: Modders create 3D models, textures, animations, and sound effects within Unity, which can be used in the mod.
1. **Define Entry Point**: An entry point C# class is set up to initialize the mod, load assets, and manage interactions with the game.
1. **Test and Refine**: Modders can test the mod within the Unity environment alongside other mods with Mix's Mod Loader.
1. **Export Assets as AssetBundles**: Assets are then exported as AssetBundles, Unity's method for packaging assets to be loaded dynamically.
1. **Export Logic as Assemblies**: The mod's C# scripts are compiled into assemblies, which are then loaded by Mix at runtime.
1. **Publish Mod**: Modders can publish their mod to the Steam Workshop, where it can be downloaded and installed by players.

## Testing Your Modpack in the Unity Editor
You can test your modpack directly within the Unity Editor:

1. Open the `Assets/Mix/Scenes/Main` scene.
2. Enable the `LOAD ON START` option in the Mix Launcher.
   - This option writes the modpack configuration to Mix’s `persistentDataPath`.
   - The configuration is then read when the `Main` scene is launched.
3. Play the scene in the Unity Editor to load and test your modpack.

## Mod loading

Mix operates by loading the assemblies of mods and instantiating a subclass of `Mix.Mod` defined in each mod's assembly. The process begins in the `Assets/Mix/Scenes/Main` scene. Non-script assets in Unity can be exported using AssetBundles and loaded by mods.
