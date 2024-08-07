using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource bgm;
    public AudioSource effect;

    [SerializeField]
    AudioClip[] bgmList;
    [SerializeField]
    AudioClip[] effectList;

    //유저가 설정한 볼륨으로 맞추기위해 필요한 변수
    PlayerData playerData; //가져온 볼륨을 담을 변수
    PlayerRecorder playerRecorder = new PlayerRecorder(); //플레이어 데이터를 가져올 변수

    void Start()
    {
        playerData = playerRecorder.LoadPlayerData();
        bgm.volume = playerData.bgmVolume;
        effect.volume = playerData.effectVolume;
    }

    void OnDestroy()
    {
        playerData.bgmVolume = bgm.volume;
        playerData.effectVolume = effect.volume;
        playerRecorder.SavePlayerData(playerData);
    }
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
