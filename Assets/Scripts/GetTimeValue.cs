using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetTimeValue : MonoBehaviour
{
    Slider Slider;
    public string atime;
    public int btime = 1;
    public ButtonSoundManager buttonSound;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }
    public void TimeNext(Button button)
    {
        Text selectedBtn = button.GetComponentInChildren<Text>();
        if (selectedBtn.text == "＋" && btime < 30)
        {
            ++btime;
            buttonSound.soundShot();
            atime = btime.ToString();
        }
        else if (selectedBtn.text == "−" && btime > 1)
        {
            --btime;
            buttonSound.soundShot();
            atime = btime.ToString();
        }
    }

}
