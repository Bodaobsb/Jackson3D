using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour {
    public float startingHealth;
    public float currentHealth;
    public float sinkSpeed;

    bool isDead;
    bool isSinking;

    Animator anim;
    ParticleSystem hitParticles;
    CapsuleCollider _collider;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        hitParticles = GetComponentInChildren<ParticleSystem>();
        _collider = GetComponent<CapsuleCollider>();

        currentHealth = startingHealth;

    }
	
	// Update is called once per frame
	void Update () {
        if (isSinking)
        {
            transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime);
        }
	}

    public void TakeDamage(float amount, Vector3 hitPoint)
    {
        if (isDead)
        {
            return;
        }
        if (currentHealth >1)
        {
            anim.SetTrigger("TakeDamage");
        }
        
        currentHealth -= amount;
        hitParticles.transform.position = hitPoint;
        hitParticles.Play();

        if (currentHealth <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        this.GetComponent<EnemyMovement>().enabled = false;
        isDead = true;
        _collider.isTrigger = true;
        anim.SetTrigger("Dead");
        this.GetComponent<EnemyDrop>().Drop();
        Destroy(gameObject,2f);

    }

    // animacao de morte
    public void StartSinking()
    {
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        isSinking = true;
        Destroy(gameObject, .2f);

        // TODO enemy pooling
    }


}
