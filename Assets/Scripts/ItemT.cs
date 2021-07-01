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


    public void SetInfo(string name, Sprite sprite)
    {
        m_name = name;
        m_sprite = sprite;
    }
}
