using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

    public  float       TimeBetweenArrows = 0.15f;
    public  Arrow       ArrowObject;
    public  Transform   ArrowFirePos;

    private int         ShootableMask;
    private bool        IsFireArrow = false;
    private Animator    PlayerAnimator;
   // private float       EffectsDisplayTime = 0.2f;

  //  Ray             ShootRay;
  //  RaycastHit      ShootHit;
  //  Light           ArrowLight;
  //  AudioSource     ArrowAudio;
  //  LineRenderer    ArrowLine;
  //  ParticleSystem  ArrowParticle;

    void Awake()
    {
        PlayerAnimator = GetComponent<Animator>();

        // ShootableMask = LayerMask.GetMask("Shootable");
        // ArrowParticle = GetComponent<ParticleSystem>();
        // ArrowLine = GetComponent<LineRenderer>();
        // ArrowAudio = GetComponent<AudioSource>();
        // ArrowLight = GetComponent<Light>();
    }

    void Update()
    {
        // 마우스 왼클릭 && 발사가능시간됬을때
        if (Input.GetMouseButtonDown(0))
        {
            // 구르기가 아닐때
            if(PlayerAnimator.GetBool("IsRolling") == false)
            {
                PlayerAnimator.SetBool("IsShoot", true);
            }
        }
    }

    public void ShootStart()
    {
        Instantiate(ArrowObject, ArrowFirePos.position, ArrowFirePos.rotation);
    }

    public void ShootEnd()
    {
        PlayerAnimator.SetBool("IsShoot", false);
    }
}
