using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class Base : MonoBehaviour
{
    int _TowerHp;
    int _TowerArmor;
    int _TowerDamageAd;
    int _TowerDamageAp;

    public delegate void OnDetection(Vector3 pos);
    public static event OnDetection onDetection;
  
    private void OnEnable()
    {
        CreateCube.onBlockCreation += CheckTowerStats;
    }
    private void Start()
    {
        
    }
    private void CheckTowerStats()
    {
        RaycastHit hitinfo;
        if (Physics.Raycast(transform.position, Vector3.up, out hitinfo, 4f))
        {
            hitinfo.collider.gameObject.GetComponent<GenericBlock>().stats.hp = _TowerHp;
            hitinfo.collider.gameObject.GetComponent<GenericBlock>().stats.armor = _TowerArmor;
            hitinfo.collider.gameObject.GetComponent<GenericBlock>().stats.damageAd = _TowerDamageAd;
            hitinfo.collider.gameObject.GetComponent<GenericBlock>().stats.damageAp = _TowerDamageAp;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
            onDetection?.Invoke(other.transform.position);
    }
}
