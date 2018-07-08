using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class weapon1 : MonoBehaviour {
	
		[SerializeField]
		public GameObject Ak47;
		[SerializeField]
		public GameObject Fal;	
		public GameObject Glock;
		[SerializeField]
		public GameObject Knife;


		public bool showAk47;
		public bool showKnife;
		public bool showFal;
		public bool showG36;
		public bool showGlock;
		 /*
		public bool show
		public bool show
		public bool show
		public bool show
		public bool show
		public bool show
		public bool show
		public bool show
		public bool show		
		public bool showGlock;
		*/



	public bool IsGun = false;
	public bool hasWeapon;
	private bool shooting;

	public bool hasAk = false;
	public bool hasFal = false;
	public bool hasGlock = false;
	public bool hasKnife = false;

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
		shooting = false;
		anim.SetBool("Rifle", hasWeapon);
		anim.SetBool("Gun", IsGun);
		anim.SetBool ("shoot", shooting);

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
		if (showKnife == false){

			Knife.SetActive(false);
		}

		if (showKnife == true){	

			Knife.SetActive(true);

		}

		






		if (Input.GetKeyDown(KeyCode.I) & showAk47 == false & hasAk == true){
			showAk47 = true;
			showFal = false;
			showGlock = false;
			showKnife = false;
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
			showKnife = false;
			IsGun = false;
			hasWeapon = true;
			anim.SetBool("Gun", false);
			anim.SetBool("Rifle",true);
			
		}


		if (Input.GetKeyDown(KeyCode.P) & showGlock == false){
			showAk47 = false;
			showFal = false;
			showGlock = true;
			showKnife = false;

			IsGun = true;
			hasWeapon = true;
			anim.SetBool("Gun", true);
			anim.SetBool("Rifle",false);
		}

		if (Input.GetKey(KeyCode.U)){
			showAk47 = false;
			showFal = false;
			showGlock = false;
			showKnife = true;
			IsGun = false;
			hasWeapon = false;
			anim.SetBool("Gun", false);
			anim.SetBool("Rifle",false);

		}

		if (Input.GetMouseButton (0) & showAk47 == true)
		 	{			//& hasAk == true & gameObject.tag == Ak47
			anim.SetBool("shoot",true);
			shooting = true;
			anim.Play (("infantry_combat_shoot_burst"), -1, 0f);
			}
		if (Input.GetMouseButton(0) & showGlock == true ){
			anim.SetBool("shoot",true);
			shooting = true;
			anim.Play (("handgun_combat_shoot_burst"), -1, 0f);
		}
		
	}

		

	void OnTriggerEnter(Collider col){
	
		if (col.tag == "Ak") {
			Destroy (col.gameObject);
			hasAk = true;

		}
		if (col.tag == "Fal") {
			Destroy (col.gameObject);
			hasFal = true;

		}

		if (col.tag == "G36") {
			Destroy (col.gameObject);



		}
		if (col.tag == "Aksu") {
			Destroy (col.gameObject);

		}
		if (col.tag == "Mac10") {
			Destroy (col.gameObject);

		}
		if (col.tag == "Mp5k") {
			Destroy (col.gameObject);

		}
		if (col.tag == "Uzi") {
			Destroy (col.gameObject);

		}
		if (col.tag == "Spas") {
			Destroy (col.gameObject);

		}
		if (col.tag == "Glock") {
			Destroy (col.gameObject);
			hasGlock = true;

		}
		if (col.tag == "Eagle") {
			Destroy (col.gameObject);

		}
		if (col.tag == "Knife") {
			Destroy (col.gameObject);
			hasKnife = true;

		}
		if (col.tag == "Svd") {
			Destroy (col.gameObject);

		}
		if (col.tag == "Ssg3000") {
			Destroy (col.gameObject);

		}
		if (col.tag == "Rpg") {
			Destroy (col.gameObject);

		}

		/*switch (col)
		{
		case (col.tag == "Rpg"):
			Destroy (col.gameObject);

			break;
		case (col.tag == "Rpg"):
			Destroy (col.gameObject);
			break;
		case (col.tag == "Rpg"):
			Destroy (col.gameObject);
			break;
		case (col.tag == "Rpg"):
			Destroy (col.gameObject);
			break;
		case (col.tag == "Rpg"):
			Destroy (col.gameObject);
			break;
		case (col.tag == "Rpg"):
			Destroy (col.gameObject);
			break;
		case (col.tag == "Rpg"):
			Destroy (col.gameObject);
			break;
		}*/
	}




		//if (col.tag == "Fal") {
		//	Destroy (col.gameObject);

		//	hasFal = true;
		//}

	}	

