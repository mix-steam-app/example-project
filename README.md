![Mix Logo](docs/logo.png)

# Mix

Combine modular game assets into modpacks to play in the Unity Engine. Download and share modules on the Steam Workshop. Create modules in the Unity Editor. Monetize your modules with no fees from Mix.

_"Imagine the power to mix together content from thousands of creators to craft your ultimate gaming experience."_

Mix enables you to blend modules containing game assets into modpacks for use in the Unity Engine. Currently, modules need to be self-contained since there isn't a dependency system in place. You can download and share modules via the Steam Workshop, and create your modules using the Unity Editor. There are no fees from Mix if you choose to monetize your modules. Join Mix to be at the forefront of modular gaming's future!

### Features
- **Module Manager**: Supports downloading, publishing, updating modules, and creating modpacks.
- **Module Loader**: A foundational system for loading and managing modules within the game.
- **Unity Editor Integration**: Creators can build modules entirely in Unity (version 6000.0.23f1).
- **Creator Monetization**: Monetize your modules with no fees from Mix, though monetization workflows are still being developed.
- **Steam Workshop Integration**: Use the Steam Workshop to download and share modules.
- **Asset Sharing**: Creators are recommended to allow others to use and reference their assets in modules, but redistribution is not permitted. This means players must own the dependency module to use dependent modules that reference it, so the creators of the dependency module benefit from the dependent module's popularity. This optional policy supports Mix’s vision of fostering a vast and ever-growing library of content by promoting the free flow of ideas and resources, encouraging collaboration and accelerating development. 
- **Documentation**: Guides on GitHub to help users get started.

### Upcoming Features (Ordered by Priority)
- **Module Dependencies**: A system to manage module dependencies and ensure they load in the correct order, minimizing conflicts and improving compatibility. This should allow large modpacks to be created and shared, with the ability to automatically download and install dependencies from the Steam Workshop.
- **Module Microtransactions**: A platform where creators can sell modules, enabling them to earn money from their creations, foster the development of premium content, and receive financial support. This will be done with Steam Workshop microtransactions.

### Join the Community
Mix is just beginning, and we’re excited for you to be part of this journey. Jump into the early access version today, share your creations, and help us build the future of modular gaming. The community will shape how Mix grows, and your feedback will help make it even better.

## Pre-requisites
1. Install Unity version 6000.0.23f1 from [Unity Editor Archive](https://unity.com/releases/editor/archive).

## Testing Your Modpack in the Unity Editor
You can test your modpack directly within the Unity Editor:

1. Open the `Assets/Mix/Scenes/Main` scene.
2. Enable the `LOAD ON START` option in the Mix Launcher.
   - This option writes the modpack configuration to Mix’s `persistentDataPath`.
   - The configuration is then read when the `Main` scene is launched.
3. Play the scene in the Unity Editor to load and test your modpack.

## Module loading

Mix operates by loading the assemblies of modules and instantiating a subclass of `Mix.Mod` defined in each mod's assembly. The process begins in the `Assets/Mix/Scenes/Main` scene. Non-script assets in Unity can be exported using AssetBundles and loaded by modules.
