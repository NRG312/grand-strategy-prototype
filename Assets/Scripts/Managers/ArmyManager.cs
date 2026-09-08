using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[Serializable]
public class ArmyManager : MonoBehaviour
{
    [Inject] private ProvinceManager province_manager; 
    [SerializeField] private List<GameObject> armies = new List<GameObject>();


    public void CreateArmy()
    {
        foreach (var army in armies)
        {
            if (!army.activeInHierarchy)
            {
                army.SetActive(true);
                army.GetComponent<UnitArmy>().InitUnit(province_manager.selected_province);
                army.transform.position = province_manager.selected_province.gameObject.transform.position;
                return;
            }
        }
    }
    public void RemoveArmy()
    {

    }

    public void MergeArmy()
    {

    }
}
