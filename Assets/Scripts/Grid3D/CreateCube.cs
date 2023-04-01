using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCube : MonoBehaviour
{
    private Grid3D grid;
    private GameObject cube;
    [SerializeField]
    private float ceiling;
    [SerializeField]
    private LayerMask layerMask;


  


    void Start()
    {
        grid = FindObjectOfType<Grid3D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hitinfo;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hitinfo)) 
            {
                if(hitinfo.collider.tag != "UI")
                    PlaceCube(hitinfo.point);
            }
        }
    }

    private void PlaceCube(Vector3 clickPoint)
    {
        Vector3 finalPos = grid.GetNearPointOnGrid(clickPoint) + new Vector3(0,0.5f,0);
        if(ObjectPicker.Instance.selectedObj != null)
        {
            cube = Instantiate(ObjectPicker.Instance.selectedObj);
            if (!CheckAlreadySpawned(cube.transform, clickPoint))
            {
                cube.transform.position = finalPos;
                
            }
            else
            {
                cube.transform.position = finalPos + new Vector3(0,1,0);
               
                
            }
            
            //check if cube is above y Max, ceiling should always be -1 of grid y dimension
            if (cube.transform.position.y >= ceiling)
                Destroy(cube);
        }
    }

    private bool CheckAlreadySpawned(Transform cube, Vector3 hitInfo)
    {
        if(cube.position == hitInfo)
        {
            return true;
        }
        return false;
    }
}
