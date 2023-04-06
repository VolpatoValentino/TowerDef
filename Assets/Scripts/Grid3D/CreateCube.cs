using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCube : MonoBehaviour
{
    private Grid3D grid;
    public GameObject cube;
    [SerializeField]
    private float ceiling;
    [SerializeField]
    private LayerMask layerMask;

    private List<Vector3> savedPosition;

    public delegate void OnBlockCreation();
    public static event OnBlockCreation onBlockCreation;


    void Start()
    {
        grid = FindObjectOfType<Grid3D>();
        savedPosition= new List<Vector3>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hitinfo;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hitinfo,100,layerMask)) 
            {
                if(hitinfo.collider.tag != "UI")
                    PlaceCube(hitinfo.point,hitinfo);
            }
        }
    }

    private void PlaceCube(Vector3 clickPoint,RaycastHit hitinfo)
    {
        Vector3 finalPos = grid.GetNearPointOnGrid(clickPoint) + new Vector3(0,0.5f,0);
        if(ObjectPicker.Instance.selectedObj != null)
        {

            cube = Instantiate(ObjectPicker.Instance.selectedObj);
            if(hitinfo.collider.gameObject.layer == 4)
            {
                cube.transform.position = finalPos;
                cube.transform.position += new Vector3(0, 1, 0);
                Debug.Log(hitinfo.collider.name);
                Debug.Log(cube.transform.position);
                Debug.Log(finalPos + new Vector3(0, 1, 0));
            }
            else
            {
                cube.transform.position = finalPos;
                Debug.Log(finalPos);
            }
            /*if (!CheckAlreadySpawned(cube.transform, clickPoint))
            {
                cube.transform.position = finalPos;
                //AddToList(finalPos);
            }
            else
            {
                cube.transform.position = finalPos + new Vector3(0,1,0);
                
                //AddToList(finalPos);
            }*/
            
            if(cube.transform.position.y <= 0.7f)
            {
                Debug.Log(hitinfo.collider.name);
                Debug.Log(cube.transform.position);
                Debug.Log(finalPos + new Vector3(0, 1, 0));
                cube.AddComponent<Base>();
            }
            else
            {
                onBlockCreation?.Invoke();
                cube.GetComponent<Collider>().enabled = false;
            }
            //check if cube is above y Max, ceiling should always be -1 of grid y dimension
            if (cube.transform.position.y >= ceiling)
                Destroy(cube);
        }
    }

    private bool CheckAlreadySpawned(Transform cube, Vector3 hitInfo)
    {
        if(cube.position == hitInfo + new Vector3(0, 0.5f, 0))
        {
            return true;
        }
        return false;
    }
    private void AddToList(Vector3 positionSaved)
    {
        if (!savedPosition.Contains(positionSaved))
        {
            savedPosition.Add(positionSaved);
        }
        else
        {
            Destroy(cube);
        }
    }
}
