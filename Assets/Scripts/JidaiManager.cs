using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;


public class JidaiManager : MonoBehaviour
{
    [SerializeField]    	
    private GameObject manager_;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TimeNext()
    {
        Text selectedBtn = button.GetComponentInChildren<Text> ();
		if (selectedBtn.text == "江戸時代") {
            SceneManager.LoadScene("SelectDifficulty");
        }
        
    }
}
