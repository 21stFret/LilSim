using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkManager : MonoBehaviour
{
    public GameObject TalkPanel, ShopPanel;
    public Text TalkText, TalkName;

    public static TalkManager instance;


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
    public void SetTalkPanel(bool open)
    {
        TalkPanel.SetActive(open);
        if(ShoppingManager.instance.TotalCost>0)
        {
            ShopPanel.SetActive(true);
        }
        else
        {
            ShopPanel.SetActive(false);
        }
    }
    public void SetTalkText(string text, string name)
    {
        TalkText.text = text;
        TalkName.text = name;
    }
    public void SetText(string text)
    {
        TalkText.text = text;
    }
}
