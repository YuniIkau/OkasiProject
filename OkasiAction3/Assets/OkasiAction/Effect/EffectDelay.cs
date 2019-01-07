using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectDelay : MonoBehaviour
{

    [SerializeField]
    GameObject particleObject;
    [SerializeField]
    float delayTime;
    void Start()
    {
        Invoke("ParticleActiveTrue", delayTime);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void ParticleActiveTrue()
    {
        particleObject.SetActive(true);
    }
}
