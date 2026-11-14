using System;
using UnityEngine;
using VContainer;

public abstract class ViewController<TModel, TView> : UIStackElement
    where TModel : BaseModel
    where TView : BaseView
{
    TModel _model = null!;
    TView _view = null!;
    
    protected TView View => _view;
    protected TModel Model => _model;

    [Inject]
    public void BaseConstruct(TModel model)
    {
        _view = GetComponent<TView>();
        _model = model;
    }

    public override void Init()
    {
        Model.Init();
        SubscribeEvents();
        View.Init();
        OnStart();
    }

    protected abstract void SubscribeEvents();

    protected virtual void OnStart()
    {
    }
}
