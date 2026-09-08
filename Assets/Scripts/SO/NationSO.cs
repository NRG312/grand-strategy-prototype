using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Nation", menuName = "Nation/NewNation")]
public class NationSO : ScriptableObject
{
    [SerializeField]private string nation_name;
    public string NationName => nation_name;
    [SerializeField] private string nation_ID;
    public string NationID => nation_ID;
    [SerializeField] private Color nation_color;
    public Color NationColor => nation_color;
    [SerializeField] private Sprite nation_owner_flag;
    public Sprite NationOwnerFlag => nation_owner_flag;
    [SerializeField] private string nation_culture;
    public string NationCulture => nation_culture;

    //kultura
    //dane bazowe
}
