using UnityEngine;

[CreateAssetMenu(fileName = "Province", menuName = "Province/NewProvince")]
public class ProvinceSO : ScriptableObject
{
    public int ID_province;
    public string Name_province;
    public string Start_owner_ID;
    public int Start_population;
    //region/pozycja
    //klimat
    //zasoby
    //podstawa populacji
}
