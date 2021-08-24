using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject score_object = null; // Textオブジェクト

    public GetTimeValue getTimeValue;
    // オブジェクトからTextコンポーネントを取得

    void Start()
    {

    }

    // 更新
    void Update()
    {
        Text score_text = score_object.GetComponent<Text>();
        // テキストの表示を入れ替える
        score_text.text = getTimeValue.atime;
    }
}
