using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Zenject;

public class ArmyProvinceUI : MonoBehaviour
{
    [Inject] private SignalBus _signal;
    private Province actual_province;
    [SerializeField] private List<UnitGarrison> unitGarrisonsPrefabs = new List<UnitGarrison>();

    private void Start()
    {
        _signal.Subscribe<ProvinceSelectEvent>(CheckSelectedlProvince);
        _signal.Subscribe<CreateArmyEvent>(DeleteGarisson);
    }
    private void OnDisable()
    {
        _signal.TryUnsubscribe<ProvinceSelectEvent>(CheckSelectedlProvince);
        _signal.TryUnsubscribe<CreateArmyEvent>(DeleteGarisson);
    }
    //Creating prefabs of units garrison in Grid Layout Group
    public void InitArmyPanel()
    {
        List<UnitType> garrison = new List<UnitType>(actual_province.garrison.GetArmyGarrison());
        foreach (var prefab in unitGarrisonsPrefabs)
        {
            prefab.gameObject.SetActive(false);
        }

        foreach (var unit in garrison)
        {
            foreach (var prefab in unitGarrisonsPrefabs)
            {
                if (!prefab.gameObject.activeInHierarchy)
                {
                    prefab.gameObject.SetActive(true);
                    prefab.SetUnit(null, unit.amount);
                    break;
                }
            }
        }
    }
    //Delete Garrison grids from layout
    private void DeleteGarisson()
    {
        foreach (var prefab in unitGarrisonsPrefabs)
        {
            if (prefab.gameObject.activeInHierarchy)
            {
                prefab.gameObject.SetActive(false);
            }
        }
    }
    private void CheckSelectedlProvince(ProvinceSelectEvent province)
    {
        if (actual_province != province.selected_province)
        {
            actual_province = province.selected_province;
            InitArmyPanel();
        }
    }

    public void CreateArmyTEST()
    {
        _signal.Fire<CreateArmyEvent>(new CreateArmyEvent(actual_province));
        _signal.Fire<ProvinceSelectClearEvent>();
    }
}
