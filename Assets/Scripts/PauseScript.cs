using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    // Start is called before the first frame update
    private bool isPause;
    public GameObject _pauseScreen;
    
    public void GamePause()
    {
        if(isPause)
        {
            _pauseScreen.SetActive(false);
            Time.timeScale = 1.0f;
        }
        else
        {
            _pauseScreen.SetActive(true);
            Time.timeScale = 0;
        }
        isPause = !isPause;
    }

}
