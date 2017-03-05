using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
	public float north = 0f;
	public float east = 0f;
	public float south = 0f;
	public float west = 0f;

	private Vector3[] POSITIONS = {
		new Vector3 (-2.5f, 0f, 2.5f),
		new Vector3 (-2.5f, 0f, -2.5f),
		new Vector3 (-2.5f, 0f, -2.5f),
		new Vector3 (2.5f, 0f, -2.5f)
	};

	private Vector3 TWO_D_SCALE = new Vector3 (0.5f, 0, 0.25f);

	enum Direction
	{
		N=0,
		E,
		S,
		W
	}

	public void config (float n, float e, float s, float w)
	{
		KeyValuePair<Direction, float>[] directions = {
			new KeyValuePair<Direction, float> (Direction.N, n),
			new KeyValuePair<Direction, float> (Direction.E, e),
			new KeyValuePair<Direction, float> (Direction.S, s),
			new KeyValuePair<Direction, float> (Direction.W, w)
		};
		createWalls (directions);
		createStaticSurfaces ();
	}

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	private void createStaticSurfaces ()
	{
		GameObject floor = GameObject.CreatePrimitive (PrimitiveType.Plane);
		floor.name = "Floor";
		floor.transform.SetParent (transform, false);
		floor.transform.localScale = Vector3.one * 0.5f;

		GameObject ceiling = GameObject.CreatePrimitive (PrimitiveType.Plane);
		ceiling.name = "Ceiling";
		ceiling.transform.SetParent (transform, false);
		ceiling.transform.localScale = (Vector3.one * 0.5f) - Vector3.up;
		ceiling.transform.localPosition = Vector3.up * 2.5f;
		ceiling.GetComponent<Renderer> ().material = Utils.loadResource<Material> ("Materials/Ceiling");

		Light light = new GameObject("Light").AddComponent<Light> ();
		light.color = new Color (0.4f, 0.4f, .6f);
		light.intensity = 0.8f;
		light.transform.SetParent (transform, false);
	}

	private void createWalls (KeyValuePair<Direction, float>[] directions)
	{
		foreach (KeyValuePair<Direction, float> dir in directions) {
			GameObject child = new GameObject (dir.Key.ToString () + " Wall");
			setTransformByDir (child.transform, dir.Key);
			Wall wall = child.AddComponent<Wall> ();
			wall.config (dir.Value);
		}
	}
	private void setTransformByDir(Transform tr, Direction dir)
	{
		tr.SetParent (transform, false);
		tr.Rotate (90, 0, (1 == (int)dir % 2 ? 90 : 0));
		tr.localPosition = POSITIONS [(int)dir];
		tr.localScale = TWO_D_SCALE + (Vector3.up * ( Direction.E < dir ? 1 : -1)); 
	}
}
