using UnityEngine;

public class HomeModel : BaseModel
{
    SceneAssetLoader _loader;
    
    public HomeModel(SceneAssetLoader loader)
    {
        _loader = loader;
    }

    public override void Init()
    {
        _loader.LoadAsset<Sprite>("Assets/Scenes/Home.png");
    }
}
