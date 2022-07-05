using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawnManager : MonoBehaviour
{
  private ObjectPool _zombiePool;
  [SerializeField]
  private float _spawnRate;
  [SerializeField]
  private Transform[] _spawnLocations;

  [SerializeField]
  private Transform[] _targetLocations;

  private void OnValidate()
  {
    _zombiePool = GetComponent<ObjectPool>();
  }

  private void Start()
  {
    InvokeRepeating(nameof(SpawnRandomZombie), 2f, _spawnRate);
  }

  private void SpawnRandomZombie()
  {
    GameObject zombie = _zombiePool.SpawnObject(_spawnLocations[UnityEngine.Random.Range(0, _spawnLocations.Length)].position, Quaternion.identity);
    zombie?.GetComponent<ZombieNavigation>().InitializeNavigation(_targetLocations[UnityEngine.Random.Range(0, _targetLocations.Length)]);
    zombie?.GetComponent<ZombieAnimation>().InitializeAnimation();
    zombie?.GetComponent<Health>().InitializeHealth();
    zombie?.SetActive(true);
  }
}
