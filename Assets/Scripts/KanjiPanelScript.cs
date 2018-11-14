using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KanjiPanelScript : MonoBehaviour
{

    public ParticleSystem kanjiPanelParticle;
    public bool isStepped;
    Text text;
    Text kanjiText;

	private void Start()
	{
        text = gameObject.transform.Find("Canvas").Find("Text").GetComponent<Text>();
        kanjiText = GameObject.Find("KanjiText").GetComponent<Text>();
        if (text.text == "")
        {
            text.text += JapaneseCharacterList.getRamdomCharacter();
        }
       

    }

	private IEnumerator PlayParticle()
    {
        Instantiate(kanjiPanelParticle, transform.position, transform.rotation);
        yield return new WaitForSeconds(5f);
        Destroy(kanjiPanelParticle);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isStepped == true){
            return;
        }
        if (other.gameObject.name == "Senser")
        {
            gameObject.GetComponent<Renderer>().material.color = Color.green;
            isStepped = true;
            GameObject.Find("Controller (right)").GetComponent<HandController>().Add(gameObject);

            //if (kanjiText.text == "")
            //{
            //    kanjiText.text += text.text;
            //    return;
            //}
            kanjiText.text += text.text;
        }
    }

}
