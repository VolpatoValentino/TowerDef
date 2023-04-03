using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericBlock : MonoBehaviour
{
    [SerializeField]
    private int hp;
    [SerializeField]
    private int armor;
    [SerializeField]
    private int damageAd;
    [SerializeField]
    private int damageAp;
    [SerializeField]
    private int detectionRange;
    [SerializeField]
    private LayerMask enemyLayer;

    public delegate void OnDetection(Transform pos);
    public static event OnDetection onDetection;

    /*private void Detection()
    {
        if (Physics.CheckSphere(transform.position, detectionRange, enemyLayer))
        {
            Collider[] hitInfo = Physics.OverlapSphere(transform.position,detectionRange, enemyLayer);
            if(hitInfo != null )
            {
                for(int i = 0;i < hitInfo.Length; i++)
                {
                    onDetection?.Invoke(hitInfo[i].transform);
                }
            }
        }
    }*/
    private void Start()
    {
        RaycastHit hitinfo;
        if(Physics.Raycast(transform.position, Vector3.down, out hitinfo, 0.6f))
        {
            if(hitinfo.collider.gameObject.GetComponent<GenericBlock>() != null)
            {
                Debug.Log("sdaf");

                int newHp = hp + hitinfo.collider.gameObject.GetComponent<GenericBlock>().hp;
                int newArmor = armor + hitinfo.collider.gameObject.GetComponent<GenericBlock>().armor;
                int newAp = damageAp + hitinfo.collider.gameObject.GetComponent<GenericBlock>().damageAp;
                int newAd = damageAd + hitinfo.collider.gameObject.GetComponent<GenericBlock>().damageAd;
                hp = newHp;
                armor = newArmor;
                damageAp = newAp;
                damageAd = newAd;
            }
        }
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
            onDetection?.Invoke(other.transform);
    }
}
