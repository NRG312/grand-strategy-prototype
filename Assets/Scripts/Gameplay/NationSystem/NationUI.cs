using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class NationUI : MonoBehaviour
{
    [SerializeField] private Canvas nation_canvas;
    [SerializeField] private TMP_Text population_amount;
    [SerializeField] private TMP_Text army_amount;
    [SerializeField] private TMP_Text provinces_amount;
    [SerializeField] private TMP_Text dominant_culture;
    [SerializeField] private Image image_owner;
    //system krola i dziedzica
    //w przyszlosci system dominujacej kultury
    public void InitUI(Nation nation)
    {
        nation_canvas.enabled = true;
        //

        population_amount.text = nation.GetPopulation().ToString();
        army_amount.text = nation.GetArmy().ToString();
        provinces_amount.text = nation.GetProvinces().ToString();
        dominant_culture.text = nation.Data.NationCulture;
        image_owner.sprite = nation.Data.NationOwnerFlag;
    }
}
