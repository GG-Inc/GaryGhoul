using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject ghost = Instantiate (Resources.Load ("Models/ghost_01", typeof(GameObject))) as GameObject;
		ghost.transform.SetParent (this.transform, false);
		ghost.transform.localScale = new Vector3 (0.15f, 0.15f, 0.15f);
		ghost.transform.Rotate(new Vector3(0, 90, 0));
		this.transform.localPosition = new Vector3 (20, 20, .5f);
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 currentPos = this.transform.localPosition;
		Vector3 playerPos = GameObject.Find ("VRCamera").transform.position;

		playerPos.y = currentPos.y;



		this.transform.LookAt (playerPos);

		currentPos.y = Mathf.Sin (Time.time*1.5f) / 4 + 0.75f;
		this.transform.Rotate (new Vector3 (0, Mathf.Sin (Time.time + 270), 0) * 10);

		Vector3 towardPlayer = Vector3.zero;
		if (Vector3.Distance (this.transform.position, playerPos) >= 1f) {
			towardPlayer = this.transform.forward;
			towardPlayer.y = 0;
			towardPlayer.Normalize ();
		}

		currentPos += towardPlayer * Time.deltaTime * .75f;

		this.transform.localPosition = currentPos;

	}
}
