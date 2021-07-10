using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class JidaiManager : MonoBehaviour
{
    [SerializeField]    	
    private GameObject manager_;
    public static int eraFlag;
    // Start is called before the first frame update
    void Start()
    {
        eraFlag = 0;
    }

    public void TimeNext(Button button){
        Text selectedBtn = button.GetComponentInChildren<Text> ();
        if (selectedBtn.text == "平安時代") {
            eraFlag=1;
            SceneManager.LoadScene("SelectDifficulty");
        }
        else if (selectedBtn.text == "鎌倉時代") {
            eraFlag=2;
            SceneManager.LoadScene("SelectDifficulty");
        }
        else if (selectedBtn.text == "室町時代") {
            eraFlag=3;
            SceneManager.LoadScene("SelectDifficulty");
        }
        else if (selectedBtn.text == "安土桃山時代") {
            eraFlag=4;
            SceneManager.LoadScene("SelectDifficulty");
        }
		else if (selectedBtn.text == "江戸時代") {
            eraFlag=5;
            SceneManager.LoadScene("SelectDifficulty");
        }
        else if (selectedBtn.text == "明治時代") {
            eraFlag=5;
            SceneManager.LoadScene("SelectDifficulty");
        }
    }
}


