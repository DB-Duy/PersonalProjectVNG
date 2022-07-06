using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrassEjection : MonoBehaviour
{
  [SerializeField]
  [HideInInspector]
  private ParticleSystem _effect;
  [SerializeField]
  private AudioSource _brassSound;
  [SerializeField]
  private float _fallingTime;

  private void OnValidate()
  {
    _effect = GetComponent<ParticleSystem>();
  }

  public void Eject()
  {
    _effect.Emit(1);
    Invoke(nameof(PlayBrassSound), _fallingTime);
  }

  public void PlayBrassSound() => _brassSound?.Play();
}
