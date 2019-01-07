using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using System.IO;
using System.Text;

/**メニュー又はAlt+Sでテンプレートスクリプトの生成**/

public class CreateScript : EditorWindow
{
    //生成するフォルダの指定
    static string templatePath = "Assets/OkasiAction/Reference/Template.txt";
    //生成するスクリプトのデフォルトの名前
    static string scriptName = "NewScript";

    [MenuItem("Assets/Create/CreateTemplateScript &s", false,0)]
    static public void Open()
    {
        GetWindow<CreateScript>(true, "CreateScene");
    }

    private void OnGUI()
    {
        //名前を付けるTextFiledにフォーカスを当てる
        GUI.SetNextControlName("ScriptName");
        EditorGUI.FocusTextInControl("ScriptName");

        //スクリプト名を入力
        scriptName = EditorGUILayout.TextField("ScriptName", scriptName);
        //コンパイル中は操作できないように
        EditorGUI.BeginDisabledGroup(EditorApplication.isCompiling);

        //Createボタンを押してスクリプト生成し、ウィンドウを閉じる
        if (GUILayout.Button("Create")) 
        {
            CreateNewScript();
            Close();
        }
        EditorGUI.EndDisabledGroup();
    }

    static void CreateNewScript()
    {
        //テンプレートを読み込んでtempに格納
        StreamReader reader = new StreamReader(templatePath, Encoding.GetEncoding("Shift_JIS"));
        string template = reader.ReadToEnd();
        reader.Close();

        //テンプレート中の文字列"#SCRIPTNAME#"をスクリプト名に置換
        string scriptText = template.Replace("#SCRIPTNAME#", scriptName);

        //csファイルとしてScriptsフォルダに保存
        File.WriteAllText("Assets/OkasiAction/Scripts/" + scriptName + ".cs", scriptText, Encoding.UTF8);

        AssetDatabase.Refresh();
    }
}