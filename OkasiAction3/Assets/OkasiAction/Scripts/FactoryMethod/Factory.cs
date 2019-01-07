using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者：佐伯
//内容：Factory Methodパターン インスタンス生成のための抽象クラス

public class Factory : MonoBehaviour
{
    public virtual void Create(string createType, Vector3 position)
    {
        Debug.Log("ファクトリー：positionのメソッドでの生成に失敗しました。");
    }
    public virtual void Create(string createType, Quaternion quaternion)
    {
        Debug.Log("ファクトリー：Quaternionのメソッドでの生成に失敗しました。");
    }
    public virtual void Create(string createType, Vector3 position, Quaternion quaternion)
    {
        Debug.Log("ファクトリー：position+Quaternionのメソッドでの生成に失敗しました。");
    }
    public virtual void Create(string createType, Transform transform)
    {
        Debug.Log("ファクトリー：transformありのメソッドでの生成に失敗しました。");
    }
    public virtual void Create(string createType, Vector3 position, Quaternion quaternion, Transform parent)
    {
        Debug.Log("ファクトリー：position+Quaternion+子オブジェクトのメソッドでの生成に失敗しました。");
    }
    public virtual void Create(string createType, Transform transform, Transform parent)
    {
        Debug.Log("ファクトリー：transform+子オブジェクトのメソッドでの生成に失敗しました。");
    }
    public virtual void Create(string createType, int itemSetType, Vector3 position, Quaternion quaternion)
    {
        Debug.Log("ファクトリー：アイテムセット+position+Quaternionのメソッドでの生成に失敗しました。");
    }
    public virtual void Create(string createType, int itemSetType, Transform transform)
    {
        Debug.Log("ファクトリー：アイテムセット+transformありのメソッドでの生成に失敗しました。");
    }
}