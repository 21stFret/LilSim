using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    [SerializeField]
    public int TotalMoney;
    public Text MoneyText;
    public static MoneyManager instance;


    void Awake()
    {
        instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        ChangeMoney(1000);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeMoney(int amount)
    {
        TotalMoney += amount;
        MoneyText.text = TotalMoney.ToString();
    }
}
