using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameselect : MonoBehaviour
{
    public static int stage=1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void stageScene(int lv)
    {
        stage = lv;
        SceneManager.LoadScene("stage1");   
    }

    public void backbutton()
    {
        SceneManager.LoadScene("menu");
    }

    public static int getstage()
    {
        return stage;
    }
}
