using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[Serializable]
public class ArmyManager : MonoBehaviour
{
    [Inject] private SignalBus _signal;
    [Inject] private UnitArmy.Factory unit_army_factory;
    [SerializeField] private List<GameObject> army_objects = new List<GameObject>();
    [SerializeField] private GameObject object_pool;
    private Province selected_province;

    private void OnEnable()
    {
        _signal.Subscribe<CreateArmyEvent>(CreateArmy);
    }
    private void OnDisable()
    {
        _signal.TryUnsubscribe<CreateArmyEvent>(CreateArmy);
    }


    private void CreateArmy(CreateArmyEvent armyEvent)
    {
        selected_province = armyEvent.province;
        foreach (var army in army_objects)
        {
            if (!army.activeInHierarchy)
            {
                army.SetActive(true);
                InitArmy(army.GetComponent<UnitArmy>());
                RemoveFromGarrison();
                return;
            }
        }
        AddToObjectPool();
    }
    private void AddToObjectPool()
    {
        UnitArmy unit = unit_army_factory.Create();
        unit.transform.SetParent(object_pool.transform);

        InitArmy(unit);
    }
    private void InitArmy(UnitArmy army)
    {
        army.InitArmy(selected_province);
        army.transform.position = selected_province.gameObject.transform.position;
    }
    private void RemoveFromGarrison()
    {
        Garrison garrison = selected_province.garrison;
        garrison.RemoveAllUnits();
    }

    //
    public void RemoveArmy()
    {

    }

    public void MergeArmy()
    {

    }
}
