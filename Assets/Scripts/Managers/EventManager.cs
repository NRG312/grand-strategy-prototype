using UnityEngine;

public class EventManager : MonoBehaviour
{
    
}

public class ProvinceSelectEvent 
{
    public Province selected_province;

    public ProvinceSelectEvent(Province province)
    {
        selected_province = province;
    }
}
public class ProvinceSelectClearEvent { }
