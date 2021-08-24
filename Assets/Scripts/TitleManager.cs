using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    // Start is called before the first frame update
    public ButtonSoundManager buttonSound;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Next()
    {
        buttonSound.soundShot();
        Invoke("NextScene", 0.4f);
    }
    void NextScene()
    {

        SceneManager.LoadScene("SelectHistory");

    }
}
