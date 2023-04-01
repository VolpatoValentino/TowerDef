using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class TestGrid : MonoBehaviour
{
    private Grid grid;
    void Start()
    {

        grid = new Grid(4,2,10f);

    }
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            ChangeGridValue();
        }
    }
    private void ChangeGridValue()
    {
        
        Vector3 vec = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
        vec.y = 0;
        Debug.Log(vec);
        grid.SetValueV(new Vector3(vec.x,vec.y,vec.z * -1), 56);
    }
}
