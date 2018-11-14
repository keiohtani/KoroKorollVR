using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorButton : MonoBehaviour {

    GameObject elevator;

	// Use this for initialization
	void Start () {
        elevator = transform.parent.gameObject;
	}

	private void OnTriggerEnter(Collider other)
	{
        elevator.GetComponent<Animator>().SetBool("isTurnedOn", true);
	}

}
