using UnityEngine;
using System.Collections;

public class OriginalCameraPositionMovement : MonoBehaviour {

	public float camDistance;
	public float speed = 100f;

	public GameObject player;

	void Update(){
		
		Vector3 pos = player.transform.position;
		pos.y = player.transform.position.y + 5.0f;
		pos.z += camDistance;
		transform.position = pos;
	}
}