using R3;
using UnityEngine;

[RequireComponent(typeof(StoreView))]
[RequireComponent(typeof(StoreScope))]
public class StoreViewController : ViewController<StoreModel, StoreView>
{
    protected override void SubscribeEvents()
    {
        View.OnClickClose.Subscribe(_ => HideBase());
    }
}
