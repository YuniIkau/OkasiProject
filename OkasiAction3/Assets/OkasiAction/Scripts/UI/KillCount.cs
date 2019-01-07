using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillCount : MonoBehaviour
{
    //キル数の表示
    int killCount;
    GameObject killCnt;
    
    //Enemyの取得
    EnemyReflect enemyReflect;

    void Start ()
    {
        killCount = 0;
        enemyReflect = GetComponent<EnemyReflect>();
        killCnt = GameObject.FindGameObjectWithTag("KillCount");
    }

	void Update ()
    {
        //キル数テキスト表示
        killCnt.GetComponent<Text>().text = "KILL："+killCount.ToString();
        if (Input.GetKeyDown(KeyCode.N))
        {
            killCount++;
            Killer();
        }
    }

    void Killer()
    {
        //if (enemyReflect.EnemyDath())
        //{
        //    killCount++;
        //}
    }
}
