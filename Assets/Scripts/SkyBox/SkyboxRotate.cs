using UnityEngine;
using System.Collections;

public class SkyboxRotate : MonoBehaviour {

    public float RotateSpeed = 1.0f;

    // Update is called once per frame
    void Update () {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * RotateSpeed);
    }
}
