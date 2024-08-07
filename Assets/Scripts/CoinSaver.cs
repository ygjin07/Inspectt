using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class CoinData
{
    public int coin = 0;
    public CoinData(int coin)
    {
        this.coin = coin;
    }
}

public class CoinSaver
{
    CoinData coin_data;

    public CoinSaver()
    {
        FileInfo fi = new FileInfo(Application.dataPath + "/CoinJson.json");
        if (!fi.Exists)
        {
            File.WriteAllText(Application.dataPath + "/CoinJson.json", JsonUtility.ToJson(new DataList()));
        }
        else
        {
            coin_data = LoadCoin();
        }
    }

    public void SaveCoin(int coin)
    {
        CoinData data = new CoinData(coin);

        File.WriteAllText(Application.dataPath + "/CoinJson.json", JsonUtility.ToJson(data));
    }

    public CoinData LoadCoin()
    {
        FileInfo fi = new FileInfo(Application.dataPath + "/CoinJson.json");
        if (!fi.Exists)
        {
            File.WriteAllText(Application.dataPath + "/CoinJson.json", JsonUtility.ToJson(new CoinData(0)));
        }
        string str = File.ReadAllText(Application.dataPath + "/CoinJson.json");
        CoinData data = JsonUtility.FromJson<CoinData>(str);
        return data;
    }
}
