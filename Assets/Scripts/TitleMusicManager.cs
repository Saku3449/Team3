using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class TitleMusicManager : MonoBehaviour
{
    // Start is called before the first frame update
    AudioSource audioSource;
    void Start()
    {
        DontDestroyOnLoad (this);
    }

    // Update is called once per frame
    void Update()
    {
           //音を消す
        if(SceneManager.GetActiveScene().name == "PlayScene"){
            Destroy(gameObject);
        }
    }
}
