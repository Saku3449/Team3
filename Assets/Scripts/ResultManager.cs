using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultManager : MonoBehaviour
{

    public Text resultScore;
    public Text identity;
    public int correctNum;

    // Start is called before the first frame update
    void Start()
    {
        correctNum = PlayManager.correctNumber;
        resultScore.text = correctNum.ToString();

        if ((0 <= correctNum) && (correctNum <= 3))
        {
            identity.text = "商人";
        }
        else if (correctNum <= 6)
        {
            identity.text = "職人";
        }
        else if (correctNum <= 9)
        {
            identity.text = "農民";
        }
        else if (correctNum <= 10)
        {
            identity.text = "武士";
        }
    }

    public void Retry()
    {
        SceneManager.LoadScene("PlayScene");
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene("StartScene");
    }
}
