using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

    public float range; // ate aonde vai o tiro
    public float fireRate; // velocidade do tiro
    public float damage;
    public float minDamage;
    public float maxDamage;
    public Sprite icon;
    public GameObject weaponPrefab;
    GameObject player;
    private void Start()
    {
        damage = Random.Range(minDamage, maxDamage);
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player" && other.gameObject.GetComponent<PlayerMovement>().isItem)
        {
            PickUpItem();
        }
    }

    void OnMouseDown()
    {

        this.GetComponent<BoxCollider>().enabled = true;
    }

    void PickUpItem()
    {
        
       // weaponPrefab.GetComponentInChildren<WeaponInHand>().damage = damage;
        //add item to inventory
        bool wasPickedUp = Inventory.instance.Add(weaponPrefab);

        if (wasPickedUp)
        {
            player.GetComponent<Animator>().SetTrigger("PickItem");
            Destroy(gameObject, 1);
        }
        

    }

    public virtual void Use()
    {
        Debug.Log("usando item");
    }
}
