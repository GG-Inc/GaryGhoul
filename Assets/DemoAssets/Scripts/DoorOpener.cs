using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class DoorOpener : MonoBehaviour {

	public SteamVR_PlayArea playArea;
	public GameObject player;

	void openDoor () {
		Vector3 playerPos = player.transform.position;
		Bounds bounds = playArea.GetComponent<MeshRenderer> ().bounds;
		float[] diffs = {
			playerPos [0] - bounds.min [0],
			playerPos [2] - bounds.min [2],
			bounds.max [0] + playerPos [0],
			bounds.max [2] + playerPos [2]
		};
		int nMin = 0;
		float min = diffs [0];
		for (int i = 1; i < 4; i++) {
			if (diffs [i] < min) {
				min = diffs [i];
				nMin = i;
			}
		}

		Vector3 dir;
		switch (nMin) {
		case 0:
			dir = Vector3.left;
			break;
		case 1:
			dir = Vector3.back;
			break;
		case 2:
			dir = Vector3.right;
			break;
		case 3:
			dir = Vector3.forward;
			break;
		default:
			dir = Vector3.zero;
			break;
		}
		transform.position += Vector3.Scale (dir, bounds.size);
		player.transform.Rotate (0, 180, 0);
		playArea.transform.localScale = Vector3.Scale (playArea.transform.localScale, (nMin % 2 == 0 ? Vector3.left : Vector3.back));
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown ("joystick button 14")) {
			openDoor ();
		}
		
	}
}
