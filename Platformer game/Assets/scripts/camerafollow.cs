using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafollow : MonoBehaviour {
    private GameObject player;
    public float xMinimum;
    public float xMaximum;
    public float yMinimum;
    public float yMaximum;
    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
        float x = Mathf.Clamp(player.transform.position.x, xMinimum, xMaximum);
        float y = Mathf.Clamp(player.transform.position.x, yMinimum, yMaximum);
        gameObject.transform.position = new Vector3 (x,y, gameObject.transform.position.z);
		
	}
}
