using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectPool : MonoBehaviour
{
  private List<GameObject> _objectPool = new List<GameObject>();
  public UnityEvent OnObjectSpawn;

  [SerializeField]
  private int _poolCount;
  [SerializeField]
  private GameObject[] _objectPrefabs;

  private void Start()
  {
    InitiatePrefabList();
  }

  private void InitiatePrefabList()
  {
    for (int i = 0; i < _poolCount; i++)
    {
      _objectPool.Add(Instantiate<GameObject>(_objectPrefabs[UnityEngine.Random.Range(0, _objectPrefabs.Length)], Vector3.zero, Quaternion.identity));
      _objectPool[i].SetActive(false);
    }
  }


  public GameObject SpawnObject(Vector3 position, Quaternion rotation)
  {
    for (int i = 0; i < _objectPool.Count; i++)
    {
      if (!_objectPool[i].activeInHierarchy)
      {
        _objectPool[i].transform.position = position;
        _objectPool[i].transform.rotation = rotation;
        _objectPool[i].SetActive(true);
        OnObjectSpawn?.Invoke();

        return _objectPool[i];
      }
    }
    return null;
  }
}
