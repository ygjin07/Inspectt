using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Unity.VisualScripting;

[System.Serializable]
public class DataList
{
    public List<Data> datas;

    public DataList()
    {
        datas = new List<Data>();
    }
}

[System.Serializable]
public class Data
{
    public int score;
    public string name;
    public Data(int score, string name){
    	this.score = score;
        this.name = name;
    }
}
public class ScoreBoard
{
    DataList datas = new DataList();
    
    public ScoreBoard()
    {
        FileInfo fi = new FileInfo(Application.dataPath + "/TestJson.json");
        if(!fi.Exists)
        {
            File.WriteAllText(Application.dataPath + "/TestJson.json", JsonUtility.ToJson(new DataList()));
        }
        else
        {
            datas = LoadScore();
        }
    }

    public void SaveScore(int score, string name)
    {
        Data data = new Data(score, name);
        datas.datas.Add(data);

        datas.datas.Sort((b,a)=>a.score.CompareTo(b.score));
        Debug.Log(JsonUtility.ToJson(datas));

        File.WriteAllText(Application.dataPath + "/TestJson.json", JsonUtility.ToJson(datas));
    }

    public DataList LoadScore()
    {
        string str = File.ReadAllText(Application.dataPath + "/TestJson.json");
        DataList datas = JsonUtility.FromJson<DataList>(str);
        return datas;
    }
}