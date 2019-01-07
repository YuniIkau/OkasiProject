using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//制作者：佐伯
//内容：各シーンへの移動

public class SceneMove : MonoBehaviour
{
    GameController gameController;
    //シーンの名前
    enum SceneName
    {
        タイトル,
        お菓子の国,
        洞窟,
        エンディング,
        ムービー
    }
    SceneName sceneName;
    //シーンを次に移動させるかのフラグ
    bool sceneMoveFlag;
    //ムービーシーンに移動するときに元のシーンがどれだったか保存しておく
    int sceneSava;

    void Start()
    {
        gameController = GetComponent<GameController>();
        sceneMoveFlag = false;
    }

    void Update()
    {
        //シーンの移動フラグが立ってるときのみ先に行く
        if (false == sceneMoveFlag)
        {
            return;
        }
        //シーン移動(Asyncは読み込みが終わってから移動するタイプのもの)
        SceneManager.LoadSceneAsync((int)sceneName);
        sceneMoveFlag = false;
    }

    //次のシーンへの移動
    public void SceneNext()
    {
        sceneMoveFlag = true;
        //現在のシーンがムービーシーンではないとき
        if (!(SceneManager.GetActiveScene().buildIndex == System.Enum.GetValues(typeof(SceneName)).Length - 1))
        {
            //一つ先のシーンへ移動先を変更する
            sceneName++;
        }
        //ムービーシーンのとき
        else
        {
            //セーブしたシーンから一つ先のシーンへ移動先を変更する
            sceneSava++;
            sceneName = (SceneName)sceneSava;
        }
        //シーンがエンディングならタイトルに戻る
        if (sceneName == (SceneName)System.Enum.GetValues(typeof(SceneName)).Length - 1)
        {
            sceneName = SceneName.タイトル;
            return;
        }
    }

    /*ムービーシーンへの移動
    int movieNumは何番目のムービーを流すか*/
    public void SceneMovie(int movieNum)
    {
        //既にムービーシーンなら何もしない
        if (sceneName == SceneName.ムービー) 
        {
            return;
        }
        //シーン移動のフラグを立てる
        sceneMoveFlag = true;
        //何番目のムービーを流すのか値を取得する
        gameController.movieNum = movieNum;
        //現在のシーンを保存しておきムービーから戻るときに使用する
        sceneSava = SceneManager.GetActiveScene().buildIndex;
        //移動先をムービーシーンへ変更
        sceneName = SceneName.ムービー;
    }
}
