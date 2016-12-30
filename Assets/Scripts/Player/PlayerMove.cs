using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

    public  float       speed = 6.0f;
    private float       rollingH;
    private float       rollingV;
    private Vector3     playerToMouse;
    private Vector3     movement;
    private Animator    PlayerAnimator;
    private Rigidbody   playerRigid;
    private int         floorMask;
    private float       camRayLength = 100.0f;

    void Awake()
    {
        PlayerAnimator = GetComponent<Animator>();
        playerRigid = GetComponent<Rigidbody>();
        floorMask = LayerMask.GetMask("Floor");
    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal"); // -1 , 0 , 1 값만 가짐.
        float v = Input.GetAxisRaw("Vertical");

        if (PlayerAnimator.GetBool("IsRolling") == false)
        {
            Move(h, v);
            Turning();
            PlayerAnimatorating(h, v);
        }
        else
        {
            RollingMove();
        }

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
            playerToMouse = floorHit.point - transform.position;
            playerToMouse.y = 0.0f;

            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
            playerRigid.MoveRotation(newRotation);
        }
    }

    void PlayerAnimatorating(float h, float v)
    {
        bool run = h != 0.0f || v != 0.0f;
        PlayerAnimator.SetBool("IsRunning", run);

        if (Input.GetMouseButtonDown(1))
        {
            PlayerAnimator.SetBool("IsRolling", true);
        }
    }

    public void RollingEnd()
    {
        PlayerAnimator.SetBool("IsRolling", false);
        speed = 6.0f;
    }

    void RollingMove()
    {
        Vector3 playerDirection = playerToMouse.normalized;
        playerDirection *= speed * Time.deltaTime;

        speed -= 0.05f;

        playerRigid.MovePosition(transform.position + playerDirection);
    }
}
