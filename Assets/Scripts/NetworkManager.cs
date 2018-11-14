using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkManager : MonoBehaviour {
    
    List<List<Node>> network;
    public int numRow = 5;
    public int numColumn = 5;

   

    public Stack<Node> FindAPath(int characterCount)
    {
        Stack<Node> path = new Stack<Node>();
        Node goalNode = network[0][2];
        Node currentNode = network[4][2];
        string move = "";
        int randomNum;
        characterCount--;
        path.Push(currentNode);
        
        //while(characterCount > currentNode.minNum)
        while (currentNode != goalNode)
        {
            switch (currentNode.position.y)
            {
                case 0:
                    if (currentNode.position.x > 2)
                        currentNode = currentNode.dicNode["left"];
                    else
                        currentNode = currentNode.dicNode["right"];
                    
                    path.Push(currentNode);
                    
                    break;
                case 1:
                case 2:
                case 3:
                    if (currentNode.minNum >= characterCount)
                    {
                        print("minNum is" + currentNode.minNum);
                        move = "front";
                        currentNode = currentNode.dicNode[move];
                        characterCount--;
                        path.Push(currentNode);
                    }
                    else if (currentNode.maxNum <= characterCount || currentNode.dicNode["front"].maxNum <= characterCount - 1)
                    {
                        switch (currentNode.position.x)
                        {
                            case 0:
                                randomNum = Random.Range(0, 2);
                                if (randomNum == 0)
                                    move = "front";
                                else
                                    move = "right";
                                break;
                            case 1:
                            case 2:
                            case 3:
                                randomNum = Random.Range(1, 3);
                                if (move == "front")
                                {
                                    if (randomNum == 1)
                                        move = "left";
                                    else
                                        move = "right";
                                }
                                break;
                            case 4:
                                randomNum = Random.Range(0, 2);
                                if (randomNum == 0)
                                    move = "front";
                                else
                                    move = "left";
                                break;
                        }
                        while (move != "front")
                        {
                            if (!currentNode.dicNode.ContainsKey(move) || currentNode.dicNode[move].minNum >= characterCount - 1)
                            {
                                move = "front";
                                currentNode = currentNode.dicNode[move];
                                characterCount--;
                                path.Push(currentNode);
                                
                            }
                            else
                            {
                                currentNode = currentNode.dicNode[move];
                                characterCount--;
                                path.Push(currentNode);
                                
                            }
                        }
                    }
                    else
                    {
                        move = "";
                        randomNum = Random.Range(0, 3);
                        switch (randomNum)
                        {
                            case 0:
                                move = "front";
                                currentNode = currentNode.dicNode[move];
                                characterCount--;
                                path.Push(currentNode);
                                break;
                            case 1:
                                move = "left";
                                break;
                            case 2:
                                move = "right";
                                break;
                        }
                        while (move != "front")
                        {
                            if (!currentNode.dicNode.ContainsKey(move) || currentNode.minNum >= characterCount - 1)
                            {
                                move = "front";
                                currentNode = currentNode.dicNode[move];
                                characterCount--;
                                path.Push(currentNode);
                                
                            }
                            else
                            {
                                randomNum = Random.Range(0, 3);
                                if (randomNum == 0 && currentNode.maxNum <= characterCount)
                                {
                                    move = "front";
                                    currentNode = currentNode.dicNode[move];
                                    characterCount--;
                                    path.Push(currentNode);
                                    
                                }
                                else
                                {
                                    currentNode = currentNode.dicNode[move];
                                    characterCount--;
                                    path.Push(currentNode);

                                }
                            }
                        }
                    }
                    break;

                case 4:
                    if (currentNode.minNum >= characterCount)
                    {
                        move = "front";
                        currentNode = currentNode.dicNode[move];
                        characterCount--;
                        path.Push(currentNode);
                        
                    }
                    else if (currentNode.maxNum <= characterCount || currentNode.dicNode["front"].maxNum <= characterCount - 1)
                    {
                        switch (currentNode.position.x)
                        {
                            case 0:
                                move = "right";
                                break;
                            case 1:
                            case 2:
                            case 3:
                                randomNum = Random.Range(1, 3);
                                if (move == "front")
                                {
                                    if (randomNum == 1)
                                        move = "left";
                                    else
                                        move = "right";
                                }
                                else
                                {
                                    move = "right";
                                }
                                break;
                            case 4:
                                move = "left";
                                break;
                        }
                        while (move != "front")
                        {
                            if (!currentNode.dicNode.ContainsKey(move) || currentNode.dicNode[move].minNum >= characterCount - 1)
                            {
                                move = "front";
                                currentNode = currentNode.dicNode[move];
                                characterCount--;
                                path.Push(currentNode);
                                
                            }
                            else
                            {
                                currentNode = currentNode.dicNode[move];
                                characterCount--;
                                path.Push(currentNode);
                                
                            }
                        }
                    }
                    else
                    {
                        randomNum = Random.Range(0, 3);
                        switch (randomNum)
                        {
                            case 0:
                                move = "front";
                                currentNode = currentNode.dicNode[move];
                                characterCount--;
                                path.Push(currentNode);

                                break;
                            case 1:
                                move = "left";
                                break;
                            case 2:
                                move = "right";
                                break;
                        }
                        while (move != "front")
                        {
                            randomNum = Random.Range(0, 3);
                            if (!currentNode.dicNode.ContainsKey(move) || currentNode.minNum >= characterCount)
                            {
                                move = "front";
                                currentNode = currentNode.dicNode[move];
                                characterCount--;
                                path.Push(currentNode);
                                
                            }
                            else
                            {
                                if (randomNum == 0 && currentNode.maxNum <= characterCount)
                                {
                                    move = "front";
                                    currentNode = currentNode.dicNode[move];
                                    characterCount--;
                                    path.Push(currentNode);
                                    
                                }
                                else
                                {
                                    currentNode = currentNode.dicNode[move];
                                    characterCount--;
                                    path.Push(currentNode);
                                    
                                }
                            }
                        }
                    }
                    break;
            }

        }
        return path;
    }

    void Start()
    {
        CreateNetwork();
        ConnectNetwork();
        //PrintPath();
        //PrintNetwork();
    }

    void PrintPath(List<Node> path)
    {
        print("The path is ");
        foreach (Node node in path)
        {
            print(node);
        }
        print("The stepcount is " + path.Count);
    }

    void CreateNetwork()
    {
        network = new List<List<Node>>();
        for (int y = 0; y < numColumn; y++)
        {
            network.Add(new List<Node>());
            for (int x = 0; x < numRow; x++)
            {
                network[y].Add(new Node(x, y));
            }
        }
    }

    void ConnectNetwork()
    {
        for (int y = 0; y < numColumn; y++)
        {
            for (int x = 0; x < numRow; x++)
            {
                if (x != 0)     //left col
                    network[y][x].AddNode("left", network[y][x - 1]);   // adding left node
                if (x != numColumn - 1)     //right col
                    network[y][x].AddNode("right", network[y][x + 1]);   // adding right node
                if (y != 0)     // top row
                    network[y][x].AddNode("front", network[y - 1][x]);   // adding top node
                if (y != numRow - 1)    // bottom
                    network[y][x].AddNode("back", network[y + 1][x]);   // adding bottom node
            }
        }
    }

    void PrintNetwork()
    {
        for (int y = 0; y < network.Count; y++)
        {
            string strStream = "";
            for (int x = 0; x < network[y].Count; x++)
            {
                strStream += network[y][x];
                //network[y][x].PrintNodeList();
                print("minNum: " + network[y][x].minNum + ", maxNum: " + network[y][x].maxNum);
            }
            //print(strStream);
        }    
    }

}