using R3;
using UnityEngine;
using UnityEngine.UI;

public class StoreView : BaseView
{
#nullable disable
    [SerializeField] Button _close;
#nullable enable

    public Observable<Unit> OnClickClose => _close.OnClickAsSingleObservable();
}
