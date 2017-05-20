using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTextBox : MonoBehaviour {
	//This script will create a dialogue box on an NPC and the player will be able to hit a button that will continue the text into a new box

	public Text dialogue;
	public string[] dialogueTexts;
	public int currentLine;
	public int endLine;
	public bool inTrigger = false;

	public CameraMovement cameraScript;
	public TextImporterScript textScript;


	void Start () {

		dialogue = GetComponentInChildren<Text> ();
		cameraScript = GetComponent<CameraMovement> ();
		textScript = GameObject.Find ("TextImporter").GetComponent<TextImporterScript> ();

		dialogue.enabled = false;
	}

	void Update () {

		if(inTrigger == true){

			DialogueScroll ();
		}

		dialogue.text = textScript.textLines [currentLine];

	}

	void OnTriggerStay(Collider other){

		inTrigger = true;
		dialogue.enabled = true;
	}

	void OnTriggerExit(Collider other){

		inTrigger = false;
		dialogue.enabled = false;
		currentLine = 0;
	}
	void DialogueScroll(){


		if(textScript.textFile != null){
			textScript.textLines = (textScript.textFile.text.Split ('\n'));
		}

		if (endLine == 0) {

			endLine = textScript.textLines.Length - 1;
		}

		if (Input.GetKeyDown (KeyCode.LeftShift)) {

				currentLine += 1;
				dialogue.enabled = true;
		}
	}
}
