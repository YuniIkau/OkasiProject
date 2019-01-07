using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

//制作者：佐伯
//内容：初期から決まっている(定数)クレア(プレイヤ)のパラメーター

[CreateAssetMenu(menuName = "Create ParameterTable/PlayerTable", fileName = "PlayerTable")]
public class PlayerTable : ScriptableObject
{
    [Header("クレアのパラメーター")]
    [Space(10)]
    [Tooltip("HPの初期段階")]
    public float stageMaxHP0;
    [Tooltip("HPの最大値アップアイテム一回取得した時の値")]
    public float stageMaxHP1;
    [Tooltip("HPの最大値アップアイテム二回取得した時の値")]
    public float stageMaxHP2;
    [Tooltip("HPの最大値アップアイテム三回取得した時の値")]
    public float stageMaxHP3;
    [Tooltip("HPの回復量")]
    public float recoveryPoint;
    [Space(10)]
    [Tooltip("攻撃の初期段階")]
    public int stageAttack0;
    [Tooltip("攻撃の最大値アップアイテム一回取得した時の値")]
    public int stageAttack1;
    [Tooltip("攻撃の最大値アップアイテム二回取得した時の値")]
    public int stageAttack2;
    [Tooltip("攻撃の最大値アップアイテム三回取得した時の値")]
    public int stageAttack3;
    [Space(10)]
    [Tooltip("移動速度の初期段階")]
    public float stageSpeed0;
    [Tooltip("移動速度の最大値アップアイテム一回取得した時の値")]
    public float stageSpeed1;
    [Tooltip("移動速度の最大値アップアイテム二回取得した時の値")]
    public float stageSpeed2;
    [Tooltip("移動速度の最大値アップアイテム三回取得した時の値")]
    public float stageSpeed3;
    [Space(10)]
    [Tooltip("SPの増加値")]
    public float addSP;
    [Tooltip("SPの最大値")]
    public float maxSP;
    [Space(10)]
    [Tooltip("被ダメージ時の無敵時間")]
    public float unHitTime;
    [Space(10)]
    [Tooltip("回避距離")]
    public float evasionDist;
    [Tooltip("回避のブレーキの力")]
    public float evasionDistRate;
    [Space(10)]
    [Tooltip("ジャンプ力")]
    public float jumpPow;
    [Space(10)]
    [Tooltip("攻撃移動距離")]
    public　float[] attackMoveDist;
    [Tooltip("攻撃移動ブレーキの力")]
    public float[] attackMoveDistRate;
    [Space(10)]
    [Tooltip("ため時間")]
    public　float chargeTime;

    /***外部スクリプトでの使用方法***/
    //var player = Resources.Load("PlayerTable") as PlayerTable;
    //hoge = player.HP;
}
