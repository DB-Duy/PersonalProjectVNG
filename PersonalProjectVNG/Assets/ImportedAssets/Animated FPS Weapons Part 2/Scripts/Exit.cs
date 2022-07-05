using UnityEngine;

public class Exit : MonoBehaviour
{

    void Update()
    {
        if(Input.GetKeyDown("escape")) {
			Application.Quit();
		}
    }
}
