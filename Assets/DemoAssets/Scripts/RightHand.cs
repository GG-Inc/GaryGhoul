using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;

public class RightHand : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.localPosition = InputTracking.GetLocalPosition (VRNode.RightHand);
		transform.localRotation = InputTracking.GetLocalRotation (VRNode.RightHand);
	}
}
