using UnityEngine;
using System.Collections;

public class HairSelect : MonoBehaviour {

    private GameObject[]    UI_HairObject;
    private int             UI_HairNumber = 0;

    // Use this for initialization
    void Start()
    {
        UI_HairObject = Resources.LoadAll<GameObject>("ManHair");

        Debug.Log(UI_HairObject.Length);
	}
	
	// Update is called once per frame
	void Update ()
    {
        Instantiate(UI_HairObject[UI_HairNumber], Vector3.zero, Quaternion.identity);
	}
}
