using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour {
	public float north = 0f;
	public float east = 0f;
	public float south = 0f;
	public float west = 0f;

	public void config (float n, float e, float s, float w) {
		Wall[] walls = GetComponentsInChildren<Wall> ();
		foreach (Wall wall in walls) {
			switch (wall.dir) {
			case Wall.Direction.N:
				wall.config (n);
				break;
			case Wall.Direction.E:
				wall.config (e);
				break;
			case Wall.Direction.S:
				wall.config (s);
				break;
			case Wall.Direction.W:
				wall.config (w);
				break;
			}
		}
	}

	// Use this for initialization
	void Start () {
		config (north, east, south, west);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
