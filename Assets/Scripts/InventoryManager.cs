using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public List<ItemT> InvList;
    public List<ItemT> EquipList;
    public List<EquipUI> EquipSlots;
    public GameObject itemTPrefabHolder, Prefab;
    public GameObject[] ItemUIs;
    public GameObject InvPanel, Equip, Inv;
    bool On;
    public bool Stats;

    public static InventoryManager instance;
    public ReSkinAnim RSA;

    void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("i"))
        {
            On = !On;
            if (On)
            {
                PopulateInv();
            }
            InvPanel.SetActive(On);
        }
    }

    public void AddToInv(ItemT item)
    {
        GameObject Temp = Instantiate(Prefab, itemTPrefabHolder.transform);
        ItemT itemT = Temp.GetComponent<ItemT>();
        itemT.SetInfo(item.m_name, item.m_sprite, item.Type, item.stats, item.descript, item.Cost);
        InvList.Add(itemT);
    }


    void PopulateInv()
    {
        for (int i = 0; i < ItemUIs.Length; i++)
        {
            ItemUIs[i].SetActive(false);
        }
        for (int i = 0; i < InvList.Count; i++)
        {
            ItemUIs[i].SetActive(true);
            ItemUI it = ItemUIs[i].GetComponent<ItemUI>();
            it.m_img.sprite = InvList[i].m_sprite;
            it.InvOrder = i;

        }

    }

    public void SetPanel(GameObject Panel)
    {
        Panel.SetActive(true);
        if (Panel.name == "StatsPanel")
        {
            Stats = true;
        }
    }
    public void ClosePanel(GameObject Panel)
    {
        Panel.SetActive(false);
        if (Panel.name == "StatsPanel")
        {
            Stats = false;
        }
    }

    public void EquipItem(int InvOrder)
    {
        for (int x = 0; x < EquipSlots.Count; x++)
        {
            if(InvList[InvOrder].Type == EquipSlots[x].Type)
            {
                if (EquipSlots[x].m_name != "")
                {
                    string elname = EquipSlots[x].m_name;
                    EquipList.Remove(EquipList.Find(el => el.m_name == elname));
                }
            }
        }
            if (EquipList.Contains(InvList[InvOrder]))
        {
            SortEquipment(InvList[InvOrder]);
        }
        else
        {
            EquipList.Add(InvList[InvOrder]);
            SortEquipment(InvList[InvOrder]);
        }
    }

    public void SortEquipment(ItemT itemT)
    {
        for (int x = 0; x < EquipSlots.Count; x++)
        {
            if (itemT.Type == EquipSlots[x].Type)
            {
                EquipSlots[x].m_img.sprite = itemT.m_sprite;
                EquipSlots[x].m_name = itemT.m_name;
                break;
            }
        }
        SetAnimSprites();
    }

    void SetAnimSprites()
    {
        string sheetName = "";
        if(EquipSlots[0].m_name == "Blue Bandana" && EquipSlots[3].m_name == "Red Cape")
        {
            sheetName = "12 - BH-RC";
        }
        if (EquipSlots[0].m_name == "Blue Bandana" && EquipSlots[3].m_name == "Blue Cape")
        {
            sheetName = "12 - BH-BC";
        }
        if (EquipSlots[0].m_name == "Blue Bandana" && EquipSlots[3].m_name == "Green Cape")
        {
            sheetName = "12 - BH-GC";
        }
        if (EquipSlots[0].m_name == "Red Bandana" && EquipSlots[3].m_name == "Red Cape")
        {
            sheetName = "12 - RH-RC";
        }
        if (EquipSlots[0].m_name == "Red Bandana" && EquipSlots[3].m_name == "Blue Cape")
        {                            
            sheetName = "12 - RH-BC";
        }                            
        if (EquipSlots[0].m_name == "Red Bandana" && EquipSlots[3].m_name == "Green Cape")
        {
            sheetName = "12 - RH-GC";
        }
        if (EquipSlots[0].m_name == "Green Bandana" && EquipSlots[3].m_name == "Red Cape")
        {
            sheetName = "12 - GH-RC";
        }
        if (EquipSlots[0].m_name == "Green Bandana" && EquipSlots[3].m_name == "Blue Cape")
        {
            sheetName = "12 - GH-BC";
        }
        if (EquipSlots[0].m_name == "Green Bandana" && EquipSlots[3].m_name == "Green Cape")
        {
            sheetName = "12 - GH-GC";
        }
        RSA.spriteSheetName = sheetName;
    }
}
