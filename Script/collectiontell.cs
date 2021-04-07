using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class collectiontell : MonoBehaviour
{
    int i;
    int j;
    int k;
    int[] i_collection = new int[15];
    int[] bestscore = new int[4];
    int selectcollection;
    int playtime = 0;
    int playtimes = 0;
    int playdays = 0;
    GameObject[] object_collection = new GameObject[15];
    public GameObject collectiontell_text;
    public GameObject particle;
    public GameObject object_new;

    // Start is called before the first frame update
    void Start()
    {
        selectcollection = collection.getSelect();
        for (i = 0; i < 4; i++)
        {
            bestscore[i] = PlayerPrefs.GetInt("bestscore" + (i + 1), 0);
        }
        playtime = PlayerPrefs.GetInt("playtime", 0);
        playtimes = PlayerPrefs.GetInt("playtimes", 0);
        playdays = PlayerPrefs.GetInt("playdays", 0);
        for (i = 0; i < 15; i++)
        {
            object_collection[i] = GameObject.Find("collection" + (i + 1));
            i_collection[i] = PlayerPrefs.GetInt("collection" + (i + 1), 0);//2なら手に入れてかつnewじゃない。1ならnew
            if (selectcollection == i + 1)
            {
                object_collection[i].SetActive(true);
            }
            else
            {
                object_collection[i].SetActive(false);
            }
        }
        //ここまでは参照

        //ここから新コレクションの処理
        k = 0;
        for(i=0;i<15;i++)
        { 
            if (i_collection[i] == 1 && k==0)//new
            {
                k++;
                particle.SetActive(true);
                object_new.SetActive(true);
                i_collection[i] = 2;
                PlayerPrefs.SetInt("collection" + (i + 1), 2);
                PlayerPrefs.Save();


                //以下は連続のnewに対応する処理
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
                for (j = 0; j < 15; j++)
                {
                    PlayerPrefs.SetInt("collection" + (j + 1), i_collection[j]);
                }
                //ここまで


            }
        }

        if(selectcollection==1)
        {
            collectiontell_text.GetComponent<Text>().text = "【定規】\n★\n定規と物差しの違いをご存知だろうか。形状が似ているため両者は混同しがちであるが、定規は直線や角を描画するときに用いられ、物差しは線分の長さを測るものである。しかし、定規にも目盛りがあり長さを測ることはできるので厳密な違いを考える必要はないかもしれない。";
        }
        else if(selectcollection==2)
        {
            collectiontell_text.GetComponent<Text>().text = "【分度器】\n★\n分度器は角度を測定するために用いられる文房具である。一般的に広く知られているのは半円の半円分度器であるが、全円形の全円分度器も存在する。全円形分度器は製図用であり文房具専門店でしか入手できないが、土地家屋調査士の作図試験などでは必須である。";
        }
        else if (selectcollection == 3)
        {
            collectiontell_text.GetComponent<Text>().text = "【コンパス】\n★\nコンパスといえば「円を描く文房具」というかもしれないが、「同じ長さを写す文房具」という面もコンパスにはあるということを忘れてはいけない。「同じ長さを写しとる」という役割は、二等辺三角形や、平行四辺形、ひし形、合同な三角形の作図など多くのところで使われる。";
        }
        else if (selectcollection == 4)
        {
            collectiontell_text.GetComponent<Text>().text = "【電卓】\n★\n電卓は計算機の一種で電子（式）卓上計算機の略である。さて、電卓には様々なボタンがあるが、「M」というボタンの意味は知っているだろうか。これは「メモリー機能」であり、途中でメモを取ることなく複数の計算が出来る。例えば「M+」は直前の数値、または計算結果をメモリーに足す時に用いる。";
        }
        else if (selectcollection == 5)
        {
            collectiontell_text.GetComponent<Text>().text = "【GPS】\n★★\nGPSは、宇宙空間に配置されたGPS衛星から送られる電波を地上で受信し地上の位置を求める測位方法で、カーナビなどで利用される。GPSによる測量は「衛星を使った三角測量」のようなものであり、三角比や三角関数の知識無くしては成り立たない。";
        }
        else if (selectcollection == 6)
        {
            collectiontell_text.GetComponent<Text>().text = "【三角形】\n★★\n三角形は、同一直線上にない3点と、それらを結ぶ3つの線分からなる多角形である。その3点を三角形の頂点、3つの線分を三角形の辺という。";
        }
        else if (selectcollection == 7)
        {
            collectiontell_text.GetComponent<Text>().text = "【π】\n★★\n円周率は、円の周長の直径に対する比率であり、通常ギリシア文字 「π」で表される。円周率は無理数であるのみならず超越数でもある。π=3..14159265358979323846264338327950288419716939937510582097494459230781640628620899862803482534211706798214808651...";
        }
        else if (selectcollection == 8)
        {
            collectiontell_text.GetComponent<Text>().text = "【θ】\n★★\nギリシャ文字の1つ。数学や物理では角度などを表すのによく使われる。また英語の「th」の発音記号にも使われる。英語の発音記号でのこの音は、舌先を上の前歯に触れさせながら、そのすきまから空気を出して発音する。日本人が苦手とする英語の子音の1つである。";
        }
        else if (selectcollection == 9)
        {
            collectiontell_text.GetComponent<Text>().text = "【正弦波】\n★★★\n波形がy＝sin xのグラフで示される曲線で表される波のこと。、数学、信号処理、電気工学およびその他の分野において重要な働きをする。ノイズなどが無視できるとすると、自然界でも海の波、音波、光波などで観測することができる。また、交流電圧の波形は正弦波である。";
        }
        else if (selectcollection == 10)
        {
            collectiontell_text.GetComponent<Text>().text = "【単位円】\n★★★\n原点を中心とする半径が１の円のこと。三角関数を用いると、単位円周上の任意の点の座標は、(cosθ, sinθ)と表すことができる。しかし、これは三角関数の定義そのものである。また、tanθは、その円周上の点と原点を結ぶ直線との傾きである。";
        }
        else if (selectcollection == 11)
        {
            collectiontell_text.GetComponent<Text>().text = "【計測】\n★★★\n「三角測量」に代表されるように三角関数は何かを測るときに用いられることがある。三角関数を用いると、長さから角度を求めたり、角度から長さを求めることができる。国土地理院による測量や、ステレオカメラにももちろん三角関数が用いられる。";
        }
        else if (selectcollection == 12)
        {
            collectiontell_text.GetComponent<Text>().text = "【回転】\n★★★\n何かの回転を記述や制御するときに三角関数は必要不可欠である。3DCGや機械の回転の制御に使われるのはもちろん、広告や芸術の分野でも使われている。世の中にある多くの自然現象を理解することから、人々にとって便利な物を作ることまで、あらゆることに三角関数は関わっていると言えるのではないだろうか。";
        }
        else if (selectcollection == 13)
        {
            collectiontell_text.GetComponent<Text>().text = "【波動】\n★★★\ny=sinxをグラフにすると波のようなグラフになることから、三角関数と波動との関係は深いことがわかる。世の中の「波動」は、バネや地震なだけでなく電気回路や信号処理、音声処理の分野にも存在するため、応用範囲がとても幅広い。また、これらを三角関数を用いて記述することができれば、フーリエ変換などで分析・編集することができるのだ。";
        }
        else if (selectcollection == 14)
        {
            collectiontell_text.GetComponent<Text>().text = "【タイヤ】\n★★★★\nゲームアプリ「VSあおり運転」に登場するコレクションのひとつ。タイヤは車輪の円環部分。19世紀には空気入りタイヤ、20世紀半ばにはチューブレスタイヤ、90年代にはスタッドレスタイヤなどの様々なタイヤが登場し、自動車の発達とともに進化を続けている。";
        }
        else if (selectcollection == 15)
        {
            collectiontell_text.GetComponent<Text>().text = "【タピオカミルクティー】\n★★★★\nゲームアプリ「タピのみ」に登場するコレクションのひとつ。2019年タピオカが大ブームになりタピオカラーメンなどが出てくるほどであったが、少し待ってほしい。初心を忘れてはならない。爽やかなミルクティーの甘さともちもちなタピオカとの相性が抜群なタピオカミルクティーが王道ではないだろうか。";
        }
    }




    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            PlayerPrefs.Save();
            SceneManager.LoadScene("collection");
        }
    }
}
