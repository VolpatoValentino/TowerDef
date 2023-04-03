using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Enemy : MonoBehaviour
{

    public delegate void OnAttack();
    public static event OnAttack onAttack; 


    void Start()
    {

    }

    
    void Update()
    {
        
    }

    private void Move()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        onAttack?.Invoke();
    }
}
