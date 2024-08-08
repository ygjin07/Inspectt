using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

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
                soundManager.PlayEffect(2);
                playerRecorder.SavePlayerData(playerData);
                LoadCoin();
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
            soundManager.PlayEffect(2);
            playerRecorder.SavePlayerData(playerData);
            LoadCoin();
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
            soundManager.PlayEffect(2);
            playerRecorder.SavePlayerData(playerData);
            LoadCoin();
        }

        else
        {
            soundManager.PlayEffect(3);
        }
    }

    public void BuyGamble()
    {
        if (!playerData.unlockExtreme && playerData.coin >= 3)
        {
            playerData.coin -= 3;
        playerData.coin += Random.Range(0, 6);
        soundManager.PlayEffect(2);
        playerRecorder.SavePlayerData(playerData);
        LoadCoin();
        }
        else
        {
            soundManager.PlayEffect(3);
        }
    }

    public void LoadCoin()
    {
        playerData = playerRecorder.LoadPlayerData();
        coinText.text = "x "+ playerData.coin;
    }
}
