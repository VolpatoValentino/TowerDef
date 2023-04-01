using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class PlayerSpawner : MonoBehaviour
{
    public GameObject playerPrefab;
  
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            Spawner();
    }
    private void Spawner()
    {
        Vector3 mouseClick = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseClick.y = 1;
        Debug.Log(mouseClick);
        Instantiate(playerPrefab, mouseClick,Quaternion.identity);
    }
}
