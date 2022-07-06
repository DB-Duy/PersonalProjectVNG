using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAudioManager : MonoBehaviour
{
  [SerializeField]
  private AudioClip[] _zombieAudios;
  [SerializeField]
  private float _zombieSoundRate = 0.4f;
  [SerializeField]
  private float _zombieSoundChance = 0.4f;
  [SerializeField]
  private ObjectPool _zombiePool;
  [SerializeField]
  private ObjectPool _audioSourcePool;
  [SerializeField]
  private AudioSource _audio;
  private void OnValidate()
  {
    _audio = GetComponent<AudioSource>();
    _audioSourcePool = GetComponent<ObjectPool>();
  }
  private void Start()
  {
    InvokeRepeating(nameof(PlayZombieSounds), 1f, 1 / _zombieSoundRate);
  }

  private void PlayZombieSounds()
  {
    GameObject[] _zombies = _zombiePool.ActiveObjects();
    for (int i = 0; i < _zombies.Length; i++)
    {
      if (UnityEngine.Random.value <= _zombieSoundChance)
      {
        GameObject zombieSound = _audioSourcePool.SpawnObject(_zombies[i].transform.position, Quaternion.identity);
        if (zombieSound == null)
        {
          return;
        }
        ZombieAudioSource source = zombieSound.GetComponent<ZombieAudioSource>();
        source.SetClip(_zombieAudios[UnityEngine.Random.Range(0, _zombieAudios.Length)]);
        source.PlayOnce();
      }
    }
  }
}
