using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UnitGarrison : MonoBehaviour
{
    [SerializeField] private TMP_Text amount_unit;
    [SerializeField] private Image image_unit;

    public void SetUnit(Image image,int amount)
    {
        amount_unit.text = amount.ToString();
        image_unit = image;
    }
}
