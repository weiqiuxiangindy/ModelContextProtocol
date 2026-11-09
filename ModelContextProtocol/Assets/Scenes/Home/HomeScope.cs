using VContainer;

public class HomeScope : SceneScope<HomeModel, HomeView, HomeViewController>
{
    protected override void Configure(IContainerBuilder builder)
    {
        base.Configure(builder);
        builder.Register<SceneAssetLoader>(Lifetime.Scoped);
    }
}
