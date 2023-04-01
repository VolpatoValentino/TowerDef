using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ObjPickerUI : MonoBehaviour
{
    public Button towerAd;
    public Button towerAp;
    public Button armor;
    public Button heavyArmor;

    private ObjectPicker objectPicker;

    private void Start()
    {
        objectPicker = GetComponent<ObjectPicker>();
        Button button = towerAd.GetComponent<Button>();
        button.onClick.AddListener(delegate { objectPicker.Picker(ObjData._TowerAD); });
        
        Button button1 = towerAp.GetComponent<Button>();
        button1.onClick.AddListener(delegate { objectPicker.Picker(ObjData._TowerAp); }) ;
        
        Button button2 = armor.GetComponent<Button>();
        button2.onClick.AddListener(delegate { objectPicker.Picker(ObjData._NormalArmor); });
        
        Button button3 = heavyArmor.GetComponent<Button>();
        button3.onClick.AddListener(delegate { objectPicker.Picker(ObjData._HeavyArmor); });

    }  
}
