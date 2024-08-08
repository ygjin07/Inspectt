using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCheat : MonoBehaviour
{
    PlayerData playerData;
    PlayerRecorder playerRecorder = new PlayerRecorder();
    bool readyrefresh = false, cheat_coin = false;

    // Start is called before the first frame update
    void Start()
    {
        playerData = playerRecorder.LoadPlayerData();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R) && readyrefresh)
        {

            playerRecorder.SavePlayerData(new PlayerData());
        }
        else if(Input.GetMouseButtonDown(0))
        {
            readyrefresh = false;
        }
        
        if(Input.GetKeyDown(KeyCode.C) && cheat_coin)
        {
            playerData = playerRecorder.LoadPlayerData();
            playerData.coin += 10;
            playerRecorder.SavePlayerData(playerData);
        }
        else if (Input.GetMouseButtonDown(0))
        {
            cheat_coin = false;
        }
    }

    public void AddCoin()
    {
        cheat_coin = true;
    }

    public void refresh()
    {
        readyrefresh = true;
    }
}
