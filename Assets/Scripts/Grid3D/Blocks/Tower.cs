using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : GenericBlock
{
    private void OnEnable()
    {
        onDetection += Shoot;
    }
    void Start()
    {
        
    }

    private void Shoot()
    {

    }
}
