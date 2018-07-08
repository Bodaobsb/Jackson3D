using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;
[RequireComponent(typeof(ThirdPersonCharacter))]
public class PlayerHealth : MonoBehaviour {
    bool damaged;
    bool isDead;
    public int startingHealth;
    public int currentHealth;

    Animator anim;
    PlayerMovement _playerMovement;
    public Shooting shooting;
	// Use this for initialization
	void Start () {
        
        _playerMovement = GetComponent<PlayerMovement>();
        anim = GetComponent<Animator>();
        currentHealth = startingHealth;

	}
	
	// Update is called once per frame
	void Update () {
        if (damaged)
        {
            // damageImage
        }
        else
        {
            //damageImage
        }
        damaged = false;
	}

    public void TakeDamage(int amout)
    {
        if (currentHealth>1 )
        {
            anim.SetTrigger("TakeDamage");
        }
        
        damaged = true;
        currentHealth -= amout;

        if (currentHealth <= 0 && !isDead)
        {
            Death();
        }
    }


    void Death()
    {
        _playerMovement.enabled = false;
        this.GetComponent<ThirdPersonCharacter>().enabled = false;
        anim.SetTrigger("Die");
        //shooting.DisableEffects();
        
        shooting.enabled = false;
        isDead = true;
        
        
    }
    
}
