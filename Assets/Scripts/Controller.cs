using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MazeConstructor))]  
public class Controller : MonoBehaviour
{
     private MazeConstructor gen;

    void Start()
    {
        gen = GetComponent<MazeConstructor>();      
        gen.GenerateNewMaze(13, 15);

    }
}
