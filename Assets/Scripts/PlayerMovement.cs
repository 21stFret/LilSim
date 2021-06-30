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

    public bool Interactable, ItemHeld;
    public GameObject HoverItem, InteractItem;

    // Start is called before the first frame update
    void Start()
    {
        m_RB = GetComponent<Rigidbody2D>();
        m_Anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            GetInput();
        }
        else
        {
            Direction = Vector2.zero;
        }
        if(Interactable)
        {
            PickupItem();
        }


        if (ItemHeld)
        {
            InteractItem.transform.position = m_IT.transform.position;
        }


        m_Anim.SetFloat("MoveY",m_RB.velocity.y);
        m_Anim.SetFloat("MoveX", m_RB.velocity.x);
        m_Anim.SetFloat("LastMoveY", LastDirection.y);
        m_Anim.SetFloat("LastMoveX", LastDirection.x);
        m_Anim.SetFloat("Move",m_RB.velocity.magnitude);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move(Direction);
    }

    void PickupItem()
    {
        if (Input.GetKeyDown("e"))
        {
            if(ItemHeld)
            {
                print("dropped item");
                ItemHeld = false;
                InteractItem = null;
            }
            else
            {
                print("picked up item");
                InteractItem = HoverItem;
                ItemHeld = true;
                InteractItem.GetComponent<Item>().ShowUI(false);
            }
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
