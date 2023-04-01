using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JsonPosition : MonoBehaviour
{
    [Serializable]
    public class JsoPos
    {
        public Vector3 position;
    }
    public JsoPos pos = new JsoPos();

    public void OutPutJson()
    {
        string json = JsonUtility.ToJson(pos);
        File.WriteAllText(Application.dataPath + "/text.txt", json);
    }
    private void Start()
    {
        pos.position = Vector3.zero;
        OutPutJson();
    }
}

