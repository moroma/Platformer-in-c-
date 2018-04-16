using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    private void Update()
    {
        if (gameObject.transform.position.y < -50)
        {

            Destroy(gameObject);
        }
        
    }
}
