using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class weapon : MonoBehaviour {
	
		[SerializeField]
		public GameObject Ak47;
		[SerializeField]
		public GameObject Fal;	
		public GameObject Glock;


		public bool showAk47;
		public bool showFal;
		public bool showGlock;

		public bool IsGun = false;
		public bool hasWeapon;

		public bool hasAk = false;
		public bool hasFal = false;
		public bool hasGlock = false;

		public Animator anim;


	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		showAk47 = false;
		showFal = false;
		showGlock = false;

	}
	
	// Update is called once per frame
	void Update () 
	{

		anim.SetBool("Rifle", hasWeapon);
		anim.SetBool("Gun", IsGun);

		if (showAk47 == false){
		
			Ak47.SetActive(false);
		}

		if (showAk47 == true){	
		
			Ak47.SetActive(true);

		}
		if (showFal == false){
		
			Fal.SetActive(false);
		}
		
		if (showFal == true){	
	
			Fal.SetActive(true);

		}

		if (showGlock == false){
		
			Glock.SetActive(false);
		}
		
		if (showGlock == true){	
	
			Glock.SetActive(true);

		}

		






		if (Input.GetKeyDown(KeyCode.P) & showAk47 == false & hasAk == true){
			showAk47 = true;
			showFal = false;
			showGlock = false;
			//anim.S
			IsGun = false;
			hasWeapon = true;
			anim.SetBool("Gun", false);
			anim.SetBool("Rifle",true);
		}

		if (Input.GetKeyDown(KeyCode.O) & showFal == false & hasFal == true){
			showAk47 = false;
			showFal = true;
			showGlock = false;
			IsGun = false;
			hasWeapon = true;
			anim.SetBool("Gun", false);
			anim.SetBool("Rifle",true);
			
		}


		if (Input.GetKeyDown(KeyCode.I) & showGlock == false){
			showAk47 = false;
			showFal = false;
			showGlock = true;

			IsGun = true;
			hasWeapon = true;
			anim.SetBool("Gun", true);
			anim.SetBool("Rifle",false);
		}

		if (Input.GetKey(KeyCode.U)){
			showAk47 = false;
			showFal = false;
			showGlock = false;
			IsGun = false;
			hasWeapon = false;
			anim.SetBool("Gun", false);
			anim.SetBool("Rifle",false);

		}

		if (Input.GetMouseButton (0) & showAk47 == true & hasAk == true) {

			anim.Play (("infantry_combat_shoot_burst"), -1, 0f);
		}

		if (Input.GetMouseButton (0) & showGlock == true) {

			anim.Play (("handgun_combat_shoot_burst"), -1, 0f);
		}
		
	}

	void OnTriggerEnter(Collider col){
	
		if (col.tag == "Ak") {
			hasAk = true;
			Destroy (col.gameObject);

		}
		if (col.tag == "Fal") {
			hasFal = true;
			Destroy (col.gameObject);

		}
		if (col.tag == "Arma") {
			hasGlock = true;
			Destroy (col.gameObject);

		}



		//if (col.tag == "Fal") {
		//	Destroy (col.gameObject);

		//	hasFal = true;
		//}

	}	
}
