using UnityEngine;
using System.Collections;

public class TextScoreScript : MonoBehaviour {

    Player p;
    TextMesh t;

	// Use this for initialization
	void Start () {
	    p = FindObjectOfType<Player>();  // assuming there's only 1 player in the scene
        t = GetComponent<TextMesh>();
    }
	
	// Update is called once per frame
	void Update () {
        t.text = "Score: " + Mathf.Round(p.score);
	}
}
