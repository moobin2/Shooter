using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

    public float TimeBetweenArrows = 0.15f;

    int             ShootableMask;
    float           Timer;
    float           EffectsDisplayTime = 0.2f;
    Ray             ShootRay;
    RaycastHit      ShootHit;
    Light           ArrowLight;
    Animator        PlayerAnimator;
    AudioSource     ArrowAudio;
    LineRenderer    ArrowLine;
    ParticleSystem  ArrowParticle;

    void Awake()
    {
        ShootableMask = LayerMask.GetMask("Shootable");
        PlayerAnimator = GetComponent<Animator>();
        ArrowParticle = GetComponent<ParticleSystem>();
        ArrowLine = GetComponent<LineRenderer>();
        ArrowAudio = GetComponent<AudioSource>();
        ArrowLight = GetComponent<Light>();
    }

    void Update()
    {
        Timer += Time.deltaTime;

        // 마우스 왼클릭 && 발사가능시간됬을때
        if (Input.GetButton("Fire1") && Timer >= TimeBetweenArrows)
        {
            Shoot();
        }

        ////
        //if (Timer >= TimeBetweenArrows * EffectsDisplayTime)
        //{
        //    DisableEffects();
        //}
    }

    public void DisableEffects()
    {
        // Disable the line renderer and the light.
        ArrowLine.enabled = false;
        ArrowLight.enabled = false;
    }

    void Shoot()
    {
        // Reset the Timer.
        Timer = 0f;

        // Play the gun shot audioclip.
        ArrowAudio.Play();

        // Enable the light.
        ArrowLight.enabled = true;

        // Stop the particles from playing if they were, then start the particles.
        ArrowParticle.Stop();
        ArrowParticle.Play();

        // Enable the line renderer and set it's first position to be the end of the gun.
        ArrowLine.enabled = true;
        ArrowLine.SetPosition(0, transform.position);

        // Set the ShootRay so that it starts at the end of the gun and points forward from the barrel.
        ShootRay.origin = transform.position;
        ShootRay.direction = transform.forward;

        // Perform the raycast against gameobjects on the shootable layer and if it hits something...
        //if (Physics.Raycast(ShootRay, out ShootHit, Range, ShootableMask))
        //{
        //    //// Try and find an EnemyHealth script on the gameobject hit.
        //    //EnemyHealth enemyHealth = ShootHit.collider.GetComponent<EnemyHealth>();

        //    //// If the EnemyHealth component exist...
        //    //if (enemyHealth != null)
        //    //{
        //    //    // ... the enemy should take damage.
        //    //    enemyHealth.TakeDamage(damagePerShot, ShootHit.point);
        //    //}

        //    //// Set the second position of the line renderer to the point the raycast hit.
        //    //ArrowLine.SetPosition(1, ShootHit.point);
        //}
        //// If the raycast didn't hit anything on the shootable layer...
        //else
        //{
        //    // ... set the second position of the line renderer to the fullest extent of the gun's Range.
        //    ArrowLine.SetPosition(1, ShootRay.origin + ShootRay.direction * Range);
        //}
    }
}
