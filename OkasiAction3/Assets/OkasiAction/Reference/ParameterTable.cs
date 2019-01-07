using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create ParameterTable/BaseTable", fileName = "ParameterTable")]
public class ParameterTable : ScriptableObject
{
    /****表示法の参考****/
    /* [Header("見やすいように表題を入れる")]
     * [SerializeField, Range(0, 10)]
     * public int hoge;
     * [TextArea(3, 5)] ()には最大と最小の行数を指定
     * public string hoge;
     * [Space(10)] ()には縦に間を開けるピクセル数を指定
     * public int hoge;
     * [Tooltip("ここに説明を書く")]
     * public int hoge;
     * [HideInInspector] インスペクターに表示しない
     * public int hoge;
     */
    /***外部スクリプトでの使用方法***/
    //var Base = Resources.Load("ParameterTable") as ParameterTable;
    //fuga = Base.hoge;
}