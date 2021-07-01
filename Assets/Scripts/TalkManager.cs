using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkManager : MonoBehaviour
{
    public GameObject TalkPanel;
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
    }
    public void SetTalkText(string text, string name)
    {
        TalkText.text = text;
        TalkName.text = name;
    }
}
