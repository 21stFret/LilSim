using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicLayerOrder : MonoBehaviour
{

    public Transform Target;
    SpriteRenderer m_SP;
    public int BaseOrder, MaxOrder, TargetYTrigger;
    // Start is called before the first frame update
    void Start()
    {
        m_SP = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        DLO();
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
}
