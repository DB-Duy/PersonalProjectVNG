using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioManager : MonoBehaviour
{
  [SerializeField]
  private AudioClip[] _damagedClips;
  [SerializeField]
  private AudioClip[] _deathClips;
  [SerializeField]
  private AudioSource _audioSource;

  private void OnValidate()
  {
    _audioSource = GetComponent<AudioSource>();
  }
  private void Start()
  {
    transform.position = GameObject.FindGameObjectWithTag("Player").transform.position;
  }

  public void OnDamaged()
  {
    if (_audioSource.isPlaying)
    {
      return;
    }
    _audioSource.clip = _damagedClips[UnityEngine.Random.Range(0, _damagedClips.Length)];
    _audioSource.Play();
  }
  public void OnDeath()
  {
    _audioSource.clip = _deathClips[UnityEngine.Random.Range(0, _deathClips.Length)];
    _audioSource.Play();
  }
}
