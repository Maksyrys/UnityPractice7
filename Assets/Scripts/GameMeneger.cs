using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMeneger : MonoBehaviour
{
    public ClockTimer _HarvestTimer;
    public ClockTimer _TrainingTimer;
    public Image _RaidTimerImg;
    public Image _SettlerTimerImg;
    public Image _WarriorTimerImg;

    public Button _settlersButton;
    public Button _warriorsButton;

    public TextMeshProUGUI _resoursesText;
    public TextMeshProUGUI _raidText;
    public TextMeshProUGUI _LoseText;

    public int _settlerCount;
    public int _warriorCount;
    public int _foodCount;

    public int _foodPerSettlers;
    public int _foodToWarrior;

    public int _settlerCost;
    public int _warriorCost;

    public float _settlerCreateTime;
    public float _warriorCreateTime;
    public float _raidMaxTime;
    public int _raidIncrease;
    public int _nextRaid;

    private float settlerTimer = 2;
    private float warriorTimer = 2;
    private float raidTimer;
    int raidcount = 0;

    public GameObject GameOverPanel;
    public GameObject WinScreen;

    public SoundToButtons SoundToButtons;


    void Start()
    {
        UpdateText();
        raidTimer = _raidMaxTime;
        SoundToButtons = GetComponent<SoundToButtons>();
        settlerTimer = 0;
        warriorTimer = 0;
    }

    void Update()
    {
        raidTimer -= Time.deltaTime;
        _RaidTimerImg.fillAmount = raidTimer / _raidMaxTime;

        if(raidTimer <= 0) 
        {
            
            raidTimer = _raidMaxTime;
            raidcount += 1;
         
            if (raidcount > 3)
            {
                _warriorCount -= _nextRaid;
                _nextRaid += _raidIncrease;
                SoundToButtons.RaidStartSoundPlay();
            }
        }

        if(_HarvestTimer.Tick)
        {
            _foodCount += _settlerCount * _foodPerSettlers;
            SoundToButtons.HarvesingSoundPlay();
        }

        if(_TrainingTimer.Tick)
        {
            _foodCount -= _warriorCount * _foodToWarrior;
            SoundToButtons.TrainingSoundPlay();
        }

        if (settlerTimer > 0)
        {
            settlerTimer -= Time.deltaTime;
            _SettlerTimerImg.fillAmount = settlerTimer / _settlerCreateTime;
          
        }
        else if (settlerTimer > -1)
        {
            _SettlerTimerImg.fillAmount = 1;
            _settlersButton.interactable = true;
            _settlerCount += 1;
            settlerTimer = -2;
            SoundToButtons.AddSettlerSoundPlay();
        }

        if (warriorTimer > 0)
        {
            warriorTimer -= Time.deltaTime;
            _WarriorTimerImg.fillAmount = warriorTimer / _warriorCreateTime;
        }
        else if (warriorTimer > -1)
        {
            _WarriorTimerImg.fillAmount = 1;
            _warriorsButton.interactable = true;
            _warriorCount += 1;
            warriorTimer = -2;
            SoundToButtons.AddWarriorSoundPlay();
        }

        UpdateText();

        if(_warriorCount < 0)
        {
            Time.timeScale = 0;
            GameOverPanel.SetActive(true);
            LoseFinalText();
        }
        
        if(_settlerCount == 100 || _foodCount >= 500)
        {
            Time.timeScale = 0;
            WinScreen.SetActive(true);
        }

        

    }

    public void CreateSettler()
    {
        if (_foodCount > _settlerCost)
        {
            _foodCount -= _settlerCost;
            settlerTimer =  _settlerCreateTime;
            _settlersButton.interactable = false;
        }
        else if(_foodCount < _settlerCost)
        {
            _settlersButton.interactable = false;
        }

    }

    public void CreateWarrior()
    {
        if (_foodCount > _warriorCost)
        {
            _foodCount -= _warriorCost;
            warriorTimer = _warriorCreateTime;
            _warriorsButton.interactable = false;
        }
        else if (_foodCount < _warriorCost)
        {
            _warriorsButton.interactable = false;
        }
    }

    public void UpdateText()
    {
        _resoursesText.text = _warriorCount + "\n\n" + _settlerCount + "\n\n" + _foodCount;
        _raidText.text = _nextRaid + "\n\n" + raidcount;
    }

    public void LoseFinalText()
    {
        _LoseText.text = raidcount + "            " +(Mathf.Round(Time.time)).ToString() + "            "+ _foodCount;
    }

 

    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        GameOverPanel.SetActive(false);
        Time.timeScale = 1.0f;
        UpdateText();
    }
}
