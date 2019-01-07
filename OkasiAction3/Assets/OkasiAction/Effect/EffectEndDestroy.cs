using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectEndDestroy : MonoBehaviour
{
    [SerializeField]
    ParticleSystem particleSystem;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //子のパーティクル再生終了時に自信のゲームオブジェクトを削除
        if (!particleSystem.isPlaying)
        {
            Destroy(this.gameObject);
        }
    }
}
