using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationaryNeighbor : MonoBehaviour {

	public DialogueTextBox dialogueScript;
	public Transform player;
	public int giftsRecieved;


	void Start () {

		dialogueScript = GetComponent<DialogueTextBox> ();
		player = GameObject.FindGameObjectWithTag ("Player").transform;

	}

	void Update () {

		if(dialogueScript.inTrigger == true){
			
			Vector3 relativePos = player.position - transform.position;
			Quaternion rotation = Quaternion.LookRotation (relativePos);
			transform.rotation = rotation;

		}
	}

	void LetsBeFriends(){


	}
}