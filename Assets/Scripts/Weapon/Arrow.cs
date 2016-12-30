using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class Arrow : MonoBehaviour {

    public  float   Damege = 20.0f;
    public  float   Speed = 100.0f;
    public  float   Range = 100.0f;
    private Vector3 FirstPos;


	// Use this for initialization
	void Start ()
    {
        FirstPos = transform.position;
        GetComponent<Rigidbody>().AddForce(transform.forward * Speed);
	}
	
	// Update is called once per frame
	void Update ()
    {
        Range -= Vector3.Magnitude(FirstPos - transform.position);
        FirstPos = transform.position;

        if(Range < 0)
        {
            Destroy(this.gameObject);
        }
     //   if(Vector3.Magnitude(FirstPos - transform.position) > Range)
     //   {
     //       Destroy(this.gameObject);
     //   }
    }
}
