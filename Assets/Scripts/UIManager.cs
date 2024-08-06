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
    TextMeshProUGUI timeText;
    [SerializeField]
    TextMeshProUGUI scoreText;
    [SerializeField]
    //TextMeshProUGUI lifeText;
    
    public float maxTime;
    public float currentTime;
    public float textTime;


    [SerializeField]
    GameObject Life;

    public Image[] hearts;

    void Awake()
    {
        hearts = Life.GetComponentsInChildren<Image>();
        maxTime = inputController.limit_time;
        currentTime = inputController.time;
    }

    //test
    void Update()
    {
        maxTime = inputController.limit_time;
        currentTime = inputController.time;
        textTime = Mathf.Floor(currentTime*100f)/100f;
    }

    void LateUpdate()
    {
        // Debug.Log("maxTime: "+maxTime);
        // Debug.Log("currentTime: "+currentTime);
        timeSlider.value = currentTime/maxTime; //타이머 바
        timeText.text = textTime + "s"; //타이머 텍스트
        scoreText.text = "Score: " + inputController.score;
        //lifeText.text = "Life: " + inputController.life;
    }

    public void UnActiveHeart(int idx)
    {
        hearts[idx].gameObject.SetActive(false);
    }
}
