using UnityEngine;

public class EditorAssetLoader : IAssetLoader
{
    public T LoadAsset<T>(string assetName) where T : Object
    {
        Debug.Log($"EditorAssetLoaderからアセットを取得{assetName}");
        return null!;
    }
}