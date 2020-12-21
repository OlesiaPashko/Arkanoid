
using Zenject;

public class DependeciesInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<Ball>().FromComponentInHierarchy().AsSingle();
        Container.Bind<Platform>().FromComponentInHierarchy().AsSingle();
        Container.Bind<UIManager>().FromComponentInHierarchy().AsSingle();
        Container.Bind<GameManager>().FromComponentInHierarchy().AsSingle();
        Container.Bind<CollisionManager>().FromComponentInHierarchy().AsSingle();
    }
}
