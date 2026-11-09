using UnityEngine;

public class RuntimeAssetLoader : IAssetLoader
{
    public T LoadAsset<T>(string assetName) where T : Object
    {
        Debug.Log("EditorAssetLoaderからアセットを取得");
        return null!;
    }
}