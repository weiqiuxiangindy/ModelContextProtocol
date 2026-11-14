using UnityEngine;

public class AppManagers : MonoBehaviour
{
#nullable disable
    [SerializeField] AppRootScope _appRootScope;
    [SerializeField] SceneTransitionManager _sceneTransitionManager;
#nullable enable
    
    public void Init()
    {
#if UNITY_EDITOR
        var assetLoader = new EditorAssetLoader();
#else
        var assetLoader = new RuntimeAssetLoader();
#endif
        _appRootScope.SetInstances(assetLoader, _sceneTransitionManager);
        _appRootScope.Build();
        GlobalCanvas.Instance.StackUICamera();
        GlobalCanvas.Instance.UIStack.Push(PrefabRegister.Instance.HomeView);
    }
}
