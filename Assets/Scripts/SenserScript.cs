using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SenserScript : MonoBehaviour {

    public Transform characterTF;
    public Transform playAreaTF;

    private Vector3 characterTFPosition;
    
    // Update is called once per frame
    void Update () {
        characterTFPosition = characterTF.position;
        transform.position = new Vector3 (characterTFPosition.x, playAreaTF.position.y, characterTFPosition.z);
        transform.eulerAngles = new Vector3(0, characterTF.rotation.eulerAngles.y + 90, 0);
    }
}
