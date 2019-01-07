using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//制作者：藤田
//内容：SPゲージの制御

public class SPSystem : MonoBehaviour
{
    //UIに表示するSPゲージ
    GameObject spGage;
    Image spImage;

    //プレイヤのパラメーター
    GameObject playerState;
    PlayerState player;
    PlayerTable playerTable;

    // Use this for initialization
    void Start ()
    {
        //playerのパラメーターを取得
        playerState = GameObject.FindGameObjectWithTag("Player");
        player = playerState.GetComponent<PlayerState>();
        playerTable = Resources.Load("PlayerTable") as PlayerTable;
        //SP取得
        spGage = GameObject.FindGameObjectWithTag("SP");
        spImage=spGage.GetComponent<Image>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(Input.GetKeyDown(KeyCode.B))
        {
            SPChage();
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            SpecialArts();
        }
    }
    //SPゲージチャージ(仮)
    public void SPChage()
    {
        if(player.sP < player.maxSP)
        {
            player.sP += playerTable.addSP;
            spImage.fillAmount = player.sP / player.maxSP;
            //SPの値がMAX値を超えないように
            if (player.sP > player.maxSP)
            {
                player.sP = player.maxSP;
            }
        }
    }
    //SPゲージ消費(仮)
    void SpecialArts()
    {
        if (player.sP == player.maxSP)
        {
            player.sP = 0.0f;
            spImage.fillAmount = player.sP / player.maxSP;
        }
    }
}
