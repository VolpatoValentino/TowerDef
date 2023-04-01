using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using Unity.Mathematics;

public class Grid 
{
    private int width;
    private int height;
    private float cellSize;
    private int[,] gridArray;
    private TextMesh[,] debugArray;
    public Grid (int width, int height,float cellSize)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;

        gridArray= new int[width, height];
        debugArray = new TextMesh[width, height];


        for(int x=0;x<gridArray.GetLength(0); x++)
        {
            for(int z=0; z<gridArray.GetLength(1); z++) 
            {
                debugArray[x,z] = UtilsClass.CreateWorldText(gridArray[x,z].ToString(), null, GetWorldPosition(x,0,z) + new Vector3(cellSize,0 ,cellSize) * 0.5f, 20, Color.white, TextAnchor.MiddleCenter);
                Debug.DrawLine(GetWorldPosition(x, 0, z), GetWorldPosition(x, 0, z + 1),Color.white,100f);
                Debug.DrawLine(GetWorldPosition(x, 0, z), GetWorldPosition(x+1, 0, z),Color.white, 100f);
            }
        }
        Debug.DrawLine(GetWorldPosition(0,0, height), GetWorldPosition(width,0, height), Color.white, 100f);
        Debug.DrawLine(GetWorldPosition(width,0, 0), GetWorldPosition(width,0, height), Color.white, 100f);

        SetValue(2,1, 56);
    }
    private Vector3 GetWorldPosition(int x,int y ,int z)
    {
        return new Vector3(x,y,z) * cellSize;
    }
    private void GetXZ(Vector3 worldPos, out int x, out int z)
    {
        x = Mathf.FloorToInt(worldPos.x/ cellSize);
        z = Mathf.FloorToInt(worldPos.z/ cellSize);
    }
    public void SetValue(int x, int z,int value)
    {
        if(x >= 0 && z >= 0 && x < width && z < height)
        {
            gridArray[x,z] = value;
            debugArray[x,z].text = gridArray[x,z].ToString();
        }
    }
    public void SetValueV(Vector3 worldPos, int value)
    {
        int x,z;
        GetXZ(worldPos, out x, out z);
        SetValue(x, z, value);  
    }
}
