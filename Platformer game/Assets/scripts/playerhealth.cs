using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerhealth : MonoBehaviour {
	void Update () {
        if (gameObject.transform.position.y < -10)
        {
            Death();
        }    
	}
    void Death()
    {
        SceneManager.LoadScene("prototype_1");
    }
}
