using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	public float camDistance;
	public float lerpDistance;
	public float idkWhatThisDoes;
	public float numerator;

	private DialogueTextBox dialogueScript;

	public GameObject player;
	public Vector3 originalCameraPosition;

	public Transform originalCameraPositionGO;

	private float startTime;

	private Vector3 dialoguePosition;
	private Vector3 mousePos;
	private Quaternion dialogueRotation;
	private Quaternion originalRotation;

	void Start(){

		dialogueScript = GameObject.Find ("NeighborPrefab").GetComponent<DialogueTextBox> ();


		originalRotation.eulerAngles = new Vector3 (41f, 0, 0);
		originalCameraPosition = originalCameraPositionGO.position;		 
	}

	void Update(){
		
		originalCameraPosition = originalCameraPositionGO.position;
		Vector3 pos = player.transform.position;
		pos.y = player.transform.position.y + 5.0f;
		pos.z += camDistance;
		transform.position = pos;

		//MoveCamera ();

	}

	void OnTriggerEnter(Collider other){
		
		startTime = Time.time;

	}

	void MoveCamera(){

		if(dialogueScript.inTrigger == true){ 
			
			dialoguePosition = GameObject.FindGameObjectWithTag ("DialoguePosition").transform.position;
			dialoguePosition.y = dialoguePosition.y - 1.5f;
			dialogueRotation.eulerAngles = new Vector3(25, 0, 0);

			numerator = (Time.time - startTime) * 3f;
			lerpDistance = Vector3.Distance (originalCameraPosition, dialoguePosition);
			idkWhatThisDoes = numerator / lerpDistance;

			transform.rotation = Quaternion.Lerp(originalRotation, dialogueRotation, idkWhatThisDoes);
			transform.position = Vector3.Lerp(originalCameraPosition, dialoguePosition, idkWhatThisDoes);
			//transform.rotation = dialogueRotation;
			//transform.position = dialoguePosition;
		}

		if(dialogueScript.inTrigger == false){

			transform.position = originalCameraPosition;
			transform.rotation = originalRotation;
			startTime = Time.time;//this fixed it!!!
		}
	}
}