using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class kanjiPanelGenerator : MonoBehaviour {
    
    public GameObject kanjiPanelPrefab;
    string japaneseSentence;
    string englishSentence;
    public GameObject normalPanelPrefab;
    List<List<GameObject>> network;
    LevelManager levelManager;
    string answer;

	// Use this for initialization
	void Start () {
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        int randomNum = Random.Range(0, levelManager.sentences.Count);
        japaneseSentence = levelManager.sentences[randomNum].japanese;
        answer = japaneseSentence;
        englishSentence = levelManager.sentences[randomNum].english;
        levelManager.sentences.RemoveAt(randomNum);
        transform.parent.Find("Gate").Find("WoodenBoard").Find("Canvas").Find("Text").GetComponent<Text>().text = "Make a sentence for \"" + englishSentence + "\"";
        GenerateKanjiPanel();
        AddPath();
	}

    public string GetAnswer()
    {
        return answer;
    }

    public string GetSentence()
    {
        return japaneseSentence;
    }

    void GenerateKanjiPanel()
    {
        GameObject gm;
        int numColumn = 5;
        int numRow = 5;
        network = new List<List<GameObject>>();
        if (transform.rotation == Quaternion.identity)
        {
            for (int z = 0; z < numColumn; z++)
            {
                network.Add(new List<GameObject>());
                for (int x = 0; x < numRow; x++)
                {
                    gm = Instantiate(kanjiPanelPrefab, new Vector3(transform.position.x + 15 * x, transform.position.y, transform.position.z - 15 * z), Quaternion.identity, transform);
                    network[z].Add(gm);
                }
            }
            if (japaneseSentence.Length % 2 == 1)
            {
                Instantiate(normalPanelPrefab, new Vector3(transform.position.x + 30, transform.position.y, transform.position.z - 75), Quaternion.identity, transform);
            }
            else
            {
                gm = Instantiate(kanjiPanelPrefab, new Vector3(transform.position.x + 30, transform.position.y, transform.position.z - 75), Quaternion.identity, transform);
                gm.transform.Find("Canvas").Find("Text").GetComponent<Text>().text = "" + japaneseSentence[0];
                japaneseSentence = japaneseSentence.Remove(0, 1);
            }
        }
        else
        {
            for (int z = 0; z < numColumn; z++)
            {
                network.Add(new List<GameObject>());
                for (int x = 0; x < numRow; x++)
                {
                    gm = Instantiate(kanjiPanelPrefab, new Vector3(transform.position.x - 15 * x, transform.position.y, transform.position.z + 15 * z), transform.rotation, transform);
                    network[z].Add(gm);
                }
            }
            if (japaneseSentence.Length % 2 == 1)
            {
                Instantiate(normalPanelPrefab, new Vector3(transform.position.x - 30, transform.position.y, transform.position.z + 75), transform.rotation, transform);
            }
            else
            {
                gm = Instantiate(kanjiPanelPrefab, new Vector3(transform.position.x - 30, transform.position.y, transform.position.z + 75), transform.rotation, transform);
                gm.transform.Find("Canvas").Find("Text").GetComponent<Text>().text = "" + japaneseSentence[0];
                japaneseSentence = japaneseSentence.Remove(0, 1);
            }
        }
        

    }

    void AddPath()
    {
        Stack<Node> path;
        Position position;
        path = GameObject.Find("NetworkManager").GetComponent<NetworkManager>().FindAPath(japaneseSentence.Length + 2);
        int i = japaneseSentence.Length - 1;
        while (path.Count > 0)
        {
            position = path.Pop().position;
            network[position.y][position.x].transform.Find("Canvas").Find("Text").GetComponent<Text>().text = "" + japaneseSentence[i];
            i--;
        }

    }
}
