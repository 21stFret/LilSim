using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public GameObject InteractUI;
    public Text itemName;
    public string Name;
    public bool CustItem;


    // Start is called before the first frame update
    void Start()
    {
        SetItemText(Name);    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetItemText(string name)
    {
        itemName.text = name;
    }

    public void ShowUI(bool On)
    {
        InteractUI.SetActive(On);
    }
}
