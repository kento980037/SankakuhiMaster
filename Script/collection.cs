using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class collection : MonoBehaviour
{
    int i;
    int[] i_collection = new int[15];
    GameObject[] object_collection = new GameObject[15];
    public static int selectcollection;

    // Start is called before the first frame update
    void Start()
    {
        for(i=0;i<15;i++)
        {
            object_collection[i] = GameObject.Find("collection" + (i + 1));
            i_collection[i] = PlayerPrefs.GetInt("collection" + (i + 1), 0);//2なら手に入れてかつnewじゃない。1ならnew
            if(i_collection[i]<2)
            {
                object_collection[i].SetActive(false);
            }
            if(i_collection[i]==1)
            {
                selectcollection = i+1;
                SceneManager.LoadScene("collectiontell");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static int getSelect()
    {
        return selectcollection;
    }

    public void backbutton()
    {
        SceneManager.LoadScene("menu");
    }

    public void button_collection(int i2)
    {
        selectcollection = i2;
        SceneManager.LoadScene("collectiontell");
    }
}
