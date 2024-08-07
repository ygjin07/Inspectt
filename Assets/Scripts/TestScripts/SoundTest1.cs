using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTest1 : MonoBehaviour
{
    
    [SerializeField]
    SoundManager soundManager;

    public void OnBGMClick0() {soundManager.PlayBGM(0,true);}
    public void OnBGMClick1() {soundManager.PlayBGM(1,true);}
    public void OnEffectClick0() {soundManager.PlayEffect(0);}
    public void OnEffectClick1() {soundManager.PlayEffect(1);}
    public void OnEffectClick2() {soundManager.PlayEffect(2);}
    public void OnEffectClick3() {soundManager.PlayEffect(3);}

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
