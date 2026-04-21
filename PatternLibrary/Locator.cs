using PatternLibrary.GameObject;
using PatternLibrary.Tweening;
using PatternLibrary.Audio;
using PatternLibrary.Collider;

namespace PatternLibrary;

// Service locator. Provides global access to core services without hard-coding
// concrete implementations. Start with null services so nothing crashes before
// real services are registered.
public static class Locator
{
    public static ITweenManager Tweens { get; private set; } = new NullTweenManager();
    public static IGameObjectManager Objects { get; private set; } = new NullGameObjectManager();
    public static ICollisionManager Collisions { get; private set; } = new NullCollisionManager();
    public static IAudio Audio { get; private set; } = new NullAudio();
    //public static GameAssets Assets { get; private set; } = null;

    // Set a new instance of the given interface type
    public static void Provide(IGameObjectManager objects) => Objects = objects;
    public static void Provide(ICollisionManager collisions) => Collisions = collisions;
    public static void Provide(ITweenManager tweens) => Tweens = tweens;
    public static void Provide(IAudio audio) => Audio  = audio;
    //public static void Provide(GameAssets assets) => Assets = assets;
}