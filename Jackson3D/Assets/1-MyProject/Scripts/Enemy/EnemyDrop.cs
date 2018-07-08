using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDrop : MonoBehaviour {

    public GameObject[] itemToDrop;
    int numRaridade;
    float minDamage;
    float maxDamage;
    float damage;
    int minChance;
    Item weapon;
    [SerializeField] int dropChance;
    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


      


    public void Drop()
    {
        int newDropChance = Random.Range(0, 10);

        if (newDropChance <= dropChance)
        {
            numRaridade = Random.Range(0, itemToDrop.Length);

            GameObject newItem = GameObject.Instantiate(itemToDrop[numRaridade], transform.position, transform.rotation);
            newItem.SetActive(true);
            
        }
            
        

    }
}
