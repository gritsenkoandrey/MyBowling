using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public sealed class UiGameScreen : MonoBehaviour
{
    [SerializeField] private GameObject _startGamePanel = null;
    [SerializeField] private GameObject _gameOverPanel = null;
    [SerializeField] private GameObject _gamePanel = null;
    [SerializeField] private GameObject _resumeGamePanel = null;

    [SerializeField] private UiButton _startButton = null;
    [SerializeField] private UiButton _exitButton = null;
    [SerializeField] private UiButton _restartButton = null;
    [SerializeField] private UiButton _resumeGameButton = null;

    [SerializeField] private Text _finalScore = null;

    private void Awake()
    {
        BallController.IsBallAlive = true;

        Time.timeScale = 0.0f;
        Cursor.visible = true;

        _startGamePanel.SetActive(true);
        _gamePanel.SetActive(true);
        _gameOverPanel.SetActive(false);
        _resumeGamePanel.SetActive(false);

        _startButton.GetButton.onClick.AddListener(delegate { StartGame(); });
        _exitButton.GetButton.onClick.AddListener(delegate { ExitGame(); });
        _restartButton.GetButton.onClick.AddListener(delegate { RestartGame(); });
        _resumeGameButton.GetButton.onClick.AddListener(delegate { ResumeGame(); });
    }

    private void StartGame()
    {
        BallController.IsBallAlive = false;

        Time.timeScale = 1.0f;
        Cursor.visible = false;

        _startGamePanel.SetActive(false);
        _gamePanel.SetActive(true);
        _gameOverPanel.SetActive(false);
    }

    private void ExitGame()
    {
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #else
        Application.Quit();
    #endif
    }

    private void RestartGame()
    {
        ScoreController.CountScore = 0;
        SceneManager.LoadScene(0);
    }

    private void ResumeGame()
    {
        Time.timeScale = 1.0f;
        Cursor.visible = false;

        _resumeGamePanel.SetActive(false);
    }

    public void NextLevel()
    {
        Time.timeScale = 0.0f;
        Cursor.visible = true;

        _resumeGamePanel.SetActive(true);
    }

    public void GameOver()
    {
        Time.timeScale = 0.0f;
        Cursor.visible = true;

        _gamePanel.SetActive(false);
        _gameOverPanel.SetActive(true);

        _finalScore.text = $"Points: {ScoreController.CountScore}";
    }
}