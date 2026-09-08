using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Zenject;

public class ArmyUI : MonoBehaviour
{
    [Inject] private SignalBus _signal;
    [Inject] private ArmyManager army_manager;
    [SerializeField] private TMP_Text infantry_amount;
    [SerializeField] private TMP_Text cavalry_amount;
    [SerializeField] private TMP_Text all_army_amount;
    private int army_in_province;
    private Province actual_province;
    public List<UnitType> units_province = new List<UnitType>();


    private void Start()
    {
        _signal.Subscribe<ProvinceSelectEvent>(CheckSelectedlProvince);
    }
    private void OnDisable()
    {
        _signal.TryUnsubscribe<ProvinceSelectEvent>(CheckSelectedlProvince);
    }


    private void CheckGarrison()
    {
        for (int i = 0; i < actual_province.garrison.army_garrison.Count; i++)
        {
            if (!units_province.Contains(actual_province.garrison.army_garrison[i]))
            {
                units_province.Add(actual_province.garrison.army_garrison[i]);
            }
        }
    }
    public void InitArmyPanel()
    {
        CheckGarrison();
        foreach (var item in units_province)
        {
            if (item.unit_type.name_unit == "Infantry")
            {
                infantry_amount.text = item.amount.ToString();
                army_in_province += item.amount;
            }
            else if (item.unit_type.name_unit == "Cavalry")
            {
                cavalry_amount.text = item.amount.ToString();
                army_in_province += item.amount;
            }
        }

        all_army_amount.text = army_in_province.ToString();
        army_in_province = 0;
    }

    private void RefreshListUnits()
    {
        units_province.Clear();
    }
    private void CheckSelectedlProvince(ProvinceSelectEvent province)
    {
        if (actual_province != province.selected_province)
        {
            actual_province = province.selected_province;
            RefreshListUnits();
            InitArmyPanel();
        }
    }

    public void CreateArmyTEST()
    {
        army_manager.CreateArmy();
    }
}
