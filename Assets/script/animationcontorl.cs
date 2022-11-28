using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 1
0: door
1: floor
2: doll on floor
3: doll with mrs - body
4: doll with mrs - clockwork
5: mrs
6: boss
7  - 11: background effect
12 - 13: dialog
*/
/* 2
1: boss
2: mrs
*/

public class animationcontorl : MonoBehaviour
{
    private music musicplay;
    public List<GameObject> goList;
    public int finish=0;
    
    // Start is called before the first frame update
    void Start()
    {
            musicplay= GameObject.Find("Audio Source").GetComponent<music>();
            goList= new List<GameObject>();   
    }

    void Update(){
        switch (finish)
        {
            case -1: break;
            case 0: 
                print(finish);
                StartCoroutine(anima());
                finish=-1;
                break;
            case 1: 
                print(finish);
                StartCoroutine(anima2());
                finish=-1;
                break;
            default:
                break;
        }
    }

    // Update is called once per frame
    IEnumerator anima()
    {
        musicplay.Fadein();
        finish=-1;
        listUPdate(1,1,14);
        float timer=0f, seconds = 0.5f; //Vector3(-4.69999981,4.21999979,-3.6500001)
        Vector3 currentVelocity = Vector3.zero;;
        while (timer <= seconds+1) {
                timer += Time.deltaTime;
                goList[0].transform.position = Vector3.SmoothDamp(goList[0].transform.position, new Vector3(-1.85f,3.4f,-2.8f), ref currentVelocity,seconds);
                yield return new WaitForSeconds(0.01f);
        }
        StartCoroutine(backanima());
        GameObject.Find("text1").GetComponent<text_parent>().dialog();
        while(goList[1]. GetComponent<SpriteRenderer>().color.a<1f){
            for (int i=1; i<=4; i++){
            goList[i]. GetComponent<SpriteRenderer>().color=this.GetComponent<fade>().fadein(1f,goList[i]. GetComponent<SpriteRenderer>().color);
            }
            yield return new WaitForSeconds(0.01f);
        }
        while(goList[5]. GetComponent<SpriteRenderer>().color.a<1f){
            goList[5]. GetComponent<SpriteRenderer>().color=this.GetComponent<fade>().fadein(2f,goList[5]. GetComponent<SpriteRenderer>().color);
            yield return new WaitForSeconds(0.01f);
        }
        while(goList[6]. GetComponent<SpriteRenderer>().color.a<1f){
            goList[6]. GetComponent<SpriteRenderer>().color=this.GetComponent<fade>().fadein(2f,goList[6]. GetComponent<SpriteRenderer>().color);
            yield return new WaitForSeconds(0.01f);
        }
        GameObject.Find("text2").GetComponent<text_parent>().dialog();
        yield return new WaitForSeconds(1f);

    }
    IEnumerator backanima(){
        yield return new WaitForSeconds(1);
        for (int i=7; i<=11; i++){
            while(goList[i]. GetComponent<SpriteRenderer>().color.a<1f){
                goList[i]. GetComponent<SpriteRenderer>().color=this.GetComponent<fade>().fadein(10f/i,goList[i]. GetComponent<SpriteRenderer>().color);
                yield return new WaitForSeconds(0f);
            }
        }
        for (int i=12; i<=13; i++){
            while(goList[i]. GetComponent<SpriteRenderer>().color.a<1f){
                goList[i]. GetComponent<SpriteRenderer>().color=this.GetComponent<fade>().fadein(10f/i,goList[i]. GetComponent<SpriteRenderer>().color);
                yield return new WaitForSeconds(0f);
            }
        }

        /*---   fade out    ---*/
        while(goList[11]. GetComponent<SpriteRenderer>().color.a>0f){
            for (int i=7; i<=11; i++){
                goList[i]. GetComponent<SpriteRenderer>().color=this.GetComponent<fade>().fadeout(3f,goList[i]. GetComponent<SpriteRenderer>().color);
                yield return new WaitForSeconds(0.01f);
            }
        }
        GameObject.Find("text1").GetComponent<text_parent>().fadeout();
        GameObject.Find("text2").GetComponent<text_parent>().fadeout();
        while(goList[13]. GetComponent<SpriteRenderer>().color.a>0f){
            int[] delete = {0,5,6,12,13};
            for (int i=0; i<5; i++){
                goList[delete[i]]. GetComponent<SpriteRenderer>().color=this.GetComponent<fade>().fadeout(3f,goList[delete[i]]. GetComponent<SpriteRenderer>().color);
                yield return new WaitForSeconds(0.01f);
            }
        }
        while(goList[3]. GetComponent<SpriteRenderer>().color.a>0f){
            int[] delete = {1,2,3};
            for (int i=0; i<3; i++){
                goList[delete[i]]. GetComponent<SpriteRenderer>().color=this.GetComponent<fade>().fadeout(3f,goList[delete[i]]. GetComponent<SpriteRenderer>().color);
                yield return new WaitForSeconds(0.01f);
            }
        }
        finish=1;
    }



    IEnumerator anima2(){
        finish=-1;
        listUPdate(2,1,2);
        for (int i=0; i<=1; i++){
            while(goList[i]. GetComponent<SpriteRenderer>().color.a<1f){
                goList[i]. GetComponent<SpriteRenderer>().color=this.GetComponent<fade>().fadein(10f/i,goList[i]. GetComponent<SpriteRenderer>().color);
                yield return new WaitForSeconds(0.1f);
            }
        }
        yield return new WaitForSeconds(0.1f);
    }

    void listUPdate(int index, int from, int to){
        goList.Clear();
        for (int i=from; i<=to; i++){
            goList.Add(GameObject.Find(index+"-"+i));
        }
    }
}
