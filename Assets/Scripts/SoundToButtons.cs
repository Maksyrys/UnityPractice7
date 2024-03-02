using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundToButtons : MonoBehaviour
{
    public AudioSource _buttonClick;
    public AudioSource _raidGoing;
    public AudioSource _training;
    public AudioSource _harvesing;
    public AudioSource _addSettler;
    public AudioSource _addWarrior;

    public void ButtonClickSoundPlay()
    {
        _buttonClick.Play();
    }
    public void RaidStartSoundPlay()
    {
        _raidGoing.Play();
    }
    public void TrainingSoundPlay()
    {
        _training.Play();
    }
    public void HarvesingSoundPlay()
    {
        _harvesing.Play();
    }

    public void AddSettlerSoundPlay()
    {
        _addSettler.Play();
    }
    public void AddWarriorSoundPlay()
    {
        _addWarrior.Play();
    }

}
