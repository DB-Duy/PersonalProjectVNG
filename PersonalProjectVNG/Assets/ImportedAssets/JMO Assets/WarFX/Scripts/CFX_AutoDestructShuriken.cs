using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ParticleSystem))]
public class CFX_AutoDestructShuriken : MonoBehaviour
{
  public bool OnlyDeactivate;

  private WaitForSeconds wait = new WaitForSeconds(0.5f);
  private ParticleSystem _particleSystem;

  void OnEnable()
  {
    StartCoroutine("CheckIfAlive");
  }

  IEnumerator CheckIfAlive()
  {
    while (true)
    {
      yield return wait;

      if (OnlyDeactivate)
      {
#if UNITY_3_5
						this.gameObject.SetActiveRecursively(false);
#else
        this.gameObject.SetActive(false);
#endif
      }
      else
        Destroy(gameObject);
      break;
    }
  }

}
