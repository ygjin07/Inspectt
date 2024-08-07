using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour
{
    [SerializeField]
    PlayerRecorder playerRecorder;
    PlayerData playerData;
    // Start is called before the first frame update
    void Start()
    {
        playerData = playerRecorder.LoadPlayerData();
    }

    public void BuyDecreasingCharactorType()
    {
        if(!playerData.decreasingCharactorType)
        {
            playerData.decreasingCharactorType = true;
        }
    }

    public void BuyLifeUpgrade()
    {
        playerData.life +=1;
    }

    public void BuyLevelUnlock()
    {
        if(playerData.unlockLevel <2)
        {
            playerData.unlockLevel +=1;
        }
    }

    public void BuyGamble()
    {
        
    }
}
