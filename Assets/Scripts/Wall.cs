using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {
	const float DOOR_WIDTH = 0.2f;
	const float DOOR_HEIGHT = 0.8f;

	public void config(float doorPos) {
		if (doorPos <= 0) {
			return;
		}
		if (doorPos + DOOR_WIDTH >= 1) {
			doorPos = 1;
		}
		setChildren (doorPos);
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	private void setChildren(float doorPos)
	{
		GameObject[] components = new GameObject[3];
		for (int i = 0; i < (doorPos < 1 ? 3 : 2) ; i++) {
			components [i] = GameObject.CreatePrimitive (PrimitiveType.Plane);
			components [i].transform.SetParent (this.transform, false);
		}
		components [0].transform.localScale = new Vector3 (doorPos, 1, DOOR_HEIGHT);
		components [0].transform.localPosition = new Vector3 (doorPos / 2, 0, -DOOR_HEIGHT / 2) * 10;
		components [1].transform.localScale = new Vector3 (1, 1, 1 - DOOR_HEIGHT);
		components [1].transform.localPosition = new Vector3 (.5f, 0, -(1 + DOOR_HEIGHT) / 2) * 10;
		if (doorPos < 1) {
			components [2].transform.localScale = new Vector3 (1 - (doorPos + DOOR_WIDTH), 1, DOOR_HEIGHT);
			components [2].transform.localPosition = new Vector3 ((1 + doorPos + DOOR_WIDTH) / 2, 0, -DOOR_HEIGHT / 2) * 10;
		}
	}
}
