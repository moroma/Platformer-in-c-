using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Score : MonoBehaviour {
    public float TimeRemaining = 120;
    public int playerscore = 0;
    public GameObject TimeRemainingUI;
    public GameObject playerscoreUI;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        TimeRemaining -= Time.deltaTime;
        TimeRemainingUI.gameObject.GetComponent<Text>().text = ("Time left: " + TimeRemaining);
        playerscoreUI.gameObject.GetComponent<Text>().text = ("Score: " + playerscore);
        if (TimeRemaining < 0.1f)
        {
            SceneManager.LoadScene("Prototype_1");
        }
	}
    void OnTriggerEnter2D(Collider2D trig)
    {
        Debug.Log("touched the end of the level");
        if (trig.gameObject.name == "Finish")
        {
            ScoreCount();
        }
        if (trig.gameObject.tag == "Coins")
        {
            playerscore += 10;
            Destroy(trig.gameObject);
        }
    }
    void ScoreCount()
    {
        playerscore = playerscore + (int)(TimeRemaining * 10);
        Debug.Log(playerscore);
    }
}
