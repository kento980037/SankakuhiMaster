using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;

public class menu : MonoBehaviour
{
    public GameObject akamaru;
    int i;
    int[] i_collection = new int[15];
    int[] bestscore = new int[4];
    int playtime=0;
    int playtimes=0;
    int playdays=0;

    public GameObject asobuButton;
    public GameObject collectionButton;
    public GameObject recordButton;
    public GameObject text_day;
    public GameObject text_kakugen;
    public GameObject login;
    int lastday = 0;
    int nowday = 0;

    // Start is called before the first frame update
    void Start()
    {
        for(i=0;i<15;i++)
        {
            i_collection[i] = PlayerPrefs.GetInt("collection" + (i + 1), 0);//2なら手に入れてかつnewじゃない。1ならnew
        }
        for(i=0;i<4;i++)
        {
            bestscore[i] = PlayerPrefs.GetInt("bestscore" + (i + 1), 0);
        }
        playtime = PlayerPrefs.GetInt("playtime", 0);
        playtimes = PlayerPrefs.GetInt("playtimes", 0);
        playdays = PlayerPrefs.GetInt("playdays", 0);


        if (i_collection[0] == 0 && bestscore[0] >= 100)
        {
            i_collection[0] = 1;
        }
        else if (i_collection[1] == 0 && bestscore[1] >= 100)
        {
            i_collection[1] = 1;
        }
        else if (i_collection[2] == 0 && bestscore[2] >= 100)
        {
            i_collection[2] = 1;
        }
        else if (i_collection[3] == 0 && bestscore[3] >= 100)
        {
            i_collection[3] = 1;
        }
        else if (i_collection[4] == 0 && bestscore[0] >= 130)
        {
            i_collection[4] = 1;
        }
        else if (i_collection[5] == 0 && bestscore[1] >= 130)
        {
            i_collection[5] = 1;
        }
        else if (i_collection[6] == 0 && bestscore[2] >= 130)
        {
            i_collection[6] = 1;
        }
        else if (i_collection[7] == 0 && bestscore[3] >= 130)
        {
            i_collection[7] = 1;
        }
        else if (i_collection[8] == 0 && bestscore[0] >= 145)
        {
            i_collection[8] = 1;
        }
        else if (i_collection[9] == 0 && bestscore[1] >= 145)
        {
            i_collection[9] = 1;
        }
        else if (i_collection[10] == 0 && bestscore[2] >= 145)
        {
            i_collection[10] = 1;
        }
        else if (i_collection[11] == 0 && bestscore[3] >= 145)
        {
            i_collection[11] = 1;
        }
        else if (i_collection[12] == 0 && bestscore[0] + bestscore[1] + bestscore[2] + bestscore[3] >= 550)
        {
            i_collection[12] = 1;
        }
        else if (i_collection[13] == 0 && playtime >= 1800 && playtimes >= 50)
        {
            i_collection[13] = 1;
        }
        else if (i_collection[14] == 0 && playdays >= 5)
        {
            i_collection[14] = 1;
        }



        for (i = 0; i < 15; i++)
        {
            PlayerPrefs.SetInt("collection" + (i + 1), i_collection[i]);
            if (i_collection[i] == 1)
            {
                akamaru.SetActive(true);
            }
        }



        lastday = PlayerPrefs.GetInt("lastday", 0);
        playdays = PlayerPrefs.GetInt("playdays", 0);
        nowday = DateTime.Now.Year * 10000 + DateTime.Now.Month * 100 + DateTime.Now.Day;//2020年3月18にちは、20200318
        if (nowday - lastday > 0)
        {
            playdays++;
            lastday = nowday;
            PlayerPrefs.SetInt("lastday", lastday);
            PlayerPrefs.SetInt("playdays", playdays);
            PlayerPrefs.Save();
            login.SetActive(true);
            asobuButton.SetActive(false);
            collectionButton.SetActive(false);
            recordButton.SetActive(false);
            text_day.GetComponent<Text>().text = ""+playdays;
            if(nowday%5==0)
            {
                text_kakugen.GetComponent<Text>().text = "できると思えばできる、できないと思えばできない。これは揺るぎない絶対的な法則である。（パブロ・ピカソ）";
            }
            else if(nowday%5==1)
            {
                text_kakugen.GetComponent<Text>().text = "誰よりも三倍、四倍、五倍勉強する者、それが天才だ。（野口英世）";
            }
            else if(nowday%5==2)
            {
                text_kakugen.GetComponent<Text>().text = "失敗したわけではない。それを誤りだと言ってはいけない。勉強したのだと言いたまえ。（トーマス・エジソン）";
            }
            else if (nowday % 5 == 3)
            {
                text_kakugen.GetComponent<Text>().text = "学べば学ぶほど、自分が何も知らなかったことに気づく。気づけば気づくほど学びたくなる（アルベルト・アインシュタイン）";
            }
            else if (nowday % 5 == 4)
            {
                text_kakugen.GetComponent<Text>().text = "明日はなんとかなると思う馬鹿者。今日でさえ遅すぎるのだ。賢者はもう昨日済ましている。(チャールズ・クーリー）";
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void gameselectScene()
    {
        SceneManager.LoadScene("gameselect");
    }

    public void collectionScene()
    {
        PlayerPrefs.Save();
        SceneManager.LoadScene("collection");
    }

    public void recordScene()
    {
        SceneManager.LoadScene("record");
    }

    public void loginok()
    {
        login.SetActive(false);
        asobuButton.SetActive(true);
        collectionButton.SetActive(true);
        recordButton.SetActive(true);
    }
}
