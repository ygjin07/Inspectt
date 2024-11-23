using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    [SerializeField]
    GameObject TutorialCheck;
    [SerializeField]
    GameObject ModeOption;
    [SerializeField]
    GameObject ModeCheck;
    PlayerData playerData; //배경음악, 효과음 볼륨을 저장할 변수
    PlayerRecorder playerRecorder = new PlayerRecorder();//플레이어 데이터를 가져오기위한 변수

    bool isTutorial = true;

    void Start()
    {
        playerData = playerRecorder.LoadPlayerData();

        bgmSlider.value = playerData.bgmVolume;
        effectSlider.value = playerData.effectVolume;
        soundManager.bgm.volume = bgmSlider.value;
        soundManager.effect.volume = effectSlider.value;

        OpenOption();

        isTutorial = playerData.Tutorial;
        TutorialCheck.SetActive(isTutorial);
    }

    // Update is called once per frame
    void Update()
    {
        soundManager.bgm.volume = bgmSlider.value;
        soundManager.effect.volume = effectSlider.value;
    }

    public void OpenOption()
    {
        if (playerData != null)
        {
            ModeOption.SetActive(playerData.unlockExtreme);
            ModeCheck.SetActive(playerData.ExtremeOnOff);
        }
    }

    public void ToggleTutorial()
    {
        TutorialCheck.SetActive(!TutorialCheck.activeSelf);
        isTutorial = TutorialCheck.activeSelf;
        playerData.Tutorial = isTutorial;
        playerRecorder.SavePlayerData(playerData);
    }

    public bool GetTutorialState()
    {
        return isTutorial;
    }

    public void ToggleMode()
    {
        ModeCheck.SetActive(!ModeCheck.activeSelf);
        playerData.ExtremeOnOff = ModeCheck.activeSelf;
        playerRecorder.SavePlayerData(playerData);
    }
}
