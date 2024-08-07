using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkData
{
    public string dialogue;
    public List<TalkEventDefault> events = new List<TalkEventDefault>();

    public TalkData(string d)
    {
        dialogue = d;
    }

    public TalkData(string d, TalkEventDefault[] evt)
    {
        dialogue = d;
        foreach(TalkEventDefault e in evt)
        {
            events.Add(e);
        }
    }
}

public class TalkEventDefault
{
    public virtual void DoEvent()
    {

    }
}

public class TalkEventMoveChat : TalkEventDefault
{
    float xsize = 0, ysize = 0;
    Vector2 pos = Vector2.zero;
    RectTransform rt;

    public TalkEventMoveChat(float xs, float ys, float xp, float yp, RectTransform rectTransform)
    {
        xsize = xs;
        ysize = ys;
        pos = new Vector2(xp, yp);
        rt = rectTransform;
    }

    public override void DoEvent()
    {
        rt.anchoredPosition = pos;
        rt.sizeDelta = new Vector2(xsize, ysize);
    }
}

public class TalkEventSetActiveObject : TalkEventDefault
{
    GameObject AObj;
    bool active;

    public TalkEventSetActiveObject(GameObject obj, bool a)
    {
        AObj = obj;
        active = a;
    }

    public override void DoEvent()
    {
        AObj.SetActive(active);
    }
}
