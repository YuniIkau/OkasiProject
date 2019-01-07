using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者：藤田
//内容：一時停止

public class PauseScript : MonoBehaviour
{
    //　ポーズした時に表示するUI
    [SerializeField]
    private GameObject pauseUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            //　ポーズUIのアクティブ、非アクティブを切り替え
            pauseUI.SetActive(!pauseUI.activeSelf);

            //　ポーズUIが表示されてる時は停止
            if (pauseUI.activeSelf)
            {
                Time.timeScale = 0.0f;
            }
            //　ポーズUIが表示されてなければ通常通り進行
            else
            {
                Time.timeScale = 1.0f;
            }
        }
    }
}
