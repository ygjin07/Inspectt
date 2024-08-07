using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionPanel : MonoBehaviour
{
    [SerializeField]
    Slider bgmSlider;
    [SerializeField]
    Slider effectSlider;
    [SerializeField]
    SoundManager soundManager;
    PlayerData playerData; //배경음악, 효과음 볼륨을 저장할 변수
    PlayerRecorder playerRecorder = new PlayerRecorder();//플레이어 데이터를 가져오기위한 변수

    void Start()
    {
        playerData = playerRecorder.LoadPlayerData();

        bgmSlider.value = playerData.bgmVolume;
        effectSlider.value = playerData.effectVolume;
    }

    // Update is called once per frame
    void Update()
    {
        soundManager.bgm.volume = bgmSlider.value;
        soundManager.effect.volume = effectSlider.value;
    }
}
