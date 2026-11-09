using UnityEngine;
using VContainer;

[RequireComponent(typeof(HomeView))]
[RequireComponent(typeof(HomeScope))]
public class HomeViewController : ViewController<HomeModel, HomeView>
{
    protected override void SubscribeEvents()
    {
        
    }
}
