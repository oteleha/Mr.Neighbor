﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextImporterScript : MonoBehaviour {

	public TextAsset textFile;
	public string[] textLines;

	void Start () {
	
		if(textFile != null){

			textLines = (textFile.text.Split ('\n'));
		}		
	}
}