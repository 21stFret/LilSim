using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsomItem : Item
{
    public string[] Names;
    public Sprite[] Variations;
    public int SelectedVariant;
    SpriteRenderer m_SR;
    public GameObject Effect;
    public ItemT itemT;

    // Start is called before the first frame update
    void Start()
    {
        CustItem = true;
        SelectedVariant = -1;
        m_SR = GetComponent<SpriteRenderer>();
        ChangeVariant();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeVariant()
    {
        SelectedVariant++;
        if (SelectedVariant == Variations.Length) { SelectedVariant = 0; }
        m_SR.sprite = Variations[SelectedVariant];
        SetItemText(Names[SelectedVariant]);
        SetItemTInfo();

        if(Effect)
        {
            if (SelectedVariant == 1)
            {
                Effect.SetActive(true);
            }
            else { Effect.SetActive(false); }
        }
    }

    void SetItemTInfo()
    {
        itemT.m_name = Names[SelectedVariant];
        itemT.m_sprite = Variations[SelectedVariant];
    }
}
