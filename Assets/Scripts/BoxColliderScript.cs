using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxColliderScript : MonoBehaviour {
    BoxCollider thisCollider;
    public Transform eyeTF;
	// Use this for initialization
	void Start () {
        thisCollider = this.gameObject.GetComponent<BoxCollider>();
	}
	
	// Update is called once per frame
	void Update () {

        thisCollider.center = new Vector3(eyeTF.localPosition.x ,thisCollider.center.y, eyeTF.localPosition.z);
	}
}
