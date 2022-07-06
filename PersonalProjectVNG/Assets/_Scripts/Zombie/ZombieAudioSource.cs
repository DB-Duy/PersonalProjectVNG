using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAudioSource : MonoBehaviour
{
  private AudioSource _audioSource;

  private void Awake()
  {
    _audioSource = GetComponent<AudioSource>();
  }
  public void PlayOnce()
  {
    _audioSource.Play();
    Invoke(nameof(DisableSource), _audioSource.clip.length + 0.1f);
  }
  private void DisableSource()
  {
    gameObject.SetActive(false);
  }
  public void SetClip(AudioClip clip)
  {
    _audioSource.clip = clip;
  }

}
