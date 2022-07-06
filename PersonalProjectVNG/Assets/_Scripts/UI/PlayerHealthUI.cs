using System.Collections;
using System.Text;
using TMPro;
using UnityEngine;

public class PlayerHealthUI : MonoBehaviour
{
  private StringBuilder str = new StringBuilder();
  private TMP_Text _playerHealthText;
  [SerializeField]
  private Health _playerHealth;
  private void OnValidate()
  {
    _playerHealthText = GetComponentInChildren<TMP_Text>();
  }
  private void Start()
  {
    UpdateHealth();
  }

  public void UpdateHealth()
  {
    StartCoroutine(UpdateHealthText());
  }
  private IEnumerator UpdateHealthText()
  {
    yield return null;
    str.Clear();
    str.Append("HP: ");
    str.Append(_playerHealth.HealthValue.ToString());
    _playerHealthText.text = str.ToString();
  }
}
