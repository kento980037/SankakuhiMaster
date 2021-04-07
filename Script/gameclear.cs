using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameclear : MonoBehaviour
{
    public GameObject text_score;
    public GameObject text_time;
    public GameObject text_marunumber;
    public GameObject text_bastscore;
    public GameObject particle;
    int score;
    int stage;
    int marunumber = 0;
    int playtimes = 0;//プレイ回数
    float bestscore = 0;
    float playtime = 0;
    int allplaytime = 0;
    // Start is called before the first frame update
    void Start()
    {
        score = stage1.getscore();
        stage = stage1.getstage();
        marunumber = stage1.getrowscore();
        playtime = stage1.getplaytime();
        bestscore= PlayerPrefs.GetInt("bestscore"+stage, 0);
        allplaytime = PlayerPrefs.GetInt("playtime", 0);
        allplaytime = allplaytime+(int)playtime;
        PlayerPrefs.SetInt("playtime", allplaytime);

        text_score.GetComponent<Text>().text = "スコア："+score;
        text_time.GetComponent<Text>().text = "タイム：" + Mathf.Round(playtime * 10) / 10;
        text_marunumber.GetComponent<Text>().text = "正解数：" + marunumber;
        if (score>bestscore)
        {
            PlayerPrefs.SetInt("bestscore"+stage, score);
            text_bastscore.SetActive(true);
            particle.SetActive(true);
        }

        playtimes = PlayerPrefs.GetInt("playtimes", 0);
        PlayerPrefs.SetInt("playtimes", playtimes + 1);

        PlayerPrefs.Save();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            SceneManager.LoadScene("gameselect");
        }
    }
}
