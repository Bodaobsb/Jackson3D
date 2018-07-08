using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWeapon : MonoBehaviour {

    public List<GameObject> armas = new List<GameObject>();
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            for (int i = 0; i < armas.Count; i++)
            {
                if (armas[i].activeInHierarchy)
                {
                    armas[i].SetActive(false);
                    if (i == armas.Count - 1)
                    {
                        armas[0].SetActive(true);
                    }
                    else
                    {
                        armas[i + 1].SetActive(true);
                    }

                    break;
                }
            }

        }
    }
}
