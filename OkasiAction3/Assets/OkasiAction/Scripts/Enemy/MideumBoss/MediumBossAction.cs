using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class MediumBoss : MonoBehaviour
{
    public void MediumBossAction()
    {
        //今現在は使わない
        //今後使うかも？
        //if (currentAnimatorInfo.IsName("移動"))
        //{
        //}
        //else if (currentAnimatorInfo.IsName("待機"))
        //{
        //}
        //else if (currentAnimatorInfo.IsName("被ダメージ"))
        //{
        //}
        //else if (currentAnimatorInfo.IsName("威嚇"))
        //{
        //}
        //else if (currentAnimatorInfo.IsName("攻撃1"))
        //{

        //}
        //else if (currentAnimatorInfo.IsName("死亡"))
        //{
        //    deadFlag = true;
        //    this.UnAttackTimeReset();
        //}
        //else
        if (currentAnimatorInfo.IsName("死亡後"))
        {
            Destroy(this.gameObject);
        }
    }
}
