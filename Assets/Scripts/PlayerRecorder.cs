using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerData
{
    int coin;
    int life;

    public PlayerData()
    {
        coin =0;
        life =5;
    }

    public PlayerData(int coin, int life)
    {
        this.coin = coin;
        this.life = life;
    }
}
public class PlayerRecorder
{
    PlayerData playerData;
    public PlayerRecorder()
    {
        FileInfo fi = new FileInfo(Application.dataPath + "/PlayerData.json");
        if(!fi.Exists)
        {
            File.WriteAllText(Application.dataPath + "/PlayerData.json", JsonUtility.ToJson(new PlayerData()));
        }
        else
        {
            playerData = LoadPlayerData();
        }
    }

    public void SavePlayerData(int coin, int life)
    {
        PlayerData playerData = new PlayerData(coin, life);
        File.WriteAllText(Application.dataPath + "/PlayerData.json", JsonUtility.ToJson(playerData));
    }
    public PlayerData LoadPlayerData()
    {
        FileInfo fi = new FileInfo(Application.dataPath + "/PlayerData.json");
        if(!fi.Exists)
        {
            File.WriteAllText(Application.dataPath + "/PlayerData.json", JsonUtility.ToJson(new DataList()));
        }
        string str = File.ReadAllText(Application.dataPath + "/PlayerData.json");
        PlayerData playerData = JsonUtility.FromJson<PlayerData>(str);
        return playerData;
    }
}
