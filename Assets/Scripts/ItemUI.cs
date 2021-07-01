using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    //UI Item
    public int InvOrder;
    public Image m_img;
    public Button EquipB;
    public InventoryManager IM;

    private void Start()
    {
        IM = InventoryManager.instance;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        ItemT t = IM.InvList[InvOrder];
        if (IM.Stats)
        {
            StatsManager.instance.SetStatsPanel(t.m_name, t.Type, t.stats, t.descript, t.m_sprite);
            StatsManager.instance.ShowStatsUI(true);
        }
        else
        {
            EquipB.onClick.AddListener(delegate { IM.EquipItem(InvOrder); });
            EquipB.gameObject.SetActive(true);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        StatsManager.instance.ShowStatsUI(false);
        EquipB.gameObject.SetActive(false);
        EquipB.onClick.RemoveListener(delegate { IM.EquipItem(InvOrder); });
    }
}
