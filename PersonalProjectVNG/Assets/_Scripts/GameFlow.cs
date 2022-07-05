using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlow : MonoBehaviour
{
    [SerializeField]
    private GameObject _gameOverPanel;

    private void Start()
    {
        _gameOverPanel.SetActive(false);
    }

    public void OnPlayerDead()
    {
        _gameOverPanel.SetActive(true);
        Time.timeScale = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void OnQuitButtonClicked()
    {
        Time.timeScale = 1;
    }

}
