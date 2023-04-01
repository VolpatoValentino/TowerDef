using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed;
    public delegate void OnDetection(Vector3 playerPosition);
    public static event OnDetection onDetection;

    private CharacterController charat;

    private void OnEnable()
    {
        TowerManager.onRotation += Detect;
    }
    void Start()
    {
        StartCoroutine(MoveTimer());
        charat = GetComponent<CharacterController>();
    }    
    void Update()
    {

    }
    private void Detect()
    {
        if(Vector3.Dot((transform.position - TowerManager.Instance.transform.position), TowerManager.Instance.transform.forward) >= Mathf.Sqrt(3)/2)
        {
            onDetection.Invoke(transform.position);    
        }
    }
    private void OnDestroy()
    {
        TowerManager.onRotation -= Detect;
    }
    private void MoveChar()
    {
        StartCoroutine(MoveTimer());
        charat.Move((TowerManager.Instance.transform.position - transform.position) * speed * Time.deltaTime);
    }
    private IEnumerator MoveTimer()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        MoveChar();
        yield return null;
        
    }
}
