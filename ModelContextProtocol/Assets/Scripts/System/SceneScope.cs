using VContainer;
using VContainer.Unity;

public abstract class SceneScope<TModel, TView, TViewController> : LifetimeScope
    where TModel : BaseModel
    where TView : BaseView
    where TViewController : ViewController<TModel, TView>
{
    protected override void Awake()
    {
        parentReference.Object = AppScope.Instance;
        base.Awake();
    }

    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<TModel>(Lifetime.Scoped);
        builder.RegisterComponent(GetComponent<TViewController>());
    }
}
