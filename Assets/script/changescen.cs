using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changescen : MonoBehaviour
{
    public string scence;
    public bool changescence;
    // Start is called before the first frame update
    void Start()
    {
        scence="menu";
        changescence=false;
    }

    // Update is called once per frame
    void Update()
    {
        if (changescence){
            Application.LoadLevel(scence);
        }
    }
}
