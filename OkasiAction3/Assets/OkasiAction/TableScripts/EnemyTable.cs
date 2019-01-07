using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//制作者：佐伯
//内容：初期から決まっている雑魚敵(アリ)のパラメーター

[CreateAssetMenu(menuName = "Create ParameterTable/EnemyTable", fileName = "EnemyTable")]
public class EnemyTable : ScriptableObject
{
    [Header("敵のパラメーター")]
    [Header("Normalアリのパラメーター")]
    [Tooltip("Normalアリの最大HP")]
    public float normalMaxHP;
    [Tooltip("Normalアリの攻撃力")]
    public int normalAttack;
    [Tooltip("Normalアリの移動速度")]
    public float normalSpeed;
    [Tooltip("Normalアリの攻撃不能時間")]
    public float normalUnAttackTime;


    [Header("Armorアリのパラメーター")]
    [Tooltip("Armorアリの最大HP")]
    public float armorMaxHP;
    [Tooltip("Armorアリの攻撃力")]
    public int armorAttack;
    [Tooltip("Armorアリの移動速度")]
    public float armorSpeed;
    [Tooltip("Armorアリの攻撃不能時間")]
    public float armorUnAttackTime;

    [Header("Shogunアリのパラメーター")]
    [Tooltip("Shogunアリの最大HP")]
    public float shogunMaxHP;
    [Tooltip("Shogunアリの攻撃力")]
    public int shogunAttack;
    [Tooltip("Shogunアリの移動速度")]
    public float shogunSpeed;
    [Tooltip("Shogunアリの攻撃不能時間")]
    public float shogunUnAttackTime;

    [Header("Thornアリのパラメーター")]
    [Tooltip("Thornアリの最大HP")]
    public float thornMaxHP;
    [Tooltip("Thornアリの攻撃力")]
    public int thornAttack;
    [Tooltip("Thornアリの移動速度")]
    public float thornSpeed;
    [Tooltip("Thornアリの攻撃不能時間")]
    public float thornUnAttackTime;

    [Header("ボスアリのパラメーター")]
    [Tooltip("ボスアリの最大HP")]
    public float bossMaxHP;
    [Tooltip("ボスアリの攻撃力")]
    public int bossAttack;
    [Tooltip("ボスアリの移動速度")]
    public float bossSpeed;
    [Tooltip("ボスアリアリの攻撃不能時間")]
    public float bossUnAttackTime;

    [Tooltip("被ダメージ時の無敵時間")]
    public float unHitTime;

    /***外部スクリプトでの使用方法***/
    //var enemy = Resources.Load("EnemyTable") as EnemyTable;
    //hoge = enemy.HP;
}
