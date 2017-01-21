using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public float            UI_ObjectRotSpeed = 100f;

    public GameObject       Character;
    public GameObject       HairPosition;

    private GameObject[]    UI_HairResources;
    private GameObject      UI_HairObject;

    private GameObject      Char_HairObject;

    private int UI_HairNumber = 7;
    private bool IsMan = true;

    // Use this for initialization
    void Start()
    {
        UI_HairResources = Resources.LoadAll<GameObject>("Hair");

        CreateUIHairObject();
    }

    // Update is called once per frame
    void Update()
    {
        UI_HairObject.transform.Rotate(Vector3.up * Time.deltaTime * UI_ObjectRotSpeed, Space.World);
    }

    void CreateUIHairObject()
    {
        if (UI_HairObject != null)
        {
            Destroy(UI_HairObject);
        }

        UI_HairObject = Instantiate(UI_HairResources[UI_HairNumber]) as GameObject;
        UI_HairObject.transform.localScale = Vector3.one * 0.4f;
        UI_HairObject.transform.parent = transform.FindChild("Hair").transform;
        UI_HairObject.transform.localPosition = Vector3.zero;
        UI_HairObject.layer = 5;


        CharacterAddObject(HairPosition, UI_HairObject);

    }

    public void SelectMan(Material FirstMaterial)
    {
        if (IsMan == true) return;

        IsMan = true;
        UI_HairNumber = 7;
        Character.transform.FindChild("Base").GetComponent<SkinnedMeshRenderer>().material = FirstMaterial;

        CreateUIHairObject();
    }

    public void SelectWoman(Material FirstMaterial)
    {
        if (IsMan == false) return;

        IsMan = false;
        UI_HairNumber = 0;
        Character.transform.FindChild("Base").GetComponent<SkinnedMeshRenderer>().material = FirstMaterial;

        CreateUIHairObject();
    }

    public void IncreaseHairNumber()
    {
        UI_HairNumber++;

        if(IsMan == true && UI_HairNumber >= UI_HairResources.Length)
        {
            UI_HairNumber = 7;
        }
        else if(IsMan == false && UI_HairNumber >= 7)
        {
            UI_HairNumber = 0;
        }
        CreateUIHairObject();
    }

    public void DecreaseHairNumber()
    {
        UI_HairNumber--;

        if (IsMan == true && UI_HairNumber < 7)
        {
            UI_HairNumber = UI_HairResources.Length - 1;
        }
        else if (IsMan == false && UI_HairNumber < 0)
        {
            UI_HairNumber = 6;
        }
        CreateUIHairObject();
    }

    void CharacterAddObject(GameObject Position, GameObject AddObject)
    {
        if (Char_HairObject != null)
        {
            Destroy(Char_HairObject);
        }

        Char_HairObject = Instantiate(AddObject) as GameObject;
        Char_HairObject.transform.localScale = Vector3.one;
        Char_HairObject.transform.parent = Position.transform;
        Char_HairObject.transform.localPosition = Vector3.zero;
        Char_HairObject.transform.localRotation = Quaternion.Euler(-90.0f, 0f, 0f);
        Char_HairObject.layer = 0;
    }

    public void ChangeClothMaterial(Material ManClothes, Material WomanClothes)
    {
        if (IsMan == true)
        {
            Character.transform.FindChild("Base").GetComponent<SkinnedMeshRenderer>().material = ManClothes;
        }
        else
        {
            Character.transform.FindChild("Base").GetComponent<SkinnedMeshRenderer>().material = WomanClothes;
        }
    }
}
