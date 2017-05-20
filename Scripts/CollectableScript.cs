using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableScript : MonoBehaviour {

	public GameManager managerScript;
	
	void Start () {

		managerScript = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameManager>();
	}

	void OnTriggerEnter(Collider other){

		if(other.gameObject.tag == "Player"){

			this.gameObject.SetActive (false);
			managerScript.numCollectables++;
		}
	}
}