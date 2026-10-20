using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private UnitArmy army_prefab;
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
        Container.DeclareSignal<UnitsArmySelectEvent>();
        Container.DeclareSignal<UnitsArmyClearEvent>();
        Container.DeclareSignal<CreateArmyEvent>();
    }
    private void InstallManagers()
    {
        Container.Bind<NationManager>().FromComponentInHierarchy().AsSingle();
        Container.Bind<NationUI>().FromComponentInHierarchy().AsSingle();
        Container.Bind<ProvinceManager>().FromComponentInHierarchy().AsSingle();
        Container.Bind<ArmyManager>().FromComponentInHierarchy().AsSingle();
        Container.Bind<ArmyUI>().FromComponentInHierarchy().AsSingle();
    }
    private void InstallGameplay()
    {
        Container.BindFactory<UnitArmy, UnitArmy.Factory>().FromComponentInNewPrefab(army_prefab);
    }
}
