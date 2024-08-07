using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

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

    [SerializeField]
    SoundManager soundManager;

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
        soundManager.PlayBGM(1,true);

        gameOverPanel.SetActive(true);
    }

    public void SetFinalScore(int score)
    {
        final_socre = score;
        score_text.text = "score : " + final_socre.ToString();
    }

    public void RetryBtn()
    {
        scoreboard.SaveScore(final_socre, name_input.text);

        soundManager.bgm.Stop();

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenuBtn()
    {
        scoreboard.SaveScore(final_socre, name_input.text);
        SceneManager.LoadScene("MainScene");
    }
}
