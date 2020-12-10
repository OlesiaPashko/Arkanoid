
using Zenject;

public class GreetingInstaller : MonoInstaller<GreetingInstaller>
{
    public override void InstallBindings()
    {
        Container.Bind<IGreeting>().To<Greeting>().AsSingle();
    }
}
