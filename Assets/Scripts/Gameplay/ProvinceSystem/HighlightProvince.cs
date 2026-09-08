using UnityEngine;
using Zenject;

public class HighlightProvince : MonoBehaviour
{
    [Inject] private SignalBus _signal;
    private Province selected_province;
    //private Color selected_province_color;
    private void OnEnable()
    {
        _signal.Subscribe<ProvinceSelectEvent>(ChangeColor);
        _signal.Subscribe<ProvinceSelectClearEvent>(ClearColors);
    }
    private void OnDisable()
    {
        _signal.Unsubscribe<ProvinceSelectEvent>(ChangeColor);
        _signal.Unsubscribe<ProvinceSelectClearEvent>(ClearColors);
    }

    private void ChangeColor(ProvinceSelectEvent province)
    {
        MeshRenderer mesh = province.selected_province.gameObject.GetComponent<MeshRenderer>();
        if (selected_province == null)
        {
            selected_province = province.selected_province;
            mesh.material.color = Color.red;
        }
        else if (selected_province != province.selected_province)
        {
            selected_province.gameObject.GetComponent<MeshRenderer>().material.color = selected_province.owner_province.Data.NationColor;
            selected_province = province.selected_province;
            mesh.material.color = Color.red;
        }
    }
    private void ClearColors()
    {

    }
}
