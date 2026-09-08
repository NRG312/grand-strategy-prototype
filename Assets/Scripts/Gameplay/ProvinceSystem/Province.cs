using TMPro;
using UnityEngine;
using Zenject;

public class Province : MonoBehaviour
{
    public ProvinceSO province_SO;
    public Garrison garrison = new Garrison();
    [Inject] private NationManager nation_manager;
    public string name_province { get; private set; }
    public int id_province { get; private set; }
    public Nation owner_province { get; private set; }
    public int population_province { get; private set; }

    private MeshRenderer mesh_province;

    //wszystkie dane
    //kultura itp
    private void Awake()
    {
        mesh_province = GetComponent<MeshRenderer>();
        Init();
    }
    private void Init()
    {
        name_province = province_SO.Name_province;
        id_province = province_SO.ID_province;
        population_province = province_SO.Start_population;
    }
    public void InitOwner(Nation nation)
    {
        if (nation != null)
        {
            owner_province = nation;
            owner_province.AddNewProvince(this);
            SetColorProvince(nation);
        }
    }

    public void SetupProvinceTextName(GameObject prefab)
    {
        GameObject province_text = Instantiate(prefab);
        province_text.transform.SetParent(transform, true);//true oznacza zeby zostal worldposition dostaje parenta ale nie zmieniajac swojego transform
        TMP_Text text = province_text.GetComponent<TMP_Text>();
        MeshRenderer mesh = GetComponent<MeshRenderer>();

        text.text = name_province;
        text.fontSize = 1.5f;
        float provinceWidth = mesh.bounds.size.x;

        text.gameObject.transform.position = mesh.bounds.center;
        text.gameObject.transform.position = new Vector3(text.gameObject.transform.position.x, 0.05f, text.gameObject.transform.position.z);
        while (text.GetPreferredValues().x > provinceWidth && text.fontSize > 1f)
        {
            text.fontSize -= 0.1f;
        }
    }

    public void SetOwnerProvince(string newNation)
    {
        Nation nation = nation_manager.ReturnProvinceOwner(newNation);
        owner_province = nation;
        SetColorProvince(nation); 
    }

    private void SetColorProvince(Nation nation)
    {
        Color color = nation.Data.NationColor;
        mesh_province.material.color = color;
    }

}
