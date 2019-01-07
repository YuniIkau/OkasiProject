using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//これを継承してゲープロの汎用タスクのようにも使えるよ

[CreateAssetMenu(menuName = "Create ParameterTable/BaseCharTable", fileName = "CharTable")]

public class CharTable : ParameterTable
{
    public float HP;
    public float MaxHP;
    public int Attack;
    public float Agility;
}
