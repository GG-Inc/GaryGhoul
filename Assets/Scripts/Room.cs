using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour {
	public float north = 0f;
	public float east = 0f;
	public float south = 0f;
	public float west = 0f;
	private Vector3 NORTH_POS = new Vector3(-2.5f,0f,2.5f);

	enum Direction {
		N = 0,
		E = 90,
		S = 180,
		W = 270
	}

	public void config (float n, float e, float s, float w) {
		KeyValuePair<Direction, float>[] directions = {
			new KeyValuePair<Direction, float>( Direction.N, n ),
			new KeyValuePair<Direction, float>( Direction.E, e ),
			new KeyValuePair<Direction, float>( Direction.S, s ),
			new KeyValuePair<Direction, float>( Direction.W, w )
		};

		foreach (KeyValuePair<Direction, float> dir in directions) {
			GameObject child = new GameObject ();
			positionChild (child.transform, dir.Key);
			Wall wall = child.AddComponent<Wall> ();
			wall.config (dir.Value);

		}
	}

	// Use this for initialization
	void Start () {
		config (north, east, south, west);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void positionChild(Transform tr, Direction dir){
		tr.SetParent(transform,false);
		tr.localPosition = NORTH_POS;
		tr.localScale = new Vector3 (0.5f, -1, 0.25f);
		tr.Rotate(90, 0, 0);
		tr.RotateAround (transform.position, Vector3.up, (float) dir);
	}
}
