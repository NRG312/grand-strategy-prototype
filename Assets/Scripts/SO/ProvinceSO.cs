using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Province", menuName = "Province/NewProvince")]
public class ProvinceSO : ScriptableObject
{
    [Header("Main Data")]
    public int ID_province;
    public string Name_province;
    public string Start_owner_ID;
    public int Start_population;
    [Space(10f)]
    [Header("Start Army")]
    public List<UnitType> start_unit_garrison;

    [Space(10f)]
    [Header("Resources")]
    public ResourceDeposit[] Resource;
    //region/pozycja
    //klimat
    //podstawa populacji
}
