using UnityEngine;
using Zenject;

public class ProvinceManager : MonoBehaviour
{
    [Inject] private SignalBus _signal;
    [Inject] private NationManager nation_manager;
    [SerializeField] private Province[] provinces;
    [SerializeField] private GameObject prefab_province_name_text;
    public Province selected_province;
    private void OnEnable()
    {
        _signal.Subscribe<ProvinceSelectEvent>(SelectedProvince);
    }
    private void OnDisable()
    {
        _signal.Unsubscribe<ProvinceSelectEvent>(SelectedProvince);
    }

    private void SelectedProvince(ProvinceSelectEvent province)
    {
        selected_province = province.selected_province;
    }
    private void Start()
    {
        foreach  (var province in provinces)
        {
            string id = province.province_SO.Start_owner_ID;
            Nation owner = nation_manager.ReturnProvinceOwner(id);
            province.InitOwner(owner);
            province.SetupProvinceTextName(prefab_province_name_text);
        }
    }
}
