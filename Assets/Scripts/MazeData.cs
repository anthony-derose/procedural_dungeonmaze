using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeData 
{
   public float emptySpace; 

   public MazeData(){
       emptySpace = .1f; 
   }

   public int [,] FromDimensions(int rows, int cols){
        
        int[,] maze = new int[rows, cols];

        int rowmax = maze.GetUpperBound(0);
        int colmax = maze.GetUpperBound(1);

        for (int i = 0; i <= rowmax; i++){
            for (int j = 0; j <= colmax; j++){
                if (i == 0 || j == 0 || i == rowmax || j == colmax){
                    maze[i, j] = 1;
                }
                else if (i % 2 == 0 && j % 2 == 0){
                    if (Random.value > emptySpace)
                    {
                        maze[i, j] = 1;
                        int a = Random.value < .5 ? 0 : (Random.value < .5 ? -1 : 1);
                        int b = a != 0 ? 0 : (Random.value < .5 ? -1 : 1);
                        maze[i+a, j+b] = 1;
                    }
                }
            }
        }       
        return maze;     
   }
}
