using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour {

    private CapsuleCollider coll;
    private AudioSource swordHitSound;

	// Use this for initialization
	void Start () {
        coll = GetComponent<CapsuleCollider>();
        swordHitSound = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton(0))
        {
            print("Left click!");
            
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        swordHitSound.Play();
        Destroy(other.gameObject);
        print("Collision!");
    }
}
