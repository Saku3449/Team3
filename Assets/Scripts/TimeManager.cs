using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class TimeManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GetTimeValue timevalue;
    public static int ttime;

    void Start()
    {
        //Debug.Log("時代："+JidaiManager.eraFlag);
        //Debug.Log("難易度："+DifficultManager.difficultFlag);

    }

    // Update is called once per frame
    void Update()
    {

    }
    

    public void Play(Button button){
        ttime = timevalue.btime * 60;
        SceneManager.LoadScene("PlayScene");
    }
}
