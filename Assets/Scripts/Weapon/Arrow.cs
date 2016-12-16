using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour {

    public float Damege = 20.0f;
    public float Speed = 10.0f;

    float Range = 100.0f;

	// Use this for initialization
	void Start ()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * Speed);
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void ArrowMove()
    {

    }
}
