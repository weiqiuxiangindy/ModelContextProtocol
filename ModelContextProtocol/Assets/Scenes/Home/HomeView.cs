using R3;
using UnityEngine;
using UnityEngine.UI;

public class HomeView : BaseView
{
#nullable disable
    [SerializeField] Button _store;
#nullable enable

    public Observable<Unit> OnClickStore => _store.OnClickAsSingleObservable();
}
