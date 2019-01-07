using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//制作者：藤田
//内容：HPゲージの制御

public class HPSystem : MonoBehaviour
{
    //UIに表示するHPゲージ
    Image hpGreenImage;
    Image hpRedImage;
    //UIに表示するテキスト
    GameObject textHP;
    Text text;
    //プレイヤのパラメーター
    GameObject playerState;
    PlayerState player;
    float damageHP;
    void Start()
    {
        //playerのパラメーターを取得
        playerState = GameObject.FindGameObjectWithTag("Player");
        player = playerState.GetComponent<PlayerState>();
        damageHP = player.maxHP;
        //各UIの取得
        textHP = GameObject.FindGameObjectWithTag("HPText");
        hpGreenImage = GameObject.FindGameObjectWithTag("HP").GetComponent<Image>();
        hpRedImage = GameObject.FindGameObjectWithTag("HPRed").GetComponent<Image>();
    }
    void Update()
    {
        //HPのテキスト表示
        textHP.GetComponent<Text>().text = 
            ((int)player.hP).ToString() + "/" + ((int)player.maxHP).ToString();
        HPGageRed();
    }
    //HP赤ゲージ更新
    void HPGageRed()
    {
        if (damageHP >= player.hP)
        {
            damageHP -= 0.03f;
            hpRedImage.fillAmount = damageHP / player.maxHP;
        }
    }
    //HPゲージの更新(攻撃を受ける場合)
    public void Renovation(float damageHP)
    {
        this.damageHP = damageHP;
        hpGreenImage.fillAmount = player.hP / player.maxHP;
    }
    //HPゲージの更新(攻撃を受けない場合)
    public void Renovation()
    {
        this.damageHP = player.hP;
        hpGreenImage.fillAmount = player.hP / player.maxHP;
    }
}