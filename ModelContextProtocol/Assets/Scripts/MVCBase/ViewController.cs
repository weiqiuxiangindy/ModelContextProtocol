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
    public void BaseConstruct(TModel model, TView view)
    {
        _model = model;
        _view = view;
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
    
    protected void HideBase()
    {
        UIStack.Pop(gameObject);
    }
}
