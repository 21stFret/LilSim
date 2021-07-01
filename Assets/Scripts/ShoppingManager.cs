using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoppingManager : MonoBehaviour
{
    public int TotalCost;
    public List<ItemT> ShoppingCart;
    public string ShoppingTalk;

    public static ShoppingManager instance;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CalculateTotalCost()
    {
        TotalCost = 0;
        foreach(ItemT i in ShoppingCart)
        {
            TotalCost += i.Cost;
        }
    }

    public void AddToShoppingCart(ItemT item)
    {
        if (!ShoppingCart.Contains(item))
        {
            ShoppingCart.Add(item);
            CalculateTotalCost();
            SetShoppingTalk();
        }

    }

    public void RemoveFromShoppingCart(ItemT item)
    {
        ShoppingCart.Remove(item);
        print("removed" + item.name);
        CalculateTotalCost();
        SetShoppingTalk();
    }

    public void ClearCart()
    {
        ShoppingCart.Clear();
        CalculateTotalCost();
    }

    public void PurchaseCart()
    {
        if(TotalCost<MoneyManager.instance.TotalMoney)
        {
            MoneyManager.instance.ChangeMoney(-TotalCost);
            foreach (ItemT i in ShoppingCart)
            {
                InventoryManager.instance.AddToInv(i);
            }
            ClearCart();
        }
        else { print(" Not enough money"); }

    }

    public void SetShoppingTalk()
    {
        ShoppingTalk = "Okay, the " + ShoppingCart[0].m_name;
        for (int i = 1; i < ShoppingCart.Count; i++)
        {
            ShoppingTalk += " and the " + ShoppingCart[i].m_name;
        }
        ShoppingTalk += " comes to " + TotalCost.ToString() + ".";
    }
}
