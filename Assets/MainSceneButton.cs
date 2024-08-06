using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneButton : MonoBehaviour
{
    public void OnClickStart()
    {
        Debug.Log("시작");
        //SceneManager.LoadScene("");
    }

    public void OnClickScoreBoard()
    {
        Debug.Log("스코어보드");
        
    }

    public void OnClickExit()
    {
        Debug.Log("종료");
        // UnityEditor.EditorApplication.isPlaying = false;
        // Application.Quit();
    }
}
