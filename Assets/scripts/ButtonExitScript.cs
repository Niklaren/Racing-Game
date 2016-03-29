using UnityEngine;
using System.Collections;

public class ButtonExitScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    void OnMouseDown()
    {
        Application.Quit();
    }
}

