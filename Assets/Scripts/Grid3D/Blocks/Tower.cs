using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : GenericBlock
{
    private void OnEnable()
    {
        onDetection += Shoot;
    }


    private void Shoot(Transform eneyPos)
    {
        Debug.Log("eventFIred");
    }

}
