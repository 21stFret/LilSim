using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DynamicLayerOrder : MonoBehaviour
{

    public Transform Target;
    SpriteRenderer m_SP;
    TilemapRenderer m_TP;
    public float  TargetYTrigger;
    public int BaseOrder, MaxOrder;
    bool Tilemap;
    // Start is called before the first frame update
    void Start()
    {
        m_SP = GetComponent<SpriteRenderer>();
        if(m_SP == null)
        {
            m_TP = GetComponent<TilemapRenderer>();
            Tilemap = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Tilemap) { TmDLO(); }
        else { DLO(); }
    }

    void DLO()
    {
        if(Target.position.y > TargetYTrigger)
        {
            m_SP.sortingOrder= MaxOrder;
        }
        else
        {
            m_SP.sortingOrder = BaseOrder;
        }
    }
    void TmDLO()
    {
        if (Target.position.y > TargetYTrigger)
        {
            m_TP.sortingOrder = MaxOrder;
        }
        else
        {
            m_TP.sortingOrder = BaseOrder;
        }
    }
}
