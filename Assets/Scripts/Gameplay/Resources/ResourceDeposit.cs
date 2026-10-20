using UnityEngine;

[System.Serializable]
public class ResourceDeposit
{
    public ResourceType resourceType;
    public float abundance;
    public float extractionBonus;


    public enum ResourceType
    {
        Coal,
        Iron,
        Copper,
        Gold,
        Stone,
        Wood
    };
}
