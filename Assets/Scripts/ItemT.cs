using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemT : MonoBehaviour
{
    public enum Itemtype
    {
        Head,
        Torso,
        Gloves,
        Feet
    }
    public Itemtype Type;
    public string m_name, stats, descript;
    public Sprite m_sprite;
    public int Cost;

    public void SetInfo(string Name, Sprite sprite, ItemT.Itemtype type, string mstats, string description, int cost)
    {
        m_name = Name;
        m_sprite = sprite;
        Type = type;
        stats = mstats;
        descript = description;
        Cost = cost;
    }
}
