using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    [SerializeField]
    GameObject gameOverPanel;
    [SerializeField]
    TMP_InputField name_input;
    [SerializeField]
    TMP_Text score_text;

    int final_socre = 0;

    ScoreBoard scoreboard = new ScoreBoard();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActiveGameOverPanel()
    {
        gameOverPanel.SetActive(true);
    }

    public void SetFinalScore(int score)
    {
        final_socre = score;
        score_text.text = "score : " + final_socre.ToString();
    }

    public void NextBtn()
    {
        scoreboard.SaveScore(final_socre, name_input.text);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
