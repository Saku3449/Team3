using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("a");
        Debug.Log("時代："+JidaiManager.eraFlag);
        Debug.Log("難易度："+DifficultManager.difficultFlag);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
