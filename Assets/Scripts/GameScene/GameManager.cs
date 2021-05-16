using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour
{
    [SerializeField] private SaveScores _saveScores;

    [SerializeField] private Text _scoreText;
    [SerializeField] private GameObject _hurdState;
    [SerializeField] private GameObject _mediumState;
    [SerializeField] private Button _exit;
    private int _score;
  
    public event Action DifficultyChange;

    private void Awake()
    {
        _exit.onClick.AddListener(() => ExitGame());
    }
    private void Start()
    {
        ChooseDifficulty();
    }
    private void ChooseDifficulty()
    {
        if (PlayerPrefs.HasKey("Complexity"))
        {
            if (PlayerPrefs.GetInt("Complexity") == 0)
            {
                _mediumState.SetActive(false);
                _hurdState.SetActive(false);
                return;
            }
            else if (PlayerPrefs.GetInt("Complexity") == 1)
            {
                _mediumState.SetActive(true);
                _hurdState.SetActive(false);
            }
            else if (PlayerPrefs.GetInt("Complexity") == 2)
            {
                _hurdState.SetActive(true);
                _mediumState.SetActive(true);
            }
        }
    }
   

    public void ChangeScore(int amount)
    {
        _score += amount;
        if (_score <= 0)
            _score = 0;
        _scoreText.text = _score.ToString();
    }

    private void ExitGame()
    {
        SceneManager.LoadScene("Menu");
        _saveScores.SaveData(_score);
    }
}
