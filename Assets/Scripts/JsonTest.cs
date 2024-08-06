using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonTest : MonoBehaviour
{
    [SerializeField]
    ScoreBoard scoreBoard = new ScoreBoard();
    // Start is called before the first frame update
    void Start()
    {
        scoreBoard.SaveScore(1,"1");
        scoreBoard.SaveScore(2,"2");
        scoreBoard.SaveScore(3,"3");

        DataList datas = scoreBoard.LoadScore();
        Debug.Log("loadScore");
        Debug.Log("-------");
        Debug.Log(datas.datas[0].name);
        for(int i =0; i<datas.datas.Count; i++)
        {
            Debug.Log(datas.datas[i].name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
