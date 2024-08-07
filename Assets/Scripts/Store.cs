using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour
{
    [SerializeField]
    PlayerRecorder playerRecorder;
    PlayerData playerData;
    // Start is called before the first frame update
    void Start()
    {
        playerData = playerRecorder.LoadPlayerData();
    }

    public void OnClickSomething1()
    {

    }

    public void OnClickSomething2()
    {

    }

    public void OnClickSomething3()
    {

    }

}
