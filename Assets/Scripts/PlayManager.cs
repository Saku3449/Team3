using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayManager : MonoBehaviour
{
    public Text questionText;
    //public Text answerText;
    public Text timeText;
    public Text timeUpText;
    public Text questionNumberText;
    public string[,] questions;
    public int[,] answers;
    public string[,,] select;
    public int turn;
    AudioSource audioSource;
    public AudioClip correctSE;
    public AudioClip incorrectSE;
    public static int correctNumber;
    public float currentTime;
    public Text Text1;
    public Text Text2;
    public Text Text3;
    public Text Text4;
    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;
    public RawImage correctImage;
    public RawImage incorrectImage;

    // Start is called before the first frame update
    void Start()
    {
        correctNumber = 0;
        questions = setQuestions();
        answers = setAnswers();
        select = setSelect();
        currentTime = (float)TimeManager.ttime;
        turn = 0;
        questionNumberText.text = (turn + 1).ToString() + "/10";
        audioSource = GetComponent<AudioSource>();
        questionText.text = questionText.text = questions[DifficultManager.difficultFlag, turn];
        Text1.text = select[DifficultManager.difficultFlag, turn, 0];
        Text2.text = select[DifficultManager.difficultFlag, turn, 1];
        Text3.text = select[DifficultManager.difficultFlag, turn, 2];
        Text4.text = select[DifficultManager.difficultFlag, turn, 3];
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;
        int minutes = Mathf.FloorToInt(currentTime / 60F);
        int seconds = Mathf.FloorToInt(currentTime - minutes * 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        if (currentTime <= 0.0f)
        {
            StartCoroutine("sceneChange");
        }
    }

    public void OnClickButton(int n)
    {
        if (answers[DifficultManager.difficultFlag, turn] == n)
        {
            audioSource.PlayOneShot(correctSE);
            correctImage.gameObject.SetActive(true);
            correctNumber++;
        }
        else
        {
            audioSource.PlayOneShot(incorrectSE);
            incorrectImage.gameObject.SetActive(true);
        }

        StartCoroutine("nextQuestion");
    }

    IEnumerator nextQuestion()
    {
        turn++;
        if (turn == 10)
        {
            yield return new WaitForSeconds(2);
            SceneManager.LoadScene("ResultScene");
        }
        else
        {
            button1.interactable = false;
            button2.interactable = false;
            button3.interactable = false;
            button4.interactable = false;
            yield return new WaitForSeconds(2);
            correctImage.gameObject.SetActive(false);
            incorrectImage.gameObject.SetActive(false);
            questionText.text = questions[DifficultManager.difficultFlag, turn];
            Text1.text = select[DifficultManager.difficultFlag, turn, 0];
            Text2.text = select[DifficultManager.difficultFlag, turn, 1];
            Text3.text = select[DifficultManager.difficultFlag, turn, 2];
            Text4.text = select[DifficultManager.difficultFlag, turn, 3];
            button1.interactable = true;
            button2.interactable = true;
            button3.interactable = true;
            button4.interactable = true;
        }
        questionNumberText.text = (turn + 1).ToString() + "/10";
    }

    IEnumerator sceneChange()
    {
        //answerText.gameObject.SetActive(false);
        questionText.gameObject.SetActive(false);
        Text1.gameObject.SetActive(false);
        Text2.gameObject.SetActive(false);
        Text3.gameObject.SetActive(false);
        Text4.gameObject.SetActive(false);
        timeText.gameObject.SetActive(false);
        timeUpText.gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("ResultScene");
    }

    string[,] setQuestions()
    {
        string[,] tmp = new string[3, 10];

        tmp[0, 0] = "1605年、家康は将軍の座を\n(　)に譲った";
        tmp[0, 1] = "西軍の総大将は(　)である";
        tmp[0, 2] = "徳川家康が江戸幕府を開いたのは\n(　)である";
        tmp[0, 3] = "大阪夏の陣は(　)年に起こった";
        tmp[0, 4] = "大坂の役の原因は(　)\n鐘銘問題である";
        tmp[0, 5] = "関ヶ原の戦い以前から徳川氏に\n従い大名に取り立てられたものは\n(　)という";
        tmp[0, 6] = "大坂の役が終わった(　)年\n将軍徳川秀忠は一国一城令を\n発令した";
        tmp[0, 7] = "武家諸法度寛永令では\n大名の(　)が制度化された";
        tmp[0, 8] = "武家諸法度寛永令は(　)年\n将軍徳川家光のときに出された";
        tmp[0, 9] = "関ヶ原の戦い以後になって\n徳川氏に臣従した大名を(　)という";

        tmp[1, 0] = "旗本・御家人観察にあたるのが\n(　)である";
        tmp[1, 1] = "朝廷の観察や西国大名の監視などに\nあたる老中に次ぐ要職は(　)である";
        tmp[1, 2] = "江戸幕府の職制は、(　)の\n時代にほぼ完成した";
        tmp[1, 3] = "江戸幕府直轄地の俗称を(　)という";
        tmp[1, 4] = "三奉行の最高格は(　)である";
        tmp[1, 5] = "老中を補佐するのが(　)である";
        tmp[1, 6] = "大名観察にあたるのが\n(　)である";
        tmp[1, 7] = "(　)は幕府非常置の最高の職である";
        tmp[1, 8] = "禁中並公家諸法度において\n天皇は(　)を第一として専念することが規定された";
        tmp[1, 9] = "田畑永代売買の禁令が出されたのは\n寛永の大飢饉の翌年にあたる(　)年である";

        tmp[2, 0] = "街道の輸送の不足分を補うため\n街道沿いの村落に課された人馬の夫役を\n(　)という";
        tmp[2, 1] = "田畑・屋敷地に対する本年貢を\n(　)という";
        tmp[2, 2] = "1604年、幕府は糸割符制度を定め\n(　)商人の暴利を抑えるため\n特定の承認に輸入生糸の一括購入権を与えた";
        tmp[2, 3] = "1609年、薩摩藩の(　)が琉球を征服した";
        tmp[2, 4] = "(　)年、日本人の出入国が\n全面禁止された";
        tmp[2, 5] = "(　)年、平戸のオランダ商館を\n長崎の出島に移した";
        tmp[2, 6] = "1624年、(　)船の来航が禁止された";
        tmp[2, 7] = "1633年、江戸幕府は(　)以外の\n海外渡航を禁止した";
        tmp[2, 8] = "1639年、(　)船の来航を禁止した";
        tmp[2, 9] = "(　)年、島原の乱が発生した";

        return tmp;
    }

    string[,,] setSelect()
    {
        string[,,] tmp = new string[3, 10, 4];

        tmp[0, 0, 0] = "徳川綱吉";
        tmp[0, 0, 1] = "徳川家綱";
        tmp[0, 0, 2] = "徳川秀忠";
        tmp[0, 0, 3] = "徳川家光";
        tmp[0, 1, 0] = "豊臣秀頼";
        tmp[0, 1, 1] = "宇喜多秀家";
        tmp[0, 1, 2] = "上杉景勝";
        tmp[0, 1, 3] = "毛利輝元";
        tmp[0, 2, 0] = "1600";
        tmp[0, 2, 1] = "1603";
        tmp[0, 2, 2] = "1615";
        tmp[0, 2, 3] = "1605";
        tmp[0, 3, 0] = "1624";
        tmp[0, 3, 1] = "1615";
        tmp[0, 3, 2] = "1610";
        tmp[0, 3, 3] = "1631";
        tmp[0, 4, 0] = "延暦寺";
        tmp[0, 4, 1] = "東大寺";
        tmp[0, 4, 2] = "方広寺";
        tmp[0, 4, 3] = "興福寺";
        tmp[0, 5, 0] = "譜代";
        tmp[0, 5, 1] = "親藩";
        tmp[0, 5, 2] = "直参";
        tmp[0, 5, 3] = "外様";
        tmp[0, 6, 0] = "1615";
        tmp[0, 6, 1] = "1631";
        tmp[0, 6, 2] = "1633";
        tmp[0, 6, 3] = "1616";
        tmp[0, 7, 0] = "キリスト教の禁止";
        tmp[0, 7, 1] = "参勤交代";
        tmp[0, 7, 2] = "株仲間の解散";
        tmp[0, 7, 3] = "殉死の禁止";
        tmp[0, 8, 0] = "1630";
        tmp[0, 8, 1] = "1615";
        tmp[0, 8, 2] = "1625";
        tmp[0, 8, 3] = "1635";
        tmp[0, 9, 0] = "譜代";
        tmp[0, 9, 1] = "直参";
        tmp[0, 9, 2] = "外様";
        tmp[0, 9, 3] = "親藩";

        tmp[1, 0, 0] = "大目付";
        tmp[1, 0, 1] = "高家";
        tmp[1, 0, 2] = "書院番頭";
        tmp[1, 0, 3] = "目付";
        tmp[1, 1, 0] = "六波羅奉行";
        tmp[1, 1, 1] = "京都守護";
        tmp[1, 1, 2] = "京都所司代";
        tmp[1, 1, 3] = "京都守護職";
        tmp[1, 2, 0] = "徳川家光";
        tmp[1, 2, 1] = "徳川吉宗";
        tmp[1, 2, 2] = "徳川秀忠";
        tmp[1, 2, 3] = "徳川家綱";
        tmp[1, 3, 0] = "御料所";
        tmp[1, 3, 1] = "入会地";
        tmp[1, 3, 2] = "天領";
        tmp[1, 3, 3] = "蔵入地";
        tmp[1, 4, 0] = "勘定奉行";
        tmp[1, 4, 1] = "大坂町奉行";
        tmp[1, 4, 2] = "寺社奉行";
        tmp[1, 4, 3] = "江戸町奉行";
        tmp[1, 5, 0] = "若年寄";
        tmp[1, 5, 1] = "高家";
        tmp[1, 5, 2] = "大老";
        tmp[1, 5, 3] = "側用人";
        tmp[1, 6, 0] = "大番頭";
        tmp[1, 6, 1] = "目付";
        tmp[1, 6, 2] = "大目付";
        tmp[1, 6, 3] = "城代";
        tmp[1, 7, 0] = "老中";
        tmp[1, 7, 1] = "評定";
        tmp[1, 7, 2] = "大老";
        tmp[1, 7, 3] = "執権";
        tmp[1, 8, 0] = "学問";
        tmp[1, 8, 1] = "道徳";
        tmp[1, 8, 2] = "信仰";
        tmp[1, 8, 3] = "政治";
        tmp[1, 9, 0] = "1653";
        tmp[1, 9, 1] = "1633";
        tmp[1, 9, 2] = "1663";
        tmp[1, 9, 3] = "1643";

        tmp[2, 0, 0] = "村役";
        tmp[2, 0, 1] = "助郷役";
        tmp[2, 0, 2] = "町人足役";
        tmp[2, 0, 3] = "国役";
        tmp[2, 1, 0] = "本途物成";
        tmp[2, 1, 1] = "高掛物";
        tmp[2, 1, 2] = "小物成";
        tmp[2, 1, 3] = "助郷役";
        tmp[2, 2, 0] = "イギリス";
        tmp[2, 2, 1] = "スペイン";
        tmp[2, 2, 2] = "ポルトガル";
        tmp[2, 2, 3] = "オランダ";
        tmp[2, 3, 0] = "島津義弘";
        tmp[2, 3, 1] = "島津忠義";
        tmp[2, 3, 2] = "島津義久";
        tmp[2, 3, 3] = "島津家久";
        tmp[2, 4, 0] = "1635";
        tmp[2, 4, 1] = "1636";
        tmp[2, 4, 2] = "1639";
        tmp[2, 4, 3] = "1641";
        tmp[2, 5, 0] = "1639";
        tmp[2, 5, 1] = "1641";
        tmp[2, 5, 2] = "1644";
        tmp[2, 5, 3] = "1685";
        tmp[2, 6, 0] = "ポルトガル";
        tmp[2, 6, 1] = "オランダ";
        tmp[2, 6, 2] = "スペイン";
        tmp[2, 6, 3] = "イギリス";
        tmp[2, 7, 0] = "奉書船";
        tmp[2, 7, 1] = "朱印船";
        tmp[2, 7, 2] = "通信船";
        tmp[2, 7, 3] = "過書船";
        tmp[2, 8, 0] = "スペイン";
        tmp[2, 8, 1] = "オランダ";
        tmp[2, 8, 2] = "ポルトガル";
        tmp[2, 8, 3] = "イギリス";
        tmp[2, 9, 0] = "1641";
        tmp[2, 9, 1] = "1688";
        tmp[2, 9, 2] = "1637";
        tmp[2, 9, 3] = "1635";

        return tmp;
    }

    int[,] setAnswers()
    {
        int[,] tmp = new int[3, 10];

        tmp[0, 0] = 3;
        tmp[0, 1] = 4;
        tmp[0, 2] = 2;
        tmp[0, 3] = 2;
        tmp[0, 4] = 3;
        tmp[0, 5] = 1;
        tmp[0, 6] = 1;
        tmp[0, 7] = 2;
        tmp[0, 8] = 4;
        tmp[0, 9] = 3;

        tmp[1, 0] = 4;
        tmp[1, 1] = 3;
        tmp[1, 2] = 1;
        tmp[1, 3] = 3;
        tmp[1, 4] = 3;
        tmp[1, 5] = 1;
        tmp[1, 6] = 3;
        tmp[1, 7] = 3;
        tmp[1, 8] = 1;
        tmp[1, 9] = 4;

        tmp[2, 0] = 2;
        tmp[2, 1] = 1;
        tmp[2, 2] = 3;
        tmp[2, 3] = 4;
        tmp[2, 4] = 1;
        tmp[2, 5] = 2;
        tmp[2, 6] = 3;
        tmp[2, 7] = 1;
        tmp[2, 8] = 3;
        tmp[2, 9] = 3;

        return tmp;
    }
}
