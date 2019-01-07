using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//制作者：佐伯
//内容：敵がゲーム内で保持する(変更がゲーム内で行われる)変数の置き場

public class EnemyState : MonoBehaviour
{

    [HideInInspector]
    public float normalHP;
    [HideInInspector]
    public float armorHP;
    [HideInInspector]
    public float shogunHP;
    [HideInInspector]
    public float shogunHalfHP;
    [HideInInspector]
    public float thornHP;
    [HideInInspector]
    public float bossHP;
    [HideInInspector]
    public float unHitTime;

    //各パラメーターの初期化
    private void Awake()
    {
        var enemy = Resources.Load("EnemyTable") as EnemyTable;
        normalHP = enemy.normalMaxHP;
        armorHP = enemy.armorMaxHP;
        shogunHP = enemy.shogunMaxHP;
        shogunHalfHP = enemy.shogunMaxHP / 2;
        thornHP = enemy.thornMaxHP;
        bossHP = enemy.bossMaxHP;
        unHitTime = 0;
    }
}