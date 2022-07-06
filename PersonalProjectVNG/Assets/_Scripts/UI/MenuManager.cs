using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
  [SerializeField]
  FPSCounter _fpsCounter;

  public void EnterGame()
  {
    if (_fpsCounter.enabled)
    {
      DontDestroyOnLoad(_fpsCounter);
    }
    Resources.UnloadUnusedAssets();
    System.GC.Collect();
    SceneManager.LoadScene("City");
  }
  public void QuitGame()
  {
    Application.Quit();
  }
  public void ToggleFPSCounter()
  {
    _fpsCounter.gameObject.SetActive(true);
  }
}
