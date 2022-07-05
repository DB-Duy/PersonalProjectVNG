using UnityEngine;

public class DestructibleObject : MonoBehaviour {
	
public GameObject destroyedObject;
public float health = 100f;

public void TakeDamage (float amount)
{
	health -= amount;
	if (health <= 0f)
	{
		Destroy();
	}
}

public void Destroy()
{
	Instantiate(destroyedObject, transform.position, transform.rotation);
	Destroy(gameObject);
}
}