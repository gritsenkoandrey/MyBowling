﻿using Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public sealed class UiGameScreen : MonoBehaviour
{
    [SerializeField] private GameObject _startGamePanel = null;
    [SerializeField] private GameObject _gameOverPanel = null;
    [SerializeField] private GameObject _gamePanel = null;
    [SerializeField] private GameObject _resumeGamePanel = null;

    [SerializeField] private GameObject _groundOne = null;
    [SerializeField] private GameObject _groundTwo = null;
    [SerializeField] private GameObject _groundThree = null;
    [SerializeField] private GameObject _groundFour = null;
    [SerializeField] private GameObject _groundFive = null;

    [SerializeField] private UiButton _startButton = null;
    [SerializeField] private UiButton _exitButton = null;
    [SerializeField] private UiButton _restartButton = null;
    [SerializeField] private UiButton _resumeGameButton = null;

    [SerializeField] private Text _finalScore = null;
    [SerializeField] private Text _maxScore = null;

    public bool IsShowUI { get; private set; }

    private void Awake()
    {
        IsShowUI = true;
        Services.Instance.TimeService.SetTimeScale(0.0f);
        Cursor.visible = true;

        _startGamePanel.SetActive(true);

        _gamePanel.SetActive(false);
        _gameOverPanel.SetActive(false);
        _resumeGamePanel.SetActive(false);
    }

    private void OnEnable()
    {
        _maxScore.text = $"Maximum Score: {SaveData.LoadMaximumScore()}";

        _startButton.GetButton.onClick.AddListener(delegate { StartGame(); });
        _exitButton.GetButton.onClick.AddListener(delegate { ExitGame(); });
        _restartButton.GetButton.onClick.AddListener(delegate { RestartGame(); });
        _resumeGameButton.GetButton.onClick.AddListener(delegate { ResumeGame(); });
    }

    private void OnDisable()
    {
        _startButton.GetButton.onClick.RemoveListener(delegate { StartGame(); });
        _exitButton.GetButton.onClick.RemoveListener(delegate { ExitGame(); });
        _restartButton.GetButton.onClick.RemoveListener(delegate { RestartGame(); });
        _resumeGameButton.GetButton.onClick.RemoveListener(delegate { ResumeGame(); });
    }

    private void StartGame()
    {
        IsShowUI = false;

        Services.Instance.TimeService.SetTimeScale(1.0f);
        Cursor.visible = false;
        _gamePanel.SetActive(true);
        _startGamePanel.SetActive(false);
    }

    private void ExitGame()
    {
        Application.Quit();
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    private void ResumeGame()
    {
        IsShowUI = false;

        Services.Instance.TimeService.SetTimeScale(1.0f);
        Cursor.visible = false;

        _gamePanel.SetActive(true);
        _resumeGamePanel.SetActive(false);
    }

    public void LevelCompleted()
    {
        Services.Instance.TimeService.SetTimeScale(0.0f);
        Cursor.visible = true;

        _gamePanel.SetActive(false);
        _resumeGamePanel.SetActive(true);
    }

    public void GameOver()
    {
        Services.Instance.TimeService.SetTimeScale(0.0f);
        Cursor.visible = true;

        _gamePanel.SetActive(false);
        _gameOverPanel.SetActive(true);

        _finalScore.text = $"Points: {SaveData.LoadCurrentScore()}";
    }

    public void ChangeGround(VisualLevelGame level)
    {
        if (_resumeGamePanel.activeSelf || _startGamePanel.activeSelf)
        {
            _groundOne.SetActive(false);
            _groundTwo.SetActive(false);
            _groundThree.SetActive(false);
            _groundFour.SetActive(false);
            _groundFive.SetActive(false);

            switch (level)
            {
                case VisualLevelGame.GreenMountians:
                    _groundOne.SetActive(true);
                    break;
                case VisualLevelGame.SnowMountians:
                    _groundTwo.SetActive(true);
                    break;
                case VisualLevelGame.Swamp:
                    _groundThree.SetActive(true);
                    break;
                case VisualLevelGame.Castle:
                    _groundFour.SetActive(true);
                    break;
                case VisualLevelGame.LavaCastle:
                    _groundFive.SetActive(true);
                    break;
            }
        }
    }

    public void GamePanel(bool value)
    {
        _gamePanel.SetActive(value);
    }

    public bool ShowUI(bool value)
    {
        return IsShowUI = value;
    }
}