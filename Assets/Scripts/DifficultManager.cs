using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class DifficultManager : MonoBehaviour
{
    public static int difficultFlag;
    // Start is called before the first frame update
    void Start()
    {
        difficultFlag = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void DifficultNext(Button button){
        Text selectedBtn = button.GetComponentInChildren<Text> ();
        if (selectedBtn.text == "簡単") {
            difficultFlag=1;
            SceneManager.LoadScene("SelectTime");
        }
        if (selectedBtn.text == "普通") {
            difficultFlag=2;
            SceneManager.LoadScene("SelectTime");
        }
        if (selectedBtn.text == "難しい") {
            difficultFlag=3;
            SceneManager.LoadScene("SelectTime");
        }
    }
}
