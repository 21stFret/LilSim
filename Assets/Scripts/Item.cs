using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public GameObject InteractUI;
    public Text itemName;
    public string Name;


    // Start is called before the first frame update
    void Start()
    {
        itemName.text = Name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowUI(bool On)
    {
        InteractUI.SetActive(On);
    }
}
