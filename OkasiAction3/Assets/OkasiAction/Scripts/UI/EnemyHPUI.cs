using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//内容：敵HPゲージの制御
//現状ほぼ表示のみ
public class EnemyHPUI : MonoBehaviour
{


    //Enemyの値を取得
    EnemyState enemyState;
    //雑魚
    float normalNowHP;
    float normalMaxHP;
    //中ボス
    float shogunNowHP;
    float shogunMaxHP;
    float armorNowHP;
    float armorMaxHP;
    float thornNowHP;
    float thornMaxHP;
    //ボス
    float bossNowHP;
    float bossMaxHP;

    //HP表示用スライダー
    GameObject enemyHPGage;
    Slider hpSlider;
	
	void Start ()
    {
        //自身のルートに取り付けている敵のステータス取得
        enemyState = transform.root.GetComponent<EnemyState>();
        
        hpSlider = this.GetComponent<Slider>();
        //値の取得
        normalMaxHP = 10.0f;//(仮)
        //normalMaxHP = enemyState.normalHP;
        normalNowHP = normalMaxHP;
        
        /*敵ステータスの取得がうまくいってない…っぽい
         どうにかして親のステータスを持ってきたい*/
    }
	
	void Update ()
    {
        //カメラと同じ向きに設定
        transform.rotation = Camera.main.transform.rotation;
        //HPゲージ更新
        UpdateZakoHP();
        
    }
    //雑魚用
    void UpdateZakoHP()
    {
        //スライダーの値0～1の間になるように比率を計算
        hpSlider.value = normalNowHP / normalMaxHP;
    }
    //ボス用
    void UpdateBossHP()
    {
        //スライダーの値0～1の間になるように比率を計算
        hpSlider.value = bossNowHP / bossMaxHP;
    }
    //中ボス用
    void UpdateShogunHP()
    {
        //スライダーの値0～1の間になるように比率を計算
        hpSlider.value = shogunNowHP / shogunMaxHP;
    }
    void UpdateArmorHP()
    {
        //スライダーの値0～1の間になるように比率を計算
        hpSlider.value = armorNowHP / armorMaxHP;
    }
    void UpdateThornHP()
    {
        //スライダーの値0～1の間になるように比率を計算
        hpSlider.value = thornNowHP / thornMaxHP;
    }
}
