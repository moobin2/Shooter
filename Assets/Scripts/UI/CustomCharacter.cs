using UnityEngine;
using System.Collections;

public class CustomCharacter : MonoBehaviour {

    private GameObject BaseManCharacter;
    private GameObject BaseWomanCharacter;
    private int Character_Hair_Number = 0;
    private int Character_Cloth_Number = 0;

    // Use this for initialization
    void Start ()
    {
        BaseManCharacter = this.transform.FindChild("BaseMan").gameObject;
        BaseManCharacter.SetActive(true);

        BaseWomanCharacter = this.transform.FindChild("BaseWoman").gameObject;
        BaseWomanCharacter.SetActive(false);

        
    }
	
	// Update is called once per frame
	void Update ()
    {
	    if(Input.GetKeyDown(KeyCode.A))
        {
            BaseManCharacter.SetActive(true);
            BaseWomanCharacter.SetActive(false);
        }
        else if(Input.GetKeyDown(KeyCode.D))
        {
            BaseManCharacter.SetActive(false);
            BaseWomanCharacter.SetActive(true);
        }
	}
}
