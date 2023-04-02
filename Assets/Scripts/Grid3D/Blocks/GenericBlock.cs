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
    private int damagaAp;
    [SerializeField]
    private int detectionRange;
    [SerializeField]
    private LayerMask enemyLayer;

    public delegate void OnDetection();
    public static event OnDetection onDetection;

    private void Update()
    {
        Detection();   
    }
    private void Detection()
    {
        if (Physics.CheckSphere(transform.position, detectionRange, enemyLayer))
        {
            Collider[] hitInfo = Physics.OverlapSphere(transform.position,detectionRange, enemyLayer);
            if(hitInfo != null )
            {
                for(int i = 0;i < hitInfo.Length; i++)
                {
                    onDetection?.Invoke();

                }

            }
        }
    }
}
