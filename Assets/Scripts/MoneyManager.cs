using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    [SerializeField]
    public int TotalMoney;
    public static MoneyManager instance;


    void Awake()
    {
        instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        TotalMoney = 1000;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeMoney(int amount)
    {
        TotalMoney += amount;
    }
}
