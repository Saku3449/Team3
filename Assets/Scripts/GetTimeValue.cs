using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetTimeValue : MonoBehaviour
{
    Slider Slider;
    int atime;
    public int btime;
    // Start is called before the first frame update
    void Start()
    {
        Slider = GameObject.Find("Slider").GetComponent<Slider>();
        //hpSlider.value = nowHp;
        int nowHp = 1;
        //スライダーの現在値の設定
        Slider.value = nowHp;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("現在値：" + Slider.value);
        btime = (int)Slider.value;
        
    }

    public void timer(){
        btime = (int)Slider.value;
    }
  
}
