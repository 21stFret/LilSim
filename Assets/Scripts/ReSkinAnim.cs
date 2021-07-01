using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class ReSkinAnim : MonoBehaviour
{

    public string spriteSheetName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(spriteSheetName == "")
        {

        }
        else
        {
            var subsprites = Resources.LoadAll<Sprite>("Characters/" + spriteSheetName);

            foreach (var renderer in GetComponentsInChildren<SpriteRenderer>())
            {
                string spriteName = renderer.sprite.name;
                var newSprite = Array.Find(subsprites, item => item.name == spriteName);

                if (newSprite)
                {
                    renderer.sprite = newSprite;
                }
            }
        }

    }
}
