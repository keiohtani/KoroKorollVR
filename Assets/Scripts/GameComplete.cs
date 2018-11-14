using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameComplete : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Senser")
        {
            GameObject.Find("KanjiText").GetComponent<Text>().text = "Congratulations! You completed the game!";
        }
    }

}
