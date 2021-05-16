using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private Transform _panelStartButton;
    private Vector3 _targetPosPanelStart;
    [SerializeField] private Transform _panelSetting;
    private Vector3 _targetPosPanelSetting;
    [SerializeField] private Transform _panelRecords;
    private Vector3 _targetPosPanelRecords;
    [SerializeField] private Transform _centrePos;
    [SerializeField] private Transform _bottomPos;

    #region Buttons
    [SerializeField] private Button _start;
    [SerializeField] private Button _hardSetting;
    [SerializeField] private Button _records;
    [SerializeField] private Button _exitGame;
    [SerializeField] private Button []_closePanel;
    #endregion
    private void Awake()
    {
        _start.onClick.AddListener(() => StartGame());
        _hardSetting.onClick.AddListener(() => OpenPanelSetting());
        _exitGame.onClick.AddListener(() => ExitGame());
        _records.onClick.AddListener(() => OpenPanelRecords());
        for (int i = 0; i < _closePanel.Length; i++)
        {
            _closePanel[i].onClick.AddListener(() => OpenPanelStartButton());
        }
    }
    private void Start()
    {
        OpenPanelStartButton();
    }
    private void Update()
    {
        _panelStartButton.localPosition = Vector3.Lerp(_panelStartButton.localPosition, _targetPosPanelStart, Time.deltaTime * 7f);
        _panelSetting.localPosition = Vector3.Lerp(_panelSetting.localPosition, _targetPosPanelSetting, Time.deltaTime * 7f);
        _panelRecords.localPosition = Vector3.Lerp(_panelRecords.localPosition, _targetPosPanelRecords, Time.deltaTime * 7f);
    }
    private void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    private void OpenPanelSetting()
    {
        _targetPosPanelStart = _bottomPos.localPosition;
        _targetPosPanelSetting = _centrePos.localPosition;
        _targetPosPanelRecords = _bottomPos.localPosition;
    }

    private void OpenPanelStartButton()
    {
        _targetPosPanelStart = _centrePos.localPosition;
        _targetPosPanelSetting = _bottomPos.localPosition;
        _targetPosPanelRecords = _bottomPos.localPosition;
    }

    private void OpenPanelRecords()
    {
        _targetPosPanelStart = _bottomPos.localPosition;
        _targetPosPanelSetting = _bottomPos.localPosition;
        _targetPosPanelRecords = _centrePos.localPosition; 
    }

    private void ExitGame()
    {
        Application.Quit();
    }
}
