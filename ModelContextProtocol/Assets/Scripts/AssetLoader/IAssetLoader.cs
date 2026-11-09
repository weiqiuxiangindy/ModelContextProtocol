using UnityEngine;

public interface IAssetLoader
{
    public T LoadAsset<T>(string assetName) where T : Object;
}
