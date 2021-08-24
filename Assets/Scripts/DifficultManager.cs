using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class DifficultManager : MonoBehaviour
{
    public static int difficultFlag;
    public ButtonSoundManager buttonSound;
    // Start is called before the first frame update
    void Start()
    {
        difficultFlag = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DifficultNext(Button button)
    {
        Text selectedBtn = button.GetComponentInChildren<Text>();
        if (selectedBtn.text == "簡単")
        {
            difficultFlag = 0;
            buttonSound.soundShot();
            Invoke("NextScene", 0.4f);
        }
        if (selectedBtn.text == "普通")
        {
            difficultFlag = 1;
            buttonSound.soundShot();
            Invoke("NextScene", 0.4f);
        }
        if (selectedBtn.text == "難しい")
        {
            difficultFlag = 2;
            buttonSound.soundShot();
            Invoke("NextScene", 0.4f);
        }
    }
    void NextScene()
    {
        SceneManager.LoadScene("SelectTime");
    }
}
