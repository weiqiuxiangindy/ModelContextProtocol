using R3;
using UnityEngine;

[RequireComponent(typeof(HomeView))]
[RequireComponent(typeof(HomeScope))]
public class HomeViewController : ViewController<HomeModel, HomeView>
{
    protected override void SubscribeEvents()
    {
        View.OnClickStore.Subscribe(_ =>
        {
            UIStack.Push(PrefabRegister.Instance.StoreView);
        });
    }
}
