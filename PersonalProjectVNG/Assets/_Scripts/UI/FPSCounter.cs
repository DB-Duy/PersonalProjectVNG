using System.Collections;
using UnityEngine;
using System.Text;

public class FPSCounter : MonoBehaviour
{
  [SerializeField]
  private TMPro.TMP_Text _fpsText;

  private WaitForSeconds _intervalWait = new WaitForSeconds(1.0f);

  private StringBuilder _sb = new StringBuilder();

  private int _frameCount;

  private void Start()
  {
    _frameCount = Time.frameCount;
    StartCoroutine(DisplayFPS());
  }

  private IEnumerator DisplayFPS()
  {
    while (true)
    {
      _sb.Clear();
      yield return _intervalWait;
      _sb.Append("FPS: ");
      _sb.Append((Time.frameCount - _frameCount).ToString());
      _fpsText.text = _sb.ToString();
      _frameCount = Time.frameCount;
    }
  }
}
