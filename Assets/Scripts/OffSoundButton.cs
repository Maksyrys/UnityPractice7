using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OffSoundButton : MonoBehaviour
{
    public GameObject _offSound;


    public bool isOn;

    private void Start()
    {
       isOn = true;
    }


    public void OnOffSound()
    {
        if (!isOn)
        {
            AudioListener.volume = 1.0f;
            isOn = true;
            _offSound.SetActive(false);
        }
        else if (isOn)
        {
            AudioListener.volume = 0f; 
            isOn = false;
            _offSound.SetActive(true);
        }
    }

}
