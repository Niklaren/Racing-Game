using UnityEngine;
using System.Collections;

public class TextHighScoreScript : MonoBehaviour {

    TextMesh t;

    // Use this for initialization
    void Start()
    {
        t = GetComponent<TextMesh>();
        t.text = "HighScore: " + PlayerPrefs.GetInt("HighScore");
    }

}
