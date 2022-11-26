using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class text_parent : MonoBehaviour
{
    // Start is called before the first frame update
    private Component[] di;
    void Start()
    {
        di = this.GetComponentsInChildren( typeof(text), true );
        float posx=0f;
        foreach (RectTransform tr in di){
            //RectTransform tr = i.GetComponent<RectTransform>();
            tr.position= new Vector3(posx,0f,0f);
            posx++;
        }
    }

    // Update is called once per frame
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
}
