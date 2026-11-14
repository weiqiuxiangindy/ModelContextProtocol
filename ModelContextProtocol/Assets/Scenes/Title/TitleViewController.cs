using UnityEngine;

[RequireComponent(typeof(TitleView))]
[RequireComponent(typeof(TitleScope))]
public class TitleViewController : ViewController<TitleModel, TitleView>
{
    protected override void SubscribeEvents()
    {
    }
}
