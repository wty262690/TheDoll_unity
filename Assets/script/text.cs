using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class text : MonoBehaviour
{
    public float charsPerSecond;
    public bool dialog = true;
    private string words;

    public bool isActive = false;
    private float timer;
    private TextMeshProUGUI myText;
    private int currentPos =0;

    // Start is called before the first frame update
    void Start()
    {
        timer=0;
        //charsPerSecond = Mathf.Max(0.2f,charsPerSecond);
        myText = GetComponent<TextMeshProUGUI>();
        words = myText.text;
        myText.text= "";
        dialogchange();
    }

    // Update is called once per frame
    void Update()
    {
        OnStartWriter();
    }

    public void StartEffecto(){
        isActive = true;
    }

    void OnStartWriter(){
        if(isActive){
            timer += Time.deltaTime;
            if(timer>=charsPerSecond){
                timer = 0;
                currentPos++;
                myText.text = words.Substring(0,currentPos);

                if(currentPos>=words.Length){
                    onFinish();
                }
            }
        }
    }

    void onFinish(){
        isActive = false;
        timer=0;
        currentPos = 0;
        myText.text = words;
    }

    void dialogchange(){
        string textContent=words;
        if (dialog){
            for (int i=1; i<=words.Length; i++){
                textContent = textContent.Insert(2*i-1, "\n");
            }
            words = textContent;
        }
    }
}
