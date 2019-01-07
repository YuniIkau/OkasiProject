using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

//内容：タイトルUIすべて
public class TitleScript : MonoBehaviour
{
    
    //現在選択中のボタン
    GameObject button;

    //各オブジェクトの取得用
    GameObject FirstSelect;
    GameObject plessB;

    GameObject startImage;
    GameObject infoImage;
    GameObject quitImage;
    GameObject selectCursor;

    SceneMove sceneMove;

    bool selectBool = false;
    void Start()
    {
        //各オブジェクトの取得
        plessB = transform.GetChild(0).gameObject;
        startImage = transform.GetChild(2).gameObject;
        infoImage = transform.GetChild(3).gameObject;
        quitImage = transform.GetChild(4).gameObject;
        selectCursor = transform.GetChild(5).gameObject;
        //はじめにボタンイメージを非アクティブ化
        startImage.SetActive(false);
        infoImage.SetActive(false);
        quitImage.SetActive(false);
        //初期フォーカス
        EventSystem.current.SetSelectedGameObject(startImage);

        sceneMove = GameObject.FindGameObjectWithTag("GameController").GetComponent<SceneMove>();

        //確認用
        Debug.Log(plessB.name);
        Debug.Log(startImage.name);
    }

    void Update()
    {
        //現在の選択されているボタンを取得  
        button = EventSystem.current.currentSelectedGameObject;
        EventSystem.current.SetSelectedGameObject(button);
        if (selectBool)
        {
            this.ButtonSelect(button);
        }
        this.MenuButton();
    }
    //------------------------------------------------------

    //------------------------------------------------------
    //ボタン入力受け取り
    void MenuButton()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            //Bボタンを押したらテキストオブジェクトを非アクティブ化
            plessB.SetActive(false);
            //Bボタンを押した各ボタンイメージオブジェクトをアクティブ化
            startImage.SetActive(true);
            infoImage.SetActive(true);
            quitImage.SetActive(true);
            selectBool = true;
        }
    }
    //------------------------------------------------------
    void ButtonSelect(GameObject selected)
    {
        if (selected == startImage)
        {
            if (Input.GetButtonDown("Fire2"))
            {
                Debug.Log("スタート！！！！！");
                sceneMove.SceneMovie(0);
            }
        }
        if (selected == infoImage)
        {
            if (Input.GetButtonDown("Fire2"))
            {
                Debug.Log("セツメイ！！！！！");

            }
        }
        if (selected == quitImage)
        {
            if (Input.GetButtonDown("Fire2"))
            {
                Debug.Log("シュウリョウ！！！！！");
                Application.Quit();
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#else
		Application.Quit();
#endif
            }
        }

    }
}
