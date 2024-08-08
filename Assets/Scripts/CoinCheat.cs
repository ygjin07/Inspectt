using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCheat : MonoBehaviour
{
    PlayerData playerData;
    PlayerRecorder playerRecorder = new PlayerRecorder();
    bool readyrefresh = false;

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
    }

    public void AddCoin()
    {
        playerData = playerRecorder.LoadPlayerData();
        playerData.coin += 10;
        playerRecorder.SavePlayerData(playerData);
    }

    public void refresh()
    {
        readyrefresh = true;
    }
}
