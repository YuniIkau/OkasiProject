using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/**Prefabの階層を全て表示するView**/

public class PrefabView : EditorWindow
{
    //Menuへの追加
    [MenuItem("Window/PrefabView")]
    static void Show()
    {
        //Viewの表示
        EditorWindow.GetWindow<PrefabView>();
    }

    void OnGUI()
    {
        //何かしらのGameObjectが指定されていてそれがPrefabなら
        if (Selection.activeGameObject != null &&
            PrefabUtility.GetPrefabType(Selection.activeGameObject) == PrefabType.Prefab)
        {
            //選択しているPrefabの全ての階層の取得
            var root = PrefabUtility.FindPrefabRoot(Selection.activeGameObject);
            //表示
            FoldOutRecursive(root.transform);
        }
        //windowの更新
        Repaint();
    }

    void FoldOutRecursive(Transform t)
    {
        //インデントの調整
        EditorGUI.indentLevel++;
        //表示
        EditorGUILayout.Foldout(true, t.name);
        foreach (Transform c in t)
        {
            FoldOutRecursive(c);
        }
        //上の親からの再度表示するときのインデント調整
        EditorGUI.indentLevel--;
    }
}