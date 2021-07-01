using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public List<ItemT> InvList;
    public List<ItemT> EquipList;
    public List<EquipUI> EquipSlots;
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
        InvList.Add(item);
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
        if(!EquipList.Contains(InvList[InvOrder]))
        {
            EquipList.Add(InvList[InvOrder]);
            SortEquipment();
        }
    }

    public void SortEquipment()
    {
        for (int i = 0; i < EquipList.Count; i++)
        {
            for (int x = 0; x < EquipSlots.Count; x++)
            {
                if (EquipList[i].Type == EquipSlots[x].Type)
                {
                    EquipSlots[x].m_img.sprite = EquipList[i].m_sprite;
                    EquipSlots[x].m_name = EquipList[i].m_name;
                    break;
                }
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
        RSA.spriteSheetName = sheetName;
    }
}
