using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//制作者：佐伯
//内容：初期から決まっている(定数)カメラのパラメーター

[CreateAssetMenu(menuName = "Create ParameterTable/CameraTable", fileName = "CameraTable")]

public class CameraTable : ScriptableObject
{
    [Header("カメラのパラメーター")]

    [Tooltip("角度の変化割合")]
    public float addAngle;
    [Tooltip("高さの変化量")]
    public float addHeight;
    [Tooltip("高さの上限")]
    public float maxHeight;
    [Tooltip("高さの下限")]
    public float minHeight;

    //var camera = Resources.Load("CameraTable") as CameraTable;
    //fuga = camera.hoge;
}
