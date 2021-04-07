using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class stage1 : MonoBehaviour
{
    int question=1;//問題の番号
    int number = 1;//現在の問題が最初から数えて何番目か
    public static int rowscore = 0;//正解した問題数
    int questionNumber = 10;//全部の問題数
    public static int stage = 1;
    public static int score = 0;//ゲームのスコア
    float score_ex = 0;//ゲームのスコアの小数点ver
    float answer = 0;//三角比のこたえ
    float time = 0;//まるばつを表示する時間に関する時間変数
    public static float playtime = 0;//ゲームプレイ時間
    public GameObject text_question;
    public GameObject maru;
    public GameObject batsu;
    public GameObject text_number;
    public GameObject text_playtime;

    // Start is called before the first frame update
    void Start()
    {
        rowscore = 0;
        score = 0;
        playtime = 0;
        stage = gameselect.getstage();
        
        if(stage==1)
        {
            question = Random.Range(1, 16);
        }
        else if(stage==2)
        {
            question = Random.Range(16, 28);
        }
        else if(stage==3)
        {
            question = Random.Range(28, 76);
        }
        else if (stage == 4)
        {
            question = Random.Range(1, 76);
        }
        makeQuestion();
        text_number.GetComponent<Text>().text = "Q"+number;
        text_playtime.GetComponent<Text>().text = "Time : " + Mathf.Round(playtime * 10) / 10;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        playtime += Time.deltaTime;
        text_playtime.GetComponent<Text>().text = "Time : " + Mathf.Round(playtime*10)/10;
        time += Time.deltaTime;
        if(time>0.5f)
        {
            maru.SetActive(false);
            batsu.SetActive(false);
        }
        if(number>questionNumber && time>0.3f)
        {
            if(playtime<60)
            {
                score_ex = (60 - playtime) + rowscore * 10;
            }
            else
            {
                score_ex = rowscore * 10;
            }
            score = (int)score_ex;
            SceneManager.LoadScene("gameclear");
        }
    }

    public static int getscore()
    {
        return score;
    }

    public static int getstage()
    {
        return stage;
    }

    public static int getrowscore()
    {
        return rowscore;
    }
    public static float getplaytime()
    {
        return playtime;
    }

    public void button_answer(float playerAnswer)
    {
        maru.SetActive(false);
        batsu.SetActive(false);
        if (number > questionNumber)
        {
            //ゲームが終了しているので何の処理もしない
        }
        else if (Mathf.Abs(playerAnswer-answer)<0.1f)
        {
            maru.SetActive(true);
            rowscore++;
        }
        else
        {
            batsu.SetActive(true);
        }
        time = 0;
        if (stage == 1)
        {
            question = Random.Range(1, 16);
        }
        else if (stage == 2)
        {
            question = Random.Range(16, 28);
        }
        else if (stage == 3)
        {
            question = Random.Range(28, 76);
        }
        else if (stage == 4)
        {
            question = Random.Range(1, 76);
        }
        makeQuestion();
        number++;
        text_number.GetComponent<Text>().text = "Q" + number;
        if(number>questionNumber)
        {
            text_number.GetComponent<Text>().text = "Q" + questionNumber;
            text_question.GetComponent<Text>().text = "ゲーム終了";
        }
    }

    void makeQuestion()
    {
        if (number > questionNumber)
        {
            //ゲームが終了しているので何の処理もしない
        }
        //satge1
        else if (question == 1)
        {
            text_question.GetComponent<Text>().text = "sin0°=?";
            answer = 0;
        }
        else if (question == 2)
        {
            text_question.GetComponent<Text>().text = "sin30°=?";
            answer = 0.5f;
        }
        else if (question == 3)
        {
            text_question.GetComponent<Text>().text = "sin45°=?";
            answer = 0.705f;
        }
        else if (question == 4)
        {
            text_question.GetComponent<Text>().text = "sin60°=?";
            answer = 0.865f;
        }
        else if (question == 5)
        {
            text_question.GetComponent<Text>().text = "sin90°=?";
            answer = 1;
        }
        else if (question == 6)
        {
            text_question.GetComponent<Text>().text = "cos0°=?";
            answer = 1;
        }
        else if (question == 7)
        {
            text_question.GetComponent<Text>().text = "cos30°=?";
            answer = 0.865f;
        }
        else if (question == 8)
        {
            text_question.GetComponent<Text>().text = "cos45°=?";
            answer = 0.705f;
        }
        else if (question == 9)
        {
            text_question.GetComponent<Text>().text = "cos60°=?";
            answer = 0.5f;
        }
        else if (question == 10)
        {
            text_question.GetComponent<Text>().text = "cos90°=?";
            answer = 0;
        }
        else if (question == 11)
        {
            text_question.GetComponent<Text>().text = "tan0°=?";
            answer = 0;
        }
        else if (question == 12)
        {
            text_question.GetComponent<Text>().text = "tan30°=?";
            answer = 0.577f;
        }
        else if (question == 13)
        {
            text_question.GetComponent<Text>().text = "tan45°=?";
            answer = 1;
        }
        else if (question == 14)
        {
            text_question.GetComponent<Text>().text = "tan60°=?";
            answer = 1.73f;
        }
        else if (question == 15)
        {
            text_question.GetComponent<Text>().text = "tan90°=?";
            answer = 99;
        }
        //stage2
        else if (question == 16)
        {
            text_question.GetComponent<Text>().text = "sin120°=?";
            answer = 0.865f;
        }
        else if (question == 17)
        {
            text_question.GetComponent<Text>().text = "sin135°=?";
            answer = 0.705f;
        }
        else if (question == 18)
        {
            text_question.GetComponent<Text>().text = "sin150°=?";
            answer = 0.5f;
        }
        else if (question == 19)
        {
            text_question.GetComponent<Text>().text = "sin180°=?";
            answer = 0;
        }
        else if (question == 20)
        {
            text_question.GetComponent<Text>().text = "cos120°=?";
            answer = -0.5f;
        }
        else if (question == 21)
        {
            text_question.GetComponent<Text>().text = "cos135°=?";
            answer = -0.705f;
        }
        else if (question == 22)
        {
            text_question.GetComponent<Text>().text = "cos150°=?";
            answer = -0.865f;
        }
        else if (question == 23)
        {
            text_question.GetComponent<Text>().text = "cos180°=?";
            answer = -1;
        }
        else if (question == 24)
        {
            text_question.GetComponent<Text>().text = "tan120°=?";
            answer = -1.73f;
        }
        else if (question == 25)
        {
            text_question.GetComponent<Text>().text = "tan135°=?";
            answer = -1;
        }
        else if (question == 26)
        {
            text_question.GetComponent<Text>().text = "tan150°=?";
            answer = -0.577f;
        }
        else if (question == 27)
        {
            text_question.GetComponent<Text>().text = "tan180°=?";
            answer = 0;
        }
        //stage3
        else if (question == 28)
        {
            text_question.GetComponent<Text>().text = "sin 0 =?";
            answer = 0;
        }
        else if (question == 29)
        {
            text_question.GetComponent<Text>().text = "sin π/6 =?";
            answer = 0.5f;
        }
        else if (question == 30)
        {
            text_question.GetComponent<Text>().text = "sin π/4 =?";
            answer = 0.705f;
        }
        else if (question == 31)
        {
            text_question.GetComponent<Text>().text = "sin π/3 =?";
            answer = 0.865f;
        }
        else if (question == 32)
        {
            text_question.GetComponent<Text>().text = "sin π/2 =?";
            answer = 1;
        }
        else if (question == 33)
        {
            text_question.GetComponent<Text>().text = "cos 0 =?";
            answer = 1;
        }
        else if (question == 34)
        {
            text_question.GetComponent<Text>().text = "cos π/6 =?";
            answer = 0.865f;
        }
        else if (question == 35)
        {
            text_question.GetComponent<Text>().text = "cos π/4 =?";
            answer = 0.705f;
        }
        else if (question == 36)
        {
            text_question.GetComponent<Text>().text = "cos π/3 =?";
            answer = 0.5f;
        }
        else if (question == 37)
        {
            text_question.GetComponent<Text>().text = "cos π/2 =?";
            answer = 0;
        }
        else if (question == 38)
        {
            text_question.GetComponent<Text>().text = "tan 0 =?";
            answer = 0;
        }
        else if (question == 39)
        {
            text_question.GetComponent<Text>().text = "tan π/6 =?";
            answer = 0.577f;
        }
        else if (question == 40)
        {
            text_question.GetComponent<Text>().text = "tan π/4 =?";
            answer = 1;
        }
        else if (question == 41)
        {
            text_question.GetComponent<Text>().text = "tan π/3 =?";
            answer = 1.73f;
        }
        else if (question == 42)
        {
            text_question.GetComponent<Text>().text = "tan π/2 =?";
            answer = 99;
        }
        else if (question == 43)
        {
            text_question.GetComponent<Text>().text = "sin 2π/3 =?";
            answer = 0.865f;
        }
        else if (question == 44)
        {
            text_question.GetComponent<Text>().text = "sin 3π/4 =?";
            answer = 0.705f;
        }
        else if (question == 45)
        {
            text_question.GetComponent<Text>().text = "sin 5π/6 =?";
            answer = 0.5f;
        }
        else if (question == 46)
        {
            text_question.GetComponent<Text>().text = "sin π =?";
            answer = 0;
        }
        else if (question == 47)
        {
            text_question.GetComponent<Text>().text = "cos 2π/3 =?";
            answer = -0.5f;
        }
        else if (question == 48)
        {
            text_question.GetComponent<Text>().text = "cos 3π/4 =?";
            answer = -0.705f;
        }
        else if (question == 49)
        {
            text_question.GetComponent<Text>().text = "cos 5π/6 =?";
            answer = -0.865f;
        }
        else if (question == 50)
        {
            text_question.GetComponent<Text>().text = "cos π =?";
            answer = -1;
        }
        else if (question == 51)
        {
            text_question.GetComponent<Text>().text = "tan 2π/3 =?";
            answer = -1.73f;
        }
        else if (question == 52)
        {
            text_question.GetComponent<Text>().text = "tan 3π/4 =?";
            answer = -1;
        }
        else if (question == 53)
        {
            text_question.GetComponent<Text>().text = "tan 5π/6 =?";
            answer = -0.577f;
        }
        else if (question == 54)
        {
            text_question.GetComponent<Text>().text = "tan π =?";
            answer = 0;
        }
        else if (question == 55)
        {
            text_question.GetComponent<Text>().text = "sin 7π/6 =?";
            answer = -0.5f;
        }
        else if (question == 56)
        {
            text_question.GetComponent<Text>().text = "sin 5π/4 =?";
            answer = -0.705f;
        }
        else if (question == 57)
        {
            text_question.GetComponent<Text>().text = "sin 4π/3 =?";
            answer = -0.865f;
        }
        else if (question == 58)
        {
            text_question.GetComponent<Text>().text = "sin 3π/2 =?";
            answer = -1;
        }
        else if (question == 59)
        {
            text_question.GetComponent<Text>().text = "cos 7π/6 =?";
            answer = -0.865f;
        }
        else if (question == 60)
        {
            text_question.GetComponent<Text>().text = "cos 5π/4 =?";
            answer = -0.705f;
        }
        else if (question == 61)
        {
            text_question.GetComponent<Text>().text = "cos 4π/3 =?";
            answer = -0.5f;
        }
        else if (question == 62)
        {
            text_question.GetComponent<Text>().text = "cos 3π/2 =?";
            answer = 0;
        }
        else if (question == 63)
        {
            text_question.GetComponent<Text>().text = "tan 7π/6 =?";
            answer = 0.577f;
        }
        else if (question == 64)
        {
            text_question.GetComponent<Text>().text = "tan 5π/4 =?";
            answer = 1;
        }
        else if (question == 65)
        {
            text_question.GetComponent<Text>().text = "tan 4π/3 =?";
            answer = 1.73f;
        }
        else if (question == 66)
        {
            text_question.GetComponent<Text>().text = "tan 3π/2 =?";
            answer = 99;
        }
        else if (question ==67)
        {
            text_question.GetComponent<Text>().text = "sin 5π/3 =?";
            answer = -0.865f;
        }
        else if (question == 68)
        {
            text_question.GetComponent<Text>().text = "sin 7π/4 =?";
            answer = -0.705f;
        }
        else if (question == 69)
        {
            text_question.GetComponent<Text>().text = "sin 11π/6 =?";
            answer = -0.5f;
        }
        else if (question == 70)
        {
            text_question.GetComponent<Text>().text = "cos 5π/3 =?";
            answer = 0.5f;
        }
        else if (question == 71)
        {
            text_question.GetComponent<Text>().text = "cos 7π/4 =?";
            answer = 0.705f;
        }
        else if (question == 72)
        {
            text_question.GetComponent<Text>().text = "cos 11π/6 =?";
            answer = 0.865f;
        }
        else if (question == 73)
        {
            text_question.GetComponent<Text>().text = "tan 5π/3 =?";
            answer = -1.73f;
        }
        else if (question == 74)
        {
            text_question.GetComponent<Text>().text = "tan 7π/4 =?";
            answer = -1;
        }
        else if (question == 75)
        {
            text_question.GetComponent<Text>().text = "tan 11π/6 =?";
            answer = -0.577f;
        }

    }
}
