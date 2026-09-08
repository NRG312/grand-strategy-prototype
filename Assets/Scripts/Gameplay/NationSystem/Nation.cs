using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable] //aby moc pokazywac dane w inspektorze w NationManager
public class Nation
{
    public NationSO Data;

    public List<Province> own_provinces = new List<Province>();

    public Nation(NationSO nation)
    {
        Data = nation;
    }

    public void AddNewProvince(Province province)
    {
        own_provinces.Add(province);
    }
    public void RemoveProvince(Province province)
    {
        own_provinces.Remove(province);
    }

    public int GetArmy()
    {
        return 0;
    }
    public int GetPopulation()
    {
        int populationAmount = 0;
        foreach (var province in own_provinces)
        {
            populationAmount += province.population_province;
        }
        return populationAmount;
    }
    public int GetProvinces()
    {
        return own_provinces.Count;
    }
}
