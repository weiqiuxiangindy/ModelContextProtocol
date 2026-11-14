using Unity.VisualScripting;
using VContainer;
using VContainer.Unity;

public class AppRootScope : LifetimeScope
{
    IAssetLoader _assetLoader = null!;
    SceneTransitionManager _sceneTransitionManager = null!;
    public static AppRootScope Instance { get; private set; } = null!;
    
    protected override void Awake()
    {
        Instance = this;
        base.Awake();
    }

    public void SetInstances(IAssetLoader assetLoader, SceneTransitionManager sceneTransitionManager)
    {
        _assetLoader = assetLoader;
        _sceneTransitionManager = sceneTransitionManager;
    }
    
    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterInstance(_assetLoader);
        builder.RegisterInstance(_sceneTransitionManager);
    }
}
