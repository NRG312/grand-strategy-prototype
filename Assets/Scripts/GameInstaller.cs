using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        InstallManagers();
        InstallSignals();
        InstallGameplay();
    }

    private void InstallSignals()
    {
        SignalBusInstaller.Install(Container);

        Container.DeclareSignal<ProvinceSelectEvent>();
        Container.DeclareSignal<ProvinceSelectClearEvent>();
    }
    private void InstallManagers()
    {
        Container.Bind<NationManager>().FromComponentInHierarchy().AsSingle();
        Container.Bind<NationUI>().FromComponentInHierarchy().AsSingle();
        Container.Bind<ProvinceManager>().FromComponentInHierarchy().AsSingle();
        Container.Bind<ArmyManager>().FromComponentInHierarchy().AsSingle();
    }
    private void InstallGameplay()
    {

    }
}
