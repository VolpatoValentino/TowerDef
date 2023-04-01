using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid3D : MonoBehaviour
{
    [SerializeField]
    private float cellSize = 1f;
    [SerializeField]
    private float xSize, ySize, zSize;


    public Vector3 GetNearPointOnGrid(Vector3 position)
    {
        //Adding and removing position so the offset can work without having to restart to create a new grid
        position -= transform.position;

        int xCount= Mathf.RoundToInt(position.x / cellSize);
        int yCount= Mathf.RoundToInt(position.y / cellSize);
        int zCount= Mathf.RoundToInt(position.z / cellSize);

        Vector3 result = new Vector3(
            (float)xCount * cellSize,
            (float)yCount * cellSize,
            (float)zCount * cellSize
            );
        result += transform.position;

        
        return result;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        for(float x =0; x < xSize ; x += cellSize)
        {
            for(float y =0; y < ySize; y += cellSize)
            {
                for(float z =0;z < zSize;z+=cellSize)
                {
                    var point = GetNearPointOnGrid(new Vector3(x,y,z));
                    Gizmos.DrawSphere(point, 0.1f);
                }
            }
        }
    }
}
