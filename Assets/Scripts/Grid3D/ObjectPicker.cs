using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPicker : MonoBehaviour
{
    public GameObject TowerAd;
    public GameObject TowerAp;
    public GameObject Armor;
    public GameObject HeavyArmor;
    
    [HideInInspector]
    public GameObject selectedObj;

    public static ObjectPicker Instance;
    private void Awake()
    {
        Instance = this;
    }

    public GameObject Picker(ObjData data)
    {        
        switch (data)
        {
            case ObjData._TowerAD:
                {
                    Debug.Log("TowerAD");
                    selectedObj = TowerAd;
                    return TowerAd;
                }
            case ObjData._TowerAp:
                {

                    Debug.Log("TowerAp");
                    selectedObj= TowerAp;
                    return TowerAp;
                }
            case ObjData._NormalArmor:
                {

                    Debug.Log("Armor");
                    selectedObj = Armor;
                    return Armor;
                }
            case ObjData._HeavyArmor:
                {

                    Debug.Log("HArmor");
                    selectedObj = HeavyArmor;
                    return HeavyArmor;
                }
            default:
                return null;
        }
    }
}
