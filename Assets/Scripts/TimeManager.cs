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
    public ButtonSoundManager buttonSound;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Play(Button button)
    {
        ttime = timevalue.btime * 60;
        //ttime = timevalue.btime; //分にしたいときはこっちを消して上に変える。
        buttonSound.soundShot();
        Invoke("NextScene", 0.4f);
    }
    void NextScene()
    {
        SceneManager.LoadScene("PlayScene");
    }
}
