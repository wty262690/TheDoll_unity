using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camercontrl : MonoBehaviour
{
    Vector3 pos;//=  new Vector3(29.2999992f, 6.5f, 3.0f);
    Vector3 rot;//=  new Vector3(2.277f, -94.318f, -0.873f);
    float move=0.1f;
    float posmove = 0.01f;
    // Start is called before the first frame update
    void Start()
    {
        pos= this.transform.position;
        rot= new Vector3 (transform.rotation.x,transform.rotation.y,transform.rotation.z);
        //gameObject.transform.rotation=
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow)){
            rot.y-=move;
            //pos.z+=posmove;
        }
        else if(Input.GetKey(KeyCode.LeftArrow)){
            rot.y+=move;
            //pos.z-=posmove;
        }
        else if(Input.GetKey(KeyCode.UpArrow)){
            rot.x-=move;
        }
        else if(Input.GetKey(KeyCode.DownArrow)){
            rot.x+=move;
        }
        else if(Input.GetKey(KeyCode.W)){
            rot.z+=move;
        }
        else if(Input.GetKey(KeyCode.S)){
            rot.z-=move;
        }
        gameObject.transform.rotation = Quaternion.Euler(rot.x, rot.y, rot.z);
        gameObject.transform.position = pos;
    }
}

