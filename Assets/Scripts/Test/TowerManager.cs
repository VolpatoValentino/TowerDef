using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[DisallowMultipleComponent]
public class TowerManager : MonoBehaviour
{

    [SerializeField]
    float speedBullet;
    public GameObject bullet;

    public static TowerManager Instance;
    public delegate void OnRotation();
    public static event OnRotation onRotation;

    private void OnEnable()
    {
        Player.onDetection += Shoot; 
    }
    private void Awake()
    {
        Instance = this; 
    }
    void Start()
    {
        StartCoroutine(RotationTimer());
    }
    
    private void RotateTowerPeriodically()
    {
        StartCoroutine(RotationTimer());
    }
    private IEnumerator RotationTimer()
    {
        transform.localRotation = Quaternion.Euler(0, UnityEngine.Random.Range(1, 360), 0);
        onRotation?.Invoke();
        yield return new WaitForSecondsRealtime(2);
        RotateTowerPeriodically();
        Debug.Log("coroutine");
        yield return null;
    }
    private void Shoot(Vector3 playerPos)
    {

        GameObject bullet1 = Instantiate(bullet, transform.position, Quaternion.identity);
        bullet1.GetComponent<Rigidbody>().AddForce((playerPos - transform.position) * speedBullet, ForceMode.Impulse);
    }
    
}
