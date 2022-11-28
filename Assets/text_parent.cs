using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class text_parent : MonoBehaviour
{
    // Start is called before the first frame update
    private Component[] di, rect, textmesh;
    void Start()
    {
        rect = this.GetComponentsInChildren( typeof(RectTransform), true );
        di = this.GetComponentsInChildren( typeof(text), true );
        textmesh = this.GetComponentsInChildren( typeof(TextMeshProUGUI), true );
        rectplace();
    }

    public void rectplace(){
        float posx=0f;
        foreach (RectTransform tr in rect){
            if (posx!=0)    tr.anchoredPosition3D= new Vector3(posx,0f,0f);
            posx++;
        }
    }

    public void dialog()
    {
        StartCoroutine(printdialog());
    }

    IEnumerator printdialog(){
        foreach (text text in di){　
            text.isActive = true;
            while(text.isActive)    yield return null;
        };
    }

    public void fadeout(){
        StartCoroutine(fade());
    }
    
    IEnumerator fade(){
        foreach (TextMeshProUGUI text in textmesh){
            while (text.color.a>0f){
                    text.color=GameObject.Find("timemanagement").GetComponent<fade>().fadeout(1f,text.color);
                    yield return null;
            }
        }
    }
}
