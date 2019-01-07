using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//作成者：佐伯
//内容：UIの挙動

public class UIAnimation : MonoBehaviour
{
    bool thisAlphaAdd = false;
    int start = 0;
    public virtual void FadeIn(Image image, float add)
    {
        image.color -= Time.deltaTime * new Color(0, 0, 0, add);
        if (image.color.a < 0)
        {
            Destroy(image.gameObject);
        }
    }
    public virtual void FadeOut(Image image, float add)
    {
        image.color += Time.deltaTime * new Color(0, 0, 0, add);
    }
    public virtual void AlphaMove(Image image, float add, float max, float min, bool thisAdd)
    {
        if (start == 0)
        {
            thisAlphaAdd = thisAdd;
        }
        start = 1;
        image.color = thisAlphaAdd == true ?
            image.color += Time.deltaTime * new Color(0, 0, 0, add) :
            image.color -= Time.deltaTime * new Color(0, 0, 0, add);
        if (image.color.a >= max)
        {
            thisAlphaAdd = false;
        }
        if (image.color.a <= min)
        {
            thisAlphaAdd = true;
        }
    }
    public virtual void AlphaMove(Text text, float add, float max, float min, bool thisAdd)
    {
        if (start == 0)
        {
            thisAlphaAdd = thisAdd;
        }
        start = 1;
        text.color = thisAlphaAdd == true ? 
            text.color += Time.deltaTime * new Color(0, 0, 0, add) :
            text.color -= Time.deltaTime * new Color(0, 0, 0, add);
        if (text.color.a >= max)
        {
            thisAlphaAdd = false;
        }
        if (text.color.a <= min)
        {
            thisAlphaAdd = true;
        }
    }
}
