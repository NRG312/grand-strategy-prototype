using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    
}

public class ProvinceSelectEvent 
{
    public Province selected_province { get; }

    public ProvinceSelectEvent(Province province)
    {
        selected_province = province;
    }
}
public class ProvinceSelectClearEvent { }

public class UnitsArmySelectEvent 
{
    public List<UnitArmy> units { get; }

    public UnitsArmySelectEvent(List<UnitArmy> unitArmies)
    {
        units = unitArmies;
    }
}
public class UnitsArmyClearEvent { }

public class CreateArmyEvent
{
    public Province province { get; }
    public CreateArmyEvent(Province province)
    {
        this.province = province;
    }
}
