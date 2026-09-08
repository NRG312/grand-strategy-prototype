using UnityEngine;

[CreateAssetMenu(fileName = "Unit",menuName = "Unit/NewUnitType")]
public class UnitTypeSO : ScriptableObject
{
    public string name_unit;
    public int attack_unit;
    public int defense_unit;
    public int movement_unit;
    public float cost_unit;
    public int time_recruitment_unit;
}
