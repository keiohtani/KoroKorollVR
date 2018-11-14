using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockDoor : MonoBehaviour {
    public bool isPasscodeProtected;
    public GameObject lockedDoor;
    public string answer;
    Text userText;


	private void Start()
	{
        userText = GameObject.Find("KanjiText").GetComponent<Text>();
        if (isPasscodeProtected)
            answer = transform.parent.parent.Find("KanjiPanelGenerator").GetComponent<kanjiPanelGenerator>().GetAnswer();
    }

	private void OnTriggerEnter(Collider other)
	{
        if (other.gameObject.name == "Senser")
        {
            if (!isPasscodeProtected)
                lockedDoor.GetComponent<Animator>().SetBool("IsUnlocked", true);
            else
            {
                if (userText.text == answer)
                {
                    userText.text = "";
                    lockedDoor.GetComponent<Animator>().SetBool("IsUnlocked", true);
                }
            }
            
        }
	}

}
