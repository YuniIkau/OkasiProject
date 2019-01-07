using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WariningScript : UIAnimation
{
    Image image;
    public  bool trigger_on;
    float cnt;

	// Use this for initialization
	void Start () {
        this.image = this.gameObject.GetComponentInChildren<Image>();
        trigger_on = false;

    }
	
	// Update is called once per frame
	void Update () {
        if(trigger_on)
        {
            AlphaMove(this.image, 2.0f, 1, 0, true);
            cnt += 1 * Time.deltaTime;
            if(cnt>=5)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
