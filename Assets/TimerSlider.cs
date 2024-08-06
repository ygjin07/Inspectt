using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TimerSlider : MonoBehaviour
{
    [SerializeField]
    Slider slider;

    [SerializeField]
    TextMeshProUGUI text;
    
    public float maxTime;
    public float currentTime;
    public float textTime;

    void Awake()
    {
        maxTime = 10f;
        currentTime = 10f;
    }

    //test
    void Update()
    {
        currentTime -= Time.deltaTime;

        textTime = Mathf.Floor(currentTime*100f)/100f;
    }

    void LateUpdate()
    {
        slider.value = currentTime/maxTime;
        text.text = textTime + "s";
    }
}
