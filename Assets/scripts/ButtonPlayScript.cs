using UnityEngine;
using System.Collections;

public class ButtonPlayScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	void OnMouseDown ()
	{
		Application.LoadLevel("game_scene");
	}
}
