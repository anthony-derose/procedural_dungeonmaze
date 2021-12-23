using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeConstructor : MonoBehaviour
{
    [SerializeField] private Material matrix1;
    [SerializeField] private Material matrix2;
    [SerializeField] private Material start;
    [SerializeField] private Material treasure;
    private MazeMeshGen meshGenerator = null;


    private MazeData mazeData;

    public int [,] data {
        get; private set;
    }

    void Awake(){
        meshGenerator = new MazeMeshGen();

        // this is an empty cell 
        data = new int[,]
        {
            {1,1,1},
            {1,0,1},
            {1,1,1},
        };

        mazeData = new MazeData();
    }

    void OnGUI(){

        int[,] m = data;
        int rowMax = m.GetUpperBound(0);
        int colMax = m.GetUpperBound(1);  

        string info = ""; 

        for(int i = rowMax; i >= 0; i--){
            for(int j = 0; j <= colMax; j++){
                if (m[i, j] == 0)
                {
                    info += "....";
                }
                else
                {
                   info += "==";
                }
            }
            info += "\n";
        }
        Debug.Log(info); 
    }

    private void DisplayMaze(){
        GameObject go = new GameObject();
        go.transform.position = Vector3.zero;
        go.name = "Procedural Maze";
        go.tag = "Gen";

        MeshFilter mf = go.AddComponent<MeshFilter>();
        mf.mesh = meshGenerator.FromData(data);
    
        MeshCollider mc = go.AddComponent<MeshCollider>();
        mc.sharedMesh = mf.mesh;

        MeshRenderer mr = go.AddComponent<MeshRenderer>();
        mr.materials = new Material[2] {matrix1, matrix2};
    }
    public void GenerateNewMaze(int rows, int cols){
        if (rows % 2 == 0 && cols % 2 == 0)
        {
        Debug.LogError("Odd numbers work better for dungeon size.");
        }

        data = mazeData.FromDimensions(rows, cols);

        DisplayMaze();
    }
}
