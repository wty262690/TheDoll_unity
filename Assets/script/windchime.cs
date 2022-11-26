using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class windchime : MonoBehaviour
{
    public float speed;
    public Rigidbody rb;
    public float delay;
    private float count,de;
    private GameObject angle;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(GameObject.Find("Obj_000019"));
        angle= GameObject.Find("1-wind chime");
        count=0;
        de=1;
        rb = GameObject.Find("Wind chimes 1").GetComponent<Rigidbody>();
        rb.AddTorque(transform.up * speed);
    }

    // Update is called once per frame
    void Update()
    {
        count += Time.deltaTime * de;
        
        angle.transform.Rotate( 0, -0.4f, 0 );

        if (count>delay){
            rb.AddTorque(transform.up * (speed/10));
            de *= -1;
            count = delay;
            //print("hi");
            //Random.Range(-10.0f, 10.0f)
        }
        else if (count<0){
            //rb.AddTorque(transform.up * -speed);
            de *= -1;
            //print("ww");
            count = 0;
            //transform.Rotate( 0, speed, 0 );
        }
    }

    public void start(){
        StartCoroutine(startanimate());
    }

    public IEnumerator startanimate(){
        this.GetComponent<Rigidbody>().velocity = new Vector3(0, -10, 0);
        rb.velocity = new Vector3(0, -10, 0);
        yield return new WaitForSeconds(0.1f);
        this.GetComponent<Rigidbody>().velocity = new Vector3(0, 10, 0);
        rb.velocity = new Vector3(0, 10, 0);
        while (transform.position.y < 20){
            yield return null;
            print(transform.position.y);
        }
        Destroy(gameObject);
    }
}
