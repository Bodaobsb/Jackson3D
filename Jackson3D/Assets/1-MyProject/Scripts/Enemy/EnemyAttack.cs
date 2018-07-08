using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

    public float attackRate;
    public int attackDamage;

    Animator anim;
    GameObject player;
    PlayerHealth _playerHealth;
    EnemyHealth _enemyHealth;
    EnemyMovement _enemyMovement;
    public bool playerInRange;
    float timer;
    public GameObject _collider;

	// Use this for initialization
	void Start () {
        _enemyMovement = GetComponent<EnemyMovement>();
        _enemyHealth = GetComponent<EnemyHealth>();
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
        _playerHealth = player.GetComponent<PlayerHealth>();

	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;

        if (_enemyMovement.dis < 2)
        {
            playerInRange = true;
        }
        if (_enemyMovement.dis > 2)
        {
            playerInRange = false;
        }
        if (timer>=attackRate && playerInRange && _enemyHealth.currentHealth > 0)
        {
            StartCoroutine(Attack());
        }

        if (_playerHealth.currentHealth <= 0)
        {
            anim.SetTrigger("PlayerDead");
        }
	}
    /*
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject == player)
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInRange = false;
        }
    }
    */
    void Attack1()
    {
        timer = 0;

        if (_playerHealth.currentHealth > 0)
        {
            _collider.SetActive(true);
            anim.SetTrigger("Attack");
           
        }
    }

    IEnumerator Attack()
    {

        timer = 0;

        if (_playerHealth.currentHealth > 0)
        {
            

            anim.SetTrigger("Attack");
            yield return new WaitForSeconds(0.25f);
            _collider.SetActive(true);

        }
        yield return new WaitForSeconds(0.6f);
        _collider.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _playerHealth.TakeDamage(attackDamage);
        }
    }

}
