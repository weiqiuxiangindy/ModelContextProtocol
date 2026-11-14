using UnityEngine;

public class StoreModel : BaseModel
{
    readonly SceneAssetLoader _loader;
    
    public StoreModel(SceneAssetLoader loader)
    {
        _loader = loader;
    }

    public override void Init()
    {
        _loader.LoadAsset<Sprite>("Assets/Scenes/Store.png");
    }
}
