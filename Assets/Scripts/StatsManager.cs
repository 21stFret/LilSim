using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsManager : MonoBehaviour
{
    public static StatsManager instance;
    public Text itemName, itemType, itemStats, itemDes;
    public Image m_Img;
    public GameObject StatsPanel;


    private void Awake()
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
        
    }

    public void ShowStatsUI(bool On)
    {
        StatsPanel.SetActive(On);
    }
    
    public void SetStatsPanel(string ItemName, ItemT.Itemtype Type, string stats, string des, Sprite img)
    {
        itemName.text = ItemName;
        itemStats.text = stats;
        itemDes.text = des;
        itemType.text = Type.ToString();
        m_Img.sprite = img;
    }
}
