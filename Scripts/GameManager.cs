using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public int numCollectables;

	private bool giftCollected;

	private CharacterMovement characterScript;


	void Start () {

		characterScript = GameObject.FindGameObjectWithTag ("Player").GetComponent<CharacterMovement> ();
	}

	void Update () {

		//GiftRecieved ();

	}

//	void GiftRecieved(){
//		
//		if(characterScript.gifted == true){
//
//			giftCollected = true;
//		}
//	}
}