using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class UnitArmy : MonoBehaviour
{
    private Province actual_province;
    [SerializeField] private SpriteRenderer visual_shield;
    [SerializeField] private SpriteRenderer nation_symbol;
    [SerializeField] private TMP_Text amount_army;
    [SerializeField] private List<UnitType> units = new List<UnitType>();

    private bool isUnitSelected = false;
    public void InitUnit(Province province) //Init Province Unit after created
    {
        actual_province = province;
        nation_symbol.sprite = actual_province.owner_province.Data.NationOwnerFlag;
        //
        int amountGarrison = 0;
        foreach (var item in actual_province.garrison.army_garrison)//Checking amount garrison for unit
        {
            amountGarrison += item.amount;
        }
        amount_army.text = amountGarrison.ToString();
    }

    public void SelectedArmy()
    {
        visual_shield.color = Color.red;
        isUnitSelected = true;
    }
    public void UnSelectedArmy()
    {
        visual_shield.color = Color.white;
        isUnitSelected = false;
    }

    private void Update()
    {
        
    }
}
