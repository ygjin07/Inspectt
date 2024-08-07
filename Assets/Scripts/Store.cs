using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Store : MonoBehaviour
{
    [SerializeField]
    PlayerRecorder playerRecorder = new PlayerRecorder();
    PlayerData playerData;
    [SerializeField]
    GameObject storePanel;

    [SerializeField]
    SoundManager soundManager;

    [SerializeField]
    TMP_Text lifeCostText;
    [SerializeField]
    TMP_Text coinText;

    public int lifeCost;
    // Start is called before the first frame update
    void Start()
    {
        playerData = playerRecorder.LoadPlayerData();
        lifeCost =(int)Mathf.Pow(2,playerData.life-5);
        lifeCostText.text = lifeCost.ToString();
        LoadCoin();
    }

    public void BuyDecreasingCharactorType()
    {
        if(!playerData.decreasingCharactorType)
        {
            //가격: 5원
            if(playerData.coin>=5)
            {
                playerData.coin -= 5;
                playerData.decreasingCharactorType = true;
                LoadCoin();
                soundManager.PlayEffect(2);
                playerRecorder.SavePlayerData(playerData);
            }

            else
            {
                soundManager.PlayEffect(3);
            }
        }
    }

    public void BuyLifeUpgrade()
    {
        //가격: 2^업그레이드횟수
        if(playerData.coin >= lifeCost)
        {
            playerData.coin -= lifeCost;
            playerData.life +=1;
            lifeCost *= 2;
            lifeCostText.text = lifeCost.ToString();
            LoadCoin();
            soundManager.PlayEffect(2);
            playerRecorder.SavePlayerData(playerData);
        }

        else
        {
            soundManager.PlayEffect(3);
        }
    }

    public void BuyMod()
    {
        //가격: 100원
        if(!playerData.unlockExtreme && playerData.coin>=100)
        {
            playerData.coin -= 100;
            playerData.unlockExtreme = true;
            LoadCoin();
            soundManager.PlayEffect(2);
            playerRecorder.SavePlayerData(playerData);
        }

        else
        {
            soundManager.PlayEffect(3);
        }
    }

    public void BuyGamble()
    {
        
    }

    public void LoadCoin()
    {
        coinText.text = "x "+ playerData.coin;
    }
}
