using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionTrigger : MonoBehaviour
{
    PlayerMovement m_PM;

    // Start is called before the first frame update
    void Start()
    {
        m_PM = GetComponentInParent<PlayerMovement>();
        m_PM.m_IT = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(m_PM.LastDirection.x== 1)
        {
            transform.localPosition = new Vector2(0.25f, 0);
        }
        if (m_PM.LastDirection.x == -1)
        {
            transform.localPosition = new Vector2(-0.25f, 0);
        }
        if (m_PM.LastDirection.y == 1)
        {
            transform.localPosition = new Vector2(0, 0.25f);
        }
        if (m_PM.LastDirection.y == -1)
        {
            transform.localPosition = new Vector2(0,-0.25f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Interactable"))
        {
            Item item = collision.GetComponent<Item>();
            item.ShowUI(true); ;
            m_PM.Interactable = true;
            m_PM.HoverItem = item;
        }
        if (collision.CompareTag("NPC"))
        {
            m_PM.Talkable = true;
            m_PM.npc = collision.GetComponent<NPC>();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Interactable"))
        {
            collision.GetComponent<Item>().ShowUI(false);
            m_PM.Interactable = false;
            m_PM.HoverItem = null;
        }
        if (collision.CompareTag("NPC"))
        {
            m_PM.Talkable = false;
            m_PM.npc = null;

        }

    }
}
