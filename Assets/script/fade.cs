using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fade : MonoBehaviour
{
    SpriteRenderer m_SpriteRenderer;
    //Color NewColor;
    //public float speed=0.1f;
    // Start is called before the first frame update
    void Start ()
    {
        //m_SpriteRenderer= GetComponent<SpriteRenderer>();
        //NewColor = new Color(255f,255f,255f,0f); //讓圖片一開始為透明
    }

    public Color fadein(float speed, Color NewColor)
    {
        if(NewColor.a < 1f)
            {
                NewColor.a = NewColor.a + Time.deltaTime * speed; //讓圖片隨時間變不透明
            }
        //m_SpriteRenderer.color= NewColor;
        return NewColor;
    }

    public Color fadeout(float speed, Color NewColor)
    {
        if(NewColor.a > 0f)
            {
                NewColor.a = NewColor.a - Time.deltaTime * speed; //讓圖片隨時間變不透明
            }
        return NewColor;
    }
}
