using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

    public float timer;
    Ray shootRay;
    RaycastHit shootHit;
    int shootableMask;
    ParticleSystem gunParticles;
    LineRenderer gunLine;
    Light gunLight;
    WeaponInHand weapon;
    float effectsDisplayTime = .2f;
    //public Animator anim;
	// Use this for initialization
	void Start () {
        
        weapon = GetComponent<WeaponInHand>();
        shootableMask = LayerMask.GetMask("Enemy");
        gunParticles = GetComponent<ParticleSystem>();
        gunLight = GetComponent<Light>();
        gunLine = GetComponent<LineRenderer>();

	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;


        

        

        if (timer >= weapon.fireRate * effectsDisplayTime)
        {
            DisableEffects();
        }
	}

    public void DisableEffects()
    {
        
        gunLine.enabled = false;
        gunLight.enabled = false;

    }

   public void Shoot()
    {
        
        timer = 0;
        gunLight.enabled = true;
        gunParticles.Stop();
        gunParticles.Play();

        gunLine.enabled = true;
        gunLine.SetPosition(0, transform.position);

        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;

        if (Physics.Raycast (shootRay,out shootHit,weapon.range,shootableMask))
        {
            EnemyHealth enemyHealth = shootHit.collider.GetComponent<EnemyHealth>();
            if (enemyHealth != null && enemyHealth.currentHealth>0)
            {
                enemyHealth.TakeDamage(weapon.damage, shootHit.point);
            }
            gunLine.SetPosition(1, shootHit.point);
        }
        else
        {
            gunLine.SetPosition(1, shootRay.origin + shootRay.direction * weapon.range);

        }
    }
}
