using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;

public class RapidMotion : MonoBehaviour {

	void Start () {
		foreach (string joy in Input.GetJoystickNames()) {
			Debug.Log (joy);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if( Input.GetKeyDown("joystick button 8") )
		{
			Manager.Instance.speed += Input.GetAxis ("Vertical");
		}

		float speed = Manager.Instance.speed;
		transform.position = Vector3.Scale(InputTracking.GetLocalPosition (VRNode.Head), new Vector3(speed,0, speed));
	}
}
