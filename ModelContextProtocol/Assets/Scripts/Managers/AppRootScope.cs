using Unity.VisualScripting;
using VContainer;
using VContainer.Unity;

public class AppRootScope : LifetimeScope
{
    public static AppRootScope Instance { get; private set; }

    protected override void Awake()
    {
        Instance = this;
        base.Awake();
    }
    
    protected override void Configure(IContainerBuilder builder)
    {
#if UNITY_EDITOR
        builder.Register<IAssetLoader, EditorAssetLoader>(Lifetime.Singleton);
#else
        builder.Register<IAssetLoader, RuntimeAssetLoader>(Lifetime.Singleton);
#endif
    }
}
