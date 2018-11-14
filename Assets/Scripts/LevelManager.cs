
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public struct Sentence
{
    public string japanese;
    public string english;
}

public class LevelManager : MonoBehaviour
{

    public List<Sentence> sentences = new List<Sentence>();

}
