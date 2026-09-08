using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class NationManager : MonoBehaviour
{
    [SerializeField] private NationSO[] nationSO;
    public List<Nation> nations;
    private void Awake()
    {
        for (int i = 0; i < nationSO.Length; i++)
        {
            Nation newNation = new Nation(nationSO[i]);
            nations.Add(newNation);
        }
    }

    public Nation ReturnProvinceOwner(string ID) //check by ID what nation is
    {
        foreach (var nation in nations)
        {
            if (nation.Data.NationID == ID)
            {
                return nation;
            }
        }
        return null;
    }
}
