using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandController : MonoBehaviour {

    private Stack<GameObject> kanjiPanelStack;
    private SteamVR_TrackedController device;
    Text userText;
    GameObject kanjiPanel;

	// Use this for initialization
	void Start () {
        device = GetComponent<SteamVR_TrackedController>();
        device.TriggerClicked += Delete;
        userText = GameObject.Find("KanjiText").GetComponent<Text>();
        kanjiPanelStack = new Stack<GameObject>();
    }


    void Delete(object sender, ClickedEventArgs e)
    {
        if (userText.text.Length > 0)
        {
            userText.text = userText.text.Remove(userText.text.Length - 1);
            Remove();
        }
    }
            
    public void Add(GameObject kanjiPanel)
    {
        kanjiPanelStack.Push(kanjiPanel);
    }

    void Remove()
    {
        kanjiPanel = kanjiPanelStack.Pop();
        kanjiPanel.GetComponent<Renderer>().material.color = Color.white;
        kanjiPanel.GetComponent<KanjiPanelScript>().isStepped = false;
    }

}
