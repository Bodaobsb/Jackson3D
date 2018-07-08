using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<PlayerHealth>().TakeDamage(this.GetComponentInParent<EnemyAttack>().attackDamage);
        }
    }
}
