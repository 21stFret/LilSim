using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckoutTrigger : MonoBehaviour
{
    ShoppingManager SM;
    // Start is called before the first frame update
    void Start()
    {
        SM = ShoppingManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("hit " + collision.name);
        if(collision.CompareTag("Interactable"))
        {
            SM.AddToShoppingCart(collision.GetComponent<ItemT>());
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Interactable"))
        {
            SM.RemoveFromShoppingCart(collision.GetComponent<ItemT>());
        }
    }
}
