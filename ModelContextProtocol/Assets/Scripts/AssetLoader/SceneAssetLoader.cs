using System;
using UnityEngine;
using VContainer;
using Object = UnityEngine.Object;

public class SceneAssetLoader : IDisposable
{
    readonly IAssetLoader _loader;
    
    public SceneAssetLoader(IAssetLoader loader)
    {
        _loader = loader;
    }
    
    public T LoadAsset<T>(string assetName) where T : Object
    {
        return _loader.LoadAsset<T>(assetName);
    }

    public void Dispose()
    {
        Debug.Log("SceneAssetLoader Dispose");
    }
}