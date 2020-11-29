using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public sealed class UiGameScreen : MonoBehaviour
{
    [SerializeField] private GameObject _startGamePanel = null;
    [SerializeField] private GameObject _gameOverPanel = null;
    [SerializeField] private GameObject _gamePanel = null;

    [SerializeField] private UiButton _startButton = null;
    [SerializeField] private UiButton _exitButton = null;
    [SerializeField] private UiButton _restartButton = null;

    [SerializeField] private Text _finalScore = null;

    private void Awake()
    {
        Time.timeScale = 0.0f;
        _startGamePanel.SetActive(true);
        _gamePanel.SetActive(true);
        _gameOverPanel.SetActive(false);
        Cursor.visible = true;
        BallController.IsBallAlive = true;

        _startButton.GetButton.onClick.AddListener(delegate { StartGame(); });
        _exitButton.GetButton.onClick.AddListener(delegate { ExitGame(); });
        _restartButton.GetButton.onClick.AddListener(delegate { RestartGame(); });
    }

    private void StartGame()
    {
        _startGamePanel.SetActive(false);
        _gamePanel.SetActive(true);
        _gameOverPanel.SetActive(false);
        Cursor.visible = false;
        Time.timeScale = 1.0f;
        BallController.IsBallAlive = false;
    }

    private void ExitGame()
    {
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #else
        Application.Quit();
    #endif
    }

    public void GameOver()
    {
        _gamePanel.SetActive(false);
        _gameOverPanel.SetActive(true);
        _finalScore.text = $"Points: {ScoreController.CountScore}";
        Cursor.visible = true;
        Time.timeScale = 0.0f;
    }

    private void RestartGame()
    {
        ScoreController.CountScore = 0;
        SceneManager.LoadScene(0);
    }
}