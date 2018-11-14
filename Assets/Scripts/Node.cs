
using System.Collections.Generic;
using UnityEngine;

public class Node{

    public string color;
    public Dictionary<string, Node> dicNode;
    public Position position;
    public int minNum;
    public int maxNum;


    public Node(int x, int y)
    {
        color = "white";
        dicNode = new Dictionary<string, Node>();
        position = new Position(x, y);
        maxNum = 0;
        minNum = 0;

        if (x == 2)
        {
            maxNum += 5 * y + 1;
            minNum += 1 + y;
        }
        else if (x == 1 || x == 3)
        {
            maxNum += 5 * y + 2;
            minNum += 2 + y;
        }
        else
        {
            maxNum += 5 * y + 3;
            minNum += 3 + y;
        }
        if (y == 4)
        {
            if (x == 2)
                maxNum = 5 * y + 1;
            else if (x == 1 || x == 3)
                maxNum = 5 * y;
            else
                maxNum = 5 * y - 1;
        }

    }

    public void AddNode(string key, Node node)
    {
        dicNode.Add(key, node);
    }

    public override string ToString(){
        return "(" + position.x + ", " + position.y + ")";
    }

    public void PrintNodeList()
    {
        Debug.Log("Current node: " + this);
        string strStream = "";
        foreach (string key in dicNode.Keys)
        {
            strStream += dicNode[key];
        }
        Debug.Log(strStream);
    }

    //public void SetColor(string color)
    //{
    //    this.color = color;
    //}

    //public bool IsAllNonWhite()
    //{
    //    foreach(Node node in dicNode)
    //    {
    //        if (node.color == "white")
    //            return false;
    //    }
    //    return true;
    //}

    //public Node GetWhiteNode()
    //{
    //    List<Node> lsWhiteNode = new List<Node>();
    //    foreach(Node node in dicNode)
    //    {
    //        if (node.color == "white")
    //            lsWhiteNode.Add(node);
    //    }
    //    int randomNum;
    //    System.Random random = new System.Random();

    //    randomNum = random.Next(lsWhiteNode.Count);
    //    return lsWhiteNode[randomNum];
    //}

}
