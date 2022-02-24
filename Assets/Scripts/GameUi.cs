using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUi : MonoBehaviour
{
    private GameManager _gameManager;
    private Button _restartButton;
    private TextMeshProUGUI _counterText;

    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _restartButton = GetComponentInChildren<Button>();
        _counterText = GetComponentInChildren<TextMeshProUGUI>();
        _restartButton.onClick.AddListener(OnRestartButtonClick);
        _gameManager.OnScoreChange += UpdateCounter;
    }

    private void OnDestroy()
    {
        _restartButton.onClick.RemoveListener(OnRestartButtonClick);
        _gameManager.OnScoreChange -= UpdateCounter;
    }

    private void UpdateCounter(int value)
    {
        _counterText.text = value.ToString();
    }

    private void OnRestartButtonClick()
    {
        _gameManager.Restart();
    }
}