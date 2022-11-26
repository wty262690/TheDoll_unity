using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class menubuttonmanagement : MonoBehaviour
{
    private menuanimation animation;
    void Start()
    {
        animation= GameObject.Find("timemanagement").GetComponent<menuanimation>();
    }

    public void start(){
        animation.start();
    } 
}
