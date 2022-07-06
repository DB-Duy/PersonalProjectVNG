using System;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFlowManager : MonoBehaviour
{
  private StringBuilder str = new StringBuilder();
  private int _roundScore;
  [SerializeField]
  private TMP_Text[] _scoreTexts;
  [SerializeField]
  private Canvas _gameOverCanvas;
  [SerializeField]
  private Canvas[] _deactiveOnDeathCanvas;

  private void Start()
  {
    _roundScore = 0;
    UpdateScore();
  }

  public void AddScore(int score)
  {
    _roundScore += score;
    UpdateScore();
  }

  private void UpdateScore()
  {
    str.Clear();
    str.Append("Score: ");
    str.Append(_roundScore.ToString());
    for (int i = 0; i < _scoreTexts.Length; i++)
    {
      _scoreTexts[i].text = str.ToString();
    }
  }

  public void OnDeath()
  {
    foreach (Canvas canvas in _deactiveOnDeathCanvas)
    {
      canvas.gameObject.SetActive(false);
    }
    _gameOverCanvas.gameObject.SetActive(true);
  }

  public void RestartGame()
  {
    string sceneName = SceneManager.GetActiveScene().name;
    SceneManager.LoadScene(sceneName);

    Resources.UnloadUnusedAssets();
    System.GC.Collect();
  }
}
