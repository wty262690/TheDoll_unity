using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class menuanimation : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject door, butt, windchime;
    private music musicplay;
    private Image image;
    private text text, subtext;
    private TextMeshProUGUI titletext, starttext, subtitletext;
    private Button button;
    private bool enter=true;
    void Start()
    {
        musicplay= GameObject.Find("Audio Source").GetComponent<music>();
        windchime= GameObject.Find("Wind chimes");
        door= GameObject.Find("1-1");
        image = GameObject.Find("Image").GetComponent<Image>();
        titletext = GameObject.Find("title").GetComponent<TextMeshProUGUI>();
        subtext = GameObject.Find("title/sub title").GetComponent<text>();
        subtitletext = GameObject.Find("title/sub title").GetComponent<TextMeshProUGUI>();
        text = GameObject.Find("title").GetComponent<text>();
        starttext = GameObject.Find("Button/start").GetComponent<TextMeshProUGUI>();
        butt=GameObject.Find("Button");
        button = butt.GetComponent<Button>();
        button.enabled = false;
        //musicplay.Fadein();
    }
    void Update()
    {
        if (enter){
            StartCoroutine(windowFadein());
            enter=false;
        }        
    }
    
    public void start(){
        musicplay.oneshot(0);
        StartCoroutine(windowFadeout());
    }

    IEnumerator windowFadein(){
        //yield return new WaitForSeconds(1f);
        while(image.color.a>0f){
                image.color=this.GetComponent<fade>().fadeout(1f,image.color);
                yield return 0;
        }
        StartCoroutine(anima());
    }
    IEnumerator anima(){
        while(door. GetComponent<SpriteRenderer>().color.a<1f){
                door. GetComponent<SpriteRenderer>().color=this.GetComponent<fade>().fadein(7f,door. GetComponent<SpriteRenderer>().color);
                yield return new WaitForSeconds(0.05f);
        }
        text.isActive=true;
        while(text.isActive == true){
            yield return 0;
        }
        subtext.isActive=true;
        while(text.isActive == true){
            yield return 0;
        }
        yield return new WaitForSeconds(0.1f);
        while(starttext.color.a<1f){
                starttext.color=this.GetComponent<fade>().fadein(3f,starttext.color);
                yield return new WaitForSeconds(0.01f);
        }
        button.enabled = true;
    }

    IEnumerator windowFadeout(){
        windchime.GetComponent<windchime>().start();
        while(starttext.color.a>0f){
                titletext.color=this.GetComponent<fade>().fadeout(1f,titletext.color);
                subtitletext.color=this.GetComponent<fade>().fadeout(1f,subtitletext.color);
                starttext.color=this.GetComponent<fade>().fadeout(1f,starttext.color);
                yield return new WaitForSeconds(0.01f);
        }
        yield return new WaitForSeconds(0.1f);
        musicplay.Fadeout();
        while(musicplay.fading) yield return null;
        Application.LoadLevel("1");

    }

}
