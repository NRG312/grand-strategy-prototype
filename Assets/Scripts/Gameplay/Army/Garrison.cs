using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
[Serializable]
public class Garrison
{
    private List<UnitType> army_garrison = new List<UnitType>();
    public List<UnitType> GetArmyGarrison()
    {
        return army_garrison;
    }
    public void AddUnits(List<UnitType> units)
    {
        army_garrison.AddRange(units);
    }

    public void RemoveUnits(List<UnitType> unit)
    {
        army_garrison.RemoveAll(units => unit.Contains(units));
    }
    public void RemoveAllUnits()
    {
        army_garrison.Clear();
    }
}
