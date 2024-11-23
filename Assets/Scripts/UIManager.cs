using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    InputController inputController;
    [SerializeField]
    Slider timeSlider;
    [SerializeField]
    Image timeSliderFill;

    [SerializeField]
    TextMeshProUGUI timeText;
    [SerializeField]
    TextMeshProUGUI scoreText;
    [SerializeField]
    TextMeshProUGUI coinText;
    //[SerializeField]
    //TextMeshProUGUI lifeText;

    //Hotfix_esc
    [SerializeField]
    GameObject pausedPanel;
    bool isPaused;
    [SerializeField]
    SoundManager soundManager;

    public float maxTime;
    public float currentTime;
    public float textTime;


    [SerializeField]
    GameObject Life;
    [SerializeField]
    GameObject HeartPrefab;

    public List<GameObject> hearts;

    void Awake()
    {
        maxTime = inputController.limit_time;
        currentTime = inputController.time;

        Time.timeScale = 1f;
        pausedPanel.SetActive(false);
        isPaused = false;
    }

    //test
    void Update()
    {
        maxTime = inputController.limit_time;
        currentTime = inputController.time;
        textTime = Mathf.Floor(currentTime*100f)/100f;

        if(!isPaused && Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("퍼즈1");
            OnClickPaused();
        }
        else if(isPaused && Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("퍼즈2");
            OnClickResume();
        }
    }

    void LateUpdate()
    {
        // Debug.Log("maxTime: "+maxTime);
        // Debug.Log("currentTime: "+currentTime);
        timeSlider.value = currentTime/maxTime; //타이머 바
        timeSliderFill.color = Color.red * (1- timeSlider.value) + Color.green * timeSlider.value;
        timeText.text = textTime + "s"; //타이머 텍스트
        scoreText.text = "Score: " + inputController.score;
        coinText.text = "Coin: " + inputController.coin;
        //lifeText.text = "Life: " + inputController.life;
    }

    public void UnActiveHeart(int idx)
    {
        hearts[idx].gameObject.SetActive(false);
    }

    public void InitLife()
    {
        for (int i = 0; i < inputController.life; i++)
        {
            hearts.Add(Instantiate(HeartPrefab, Life.transform));
        }
    }

    public void OnClickPaused()
    {
        Time.timeScale = 0f;
        isPaused = true;
        pausedPanel.SetActive(true);
        soundManager.bgm.Pause();
        pausedPanel.SetActive(true);
	}
    
    public void OnClickResume()
    {
    	Time.timeScale = 1f;
        isPaused = false;
        pausedPanel.SetActive(false);
        soundManager.bgm.UnPause();
    	pausedPanel.SetActive(false);
	}
}
