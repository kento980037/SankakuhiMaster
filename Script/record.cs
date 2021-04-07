using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class record : MonoBehaviour
{
    public GameObject text_bestscore1;
    public GameObject text_bestscore2;
    public GameObject text_bestscore3;
    public GameObject text_bestscore4;
    public GameObject text_playtime;
    public GameObject text_playdays;
    int[] bestscore=new int[4];
    int playtimes=0;
    int playdays=0;
    int i;

    // Start is called before the first frame update
    void Start()
    {
        for(i=0;i<4;i++)
        {
            bestscore[i] = PlayerPrefs.GetInt("bestscore" + (i + 1), 0);
        }
        playtimes = PlayerPrefs.GetInt("playtimes", 0);
        playdays = PlayerPrefs.GetInt("playdays", 1);
        text_bestscore1.GetComponent<Text>().text = "" +bestscore[0];
        text_bestscore2.GetComponent<Text>().text = "" + bestscore[1];
        text_bestscore3.GetComponent<Text>().text = "" + bestscore[2];
        text_bestscore4.GetComponent<Text>().text = "" + bestscore[3];
        text_playtime.GetComponent<Text>().text = ""+playtimes;
        text_playdays.GetComponent<Text>().text = ""+playdays;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void backbutton()
    {
        SceneManager.LoadScene("menu");
    }
}
