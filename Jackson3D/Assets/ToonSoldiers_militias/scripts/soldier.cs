using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soldier : MonoBehaviour {

	public Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey("1"))
		{
			anim.Play("infantry_combat_run_left",-1,0f);
		}
	}
}
