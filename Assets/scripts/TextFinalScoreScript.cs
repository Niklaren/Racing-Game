using UnityEngine;
using System.Collections;

public class TextFinalScoreScript : MonoBehaviour {

    TextMesh t;

    // Use this for initialization
    void Start()
    {
        t = GetComponent<TextMesh>();
        t.text = "Score: " + PlayerPrefs.GetInt("Score");
    }

}