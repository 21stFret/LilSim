using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D m_RB;
    public int MoveSpeed;
    Vector2 Direction;
    public Vector2 LastDirection;
    Animator m_Anim;
    public InteractionTrigger m_IT;

    public bool Interactable, ItemHeld, HeldCondition;
    public bool Talkable;
    public Item InteractItem, HoverItem;
    public NPC npc;

    public bool Paused;

    // Start is called before the first frame update
    void Start()
    {
        m_RB = GetComponent<Rigidbody2D>();
        m_Anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if(!Paused)
        {
            if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
            {
                GetInput();
            }
            else
            {
                Direction = Vector2.zero;
            }
            if (Interactable)
            {
                ChangeItem();
            }
            if (Talkable && !Interactable)
            {
                OpenTalk();
            }
            PickupItem();

        }


        m_Anim.SetFloat("MoveY",m_RB.velocity.y);
        m_Anim.SetFloat("MoveX", m_RB.velocity.x);
        m_Anim.SetFloat("LastMoveY", LastDirection.y);
        m_Anim.SetFloat("LastMoveX", LastDirection.x);
        m_Anim.SetFloat("Move",m_RB.velocity.magnitude);
    }

    public void PauseGame(bool On)
    {
        if(On) { Time.timeScale = 0;}
        else { Time.timeScale = 1; }
        Paused = On;
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        Move(Direction);
    }

    void OpenTalk()
    {
        if (Input.GetKeyDown("e"))
        {
            TalkManager TM = TalkManager.instance;
            if (ShoppingManager.instance.TotalCost>0)
            {
                TM.SetTalkPanel(true);
                TM.SetTalkText(ShoppingManager.instance.ShoppingTalk, npc.Name);
            }
            else
            {
                TM.SetTalkPanel(true);
                TM.SetTalkText(npc.Talk, npc.Name);
            }
        }
    }

    void PickupItem()
    {

        if (Input.GetKeyDown("e"))
        {
            if(ItemHeld)
            {
                print("dropped item");
                ItemHeld = false;
                InteractItem.transform.SetParent(null,true);
                InteractItem.gameObject.layer = LayerMask.NameToLayer("Items");
                InteractItem = null;

            }
            else
            {
                print("picked up item");
                InteractItem = HoverItem;
                ItemHeld = true;
                InteractItem.gameObject.layer = LayerMask.NameToLayer("Interacted");
                InteractItem.transform.SetParent(m_IT.transform);
                InteractItem.transform.localPosition = new Vector3(-0.00200000009f, -0.0979999974f, 0);
                InteractItem.ShowUI(false);
            }
        }   
    }

    void ChangeItem()
    {
        if (Input.GetKeyDown("q"))
        {
            if (HoverItem.CustItem)
            {
                HoverItem.GetComponent<CutsomItem>().ChangeVariant();
            }
            else { print("Error not a customizable item"); }
        }
    }

    void GetInput()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        Direction = new Vector2(moveX, moveY).normalized;
        if (Direction!=Vector2.zero)
        {
            LastDirection.x = Input.GetAxisRaw("Horizontal");
            LastDirection.y = Input.GetAxisRaw("Vertical");
        }
    }

    public void Move(Vector3 direction)
    {
        m_RB.AddForce(direction * MoveSpeed);
    }
}
