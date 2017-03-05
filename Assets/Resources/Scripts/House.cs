using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour {

	// Use this for initialization
	void Start () {
		float[,,] doors = new float[5,5,2];
		for (int i = 0; i < 5; i++)
			for (int j = 0; j < 5; j++) {
				for(int k = 0; k < 2; k++){
					doors [i, j, k] = randomDoorPos();
				}
				if(0 == i || 4 == i) doors[i, j, 1] = 1;
				if(0 == j || 4 == j) doors[i, j, 0] = 1;
			}

		for (int x = 0; x < 4; x++)
			for (int y = 0; y < 4; y++) {
				Room room = new GameObject ("Room " + x + "x" + y).AddComponent<Room> ();
				room.transform.SetParent (transform, false);
				room.transform.localPosition = new Vector3 (x, 0, y) * 5;
				room.config (doors [x, y+1, 0], doors [x, y, 1],doors [x, y, 0], doors [x+1, y, 1]);
			}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private float randomDoorPos() {
		if (0.1f > Random.value) {
			return 0;
		}
		return Random.value;
	}
}
