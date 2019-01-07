using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//制作者：佐伯
//内容：プレイヤがゲーム内で保持する(変更がゲーム内で行われる)変数の置き場

public class PlayerState : MonoBehaviour
{
    [HideInInspector]
    public float hP;
    [HideInInspector]
    public float maxHP;
    [HideInInspector]
    public int attack;
    [HideInInspector]
    public float speed;
    [HideInInspector]
    public float sP;
    [HideInInspector]
    public float maxSP;
    [HideInInspector]
    public float unHitTime;
    [HideInInspector]
    public float evasionDistNow;
    [HideInInspector]
    public bool firstDamage;
    [HideInInspector]
    public float[] attackMoveDistNow;
    [HideInInspector]
    public float chargeTimeNow;

    //各パラメーターの初期化
    private void Awake()
    {
        //ターブルの取得
        var playerTable = Resources.Load("PlayerTable") as PlayerTable;
        //テーブルを使用した初期化
        hP = playerTable.stageMaxHP0;
        maxHP = playerTable.stageMaxHP0;
        attack = playerTable.stageAttack0;
        speed = playerTable.stageSpeed0;
        sP = playerTable.maxSP;
        maxSP = playerTable.maxSP;
        //回避距離初期化
        evasionDistNow = playerTable.evasionDist;
        //初回ダメージ初期化
        firstDamage = true;
        //攻撃移動距離初期化
        attackMoveDistNow = new float[3];
        for (int i = 0; i < playerTable.attackMoveDist.Length; ++i)
        {
            attackMoveDistNow[i] = playerTable.attackMoveDist[i];
        }
        //ため時間初期化
        chargeTimeNow = playerTable.chargeTime;
        //現在の無敵時間を0に指定
        unHitTime = 0;
    }
}
