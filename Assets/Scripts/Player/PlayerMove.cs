using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

    public float speed = 6.0f;
    private Vector3 movement;
    private Animator anim;
    private Rigidbody playerRigid;
    private int floorMask;
    float camRayLength = 100.0f;

    void Awake()
    {
        anim = GetComponent<Animator>();
        playerRigid = GetComponent<Rigidbody>();
        floorMask = LayerMask.GetMask("Floor");
    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal"); // -1 , 0 , 1 값만 가짐.
        float v = Input.GetAxisRaw("Vertical");

        Move(h, v);
        Turning();
        Animating(h, v);
    }

    void Move(float h, float v)
    {
        movement.Set(h, 0, v);
        movement = movement.normalized * speed * Time.deltaTime;

        playerRigid.MovePosition(transform.position + movement);
    }

    void Turning()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit floorHit;

        if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
        {
            Vector3 playerToMouse = floorHit.point - transform.position;
            playerToMouse.y = 0.0f;

            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
            playerRigid.MoveRotation(newRotation);
        }
    }

    void Animating(float h, float v)
    {
        bool run = h != 0.0f || v != 0.0f;
        anim.SetBool("IsRun", run);
    }
}
