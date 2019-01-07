using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//制作者：佐伯
//内容：ゲーム全体の状態、値の管理

public class GameController : MonoBehaviour
{
    struct PlayerStorage
    {
        //プレイヤの引き継ぐ情報
        float   playerHP;
        float   playerSP;
        int     playerAttack;
    }
    //どのムービーを流すか
    [HideInInspector]
    public int movieNum;

    //一つしか存在しないようにするための変数
    GameObject[] gameObjects;

    //ゲームコントローラーが一つしか存在しないようにする
    void Awake()
    {
        gameObjects = GameObject.FindGameObjectsWithTag("GameController");
        for (int i = 0; i < gameObjects.Length; ++i) 
        {
            if(i==0)
            {
                continue;
            }
            Destroy(gameObjects[i]);
        }
        DontDestroyOnLoad(this);
    }
}
