using UnityEngine;
using Zenject;
using TMPro;
using UnityEngine.UI;
public class ProvinceUI : MonoBehaviour
{
    [Inject] private SignalBus _signal;
    [Inject] private NationUI nation_UI;
    private Province selected_province;
    [SerializeField] private Canvas canvas_province;
    //Buildings pozniej do zrobienia
    //Army pozniej do zrobienia
    [SerializeField] private TMP_Text population_province;
    [SerializeField] private Image owner_province;
    [SerializeField] private TMP_Text culture_province;
    [SerializeField] private TMP_Text province_name;
    //Klimat na pozniej

    public NationSO nation;
    private void OnEnable()
    {
        _signal.Subscribe<ProvinceSelectEvent>(SelectedProvince);
        _signal.Subscribe<ProvinceSelectEvent>(ShowUI);
        _signal.Subscribe<ProvinceSelectClearEvent>(HideUI);
    }
    private void OnDisable()
    {
        _signal.Unsubscribe<ProvinceSelectEvent>(SelectedProvince);
        _signal.Unsubscribe<ProvinceSelectEvent>(ShowUI);
        _signal.Unsubscribe<ProvinceSelectClearEvent>(HideUI);
    }

    private void SelectedProvince(ProvinceSelectEvent province)
    {
        selected_province = province.selected_province;
    }

    private void ShowUI()
    {
        canvas_province.enabled = true;
        population_province.text = selected_province.population_province.ToString();
        province_name.text = selected_province.name_province;
        owner_province.sprite = selected_province.owner_province.Data.NationOwnerFlag;
        culture_province.text = selected_province.owner_province.Data.NationCulture;
    }
    private void HideUI()
    {
        canvas_province.enabled = false;
    }

    public void TurnOnNationPage()
    {
        nation_UI.InitUI(selected_province.owner_province);
    }
    //Test
    public void SetNewOwner()
    {
        selected_province.SetOwnerProvince(nation.NationID);
    }
}
