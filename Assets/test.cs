using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("時代："+JidaiManager.eraFlag);
        Debug.Log("難易度："+DifficultManager.difficultFlag);
        Debug.Log("時代："+JidaiManager.eraFlag);
        Debug.Log("時間："+TimeManager.ttime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
