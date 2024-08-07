using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource bgm;
    public AudioSource effect;

    [SerializeField]
    AudioClip[] bgmList;
    [SerializeField]
    AudioClip[] effectList;

    public void PlayBGM(int index, bool loop)
    {
        bgm.Stop();
        bgm.clip = bgmList[index];
        bgm.Play();
        bgm.loop = loop;
    }

    public void PlayEffect(int index)
    {
        effect.clip = effectList[index];
        effect.Play();
    }
}
