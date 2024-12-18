using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerData
{
    public int coin;
    public int life;
    public float bgmVolume;
    public float effectVolume;
    public bool decreasingCharactorType;
    public bool unlockExtreme;
    public bool Tutorial;
    public bool ExtremeOnOff;

    public PlayerData()
    {
        coin =0;
        life =5;
        bgmVolume =1;
        effectVolume =1;
        decreasingCharactorType = false;
        unlockExtreme = false;
        Tutorial = true;
        ExtremeOnOff = false;
    }

    public PlayerData(int coin, int life, float bgm, float effect, bool dCT, bool unlockExtreme, bool tuto, bool exOnoff)
    {
        this.coin = coin;
        this.life = life;
        this.bgmVolume = bgm;
        this.effectVolume = effect;
        this.decreasingCharactorType = dCT;
        this.unlockExtreme = unlockExtreme;
        Tutorial = tuto;
        ExtremeOnOff = unlockExtreme ? exOnoff : false;
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
    // public void SavePlayerData(int coin, int life, float bgm, float effect)
    // {
    //     PlayerData playerData = new PlayerData(coin, life, bgm, effect);
    //     File.WriteAllText(Application.dataPath + "/PlayerData.json", JsonUtility.ToJson(playerData));
    // }
    public void SavePlayerData(PlayerData playerData)
    {
        File.WriteAllText(Application.dataPath + "/PlayerData.json", JsonUtility.ToJson(playerData));
    }
    public PlayerData LoadPlayerData()
    {
        FileInfo fi = new FileInfo(Application.dataPath + "/PlayerData.json");
        if(!fi.Exists)
        {
            File.WriteAllText(Application.dataPath + "/PlayerData.json", JsonUtility.ToJson(new PlayerData()));
        }
        string str = File.ReadAllText(Application.dataPath + "/PlayerData.json");
        PlayerData data = JsonUtility.FromJson<PlayerData>(str);
        playerData = data;
        return playerData;  
    }
}
