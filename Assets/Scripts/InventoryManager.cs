using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{

    public static InventoryManager instance;
    public GameObject InventoryPanel;
    bool switcher;


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
        if (Input.GetKeyDown("i"))
        {
            SetInvPanelSwitch();
        }
    }

    public void SetInvPanel(bool open)
    {
        InventoryPanel.SetActive(open);
    }
    public void SetInvPanelSwitch()
    {
        switcher = !switcher;
        InventoryPanel.SetActive(switcher);
    }
}
