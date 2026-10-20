using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NationManager : MonoBehaviour
{
    [SerializeField] private NationSO[] nationSO;
    public List<Nation> nations = new List<Nation>();
    private void Awake()
    {
        nations = nationSO.Select(so => new Nation(so)).ToList();
    }

    public Nation ReturnProvinceOwner(string ID) //check by ID what nation is
    {
        return nations.FirstOrDefault(nation => nation.Data.NationID == ID);
    }
}
