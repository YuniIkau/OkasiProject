using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/**EditにPrefabのApplyをする項目の追加、ショートカットAlt+Aでも可能**/

public class PrefabApply
{
    //MenuのEditに追加
    [MenuItem("Edit/PrefabApply &a")]
    static void Apply()
    {
        //実際にここでApplyする
        EditorApplication.ExecuteMenuItem("GameObject/Apply Changes To Prefab");
    }
}