using UnityEngine;
using System.Collections;

public class DestroyBelowScreen : MonoBehaviour {

    private Camera cam;

	// Use this for initialization
	void Start () {
        cam = FindObjectOfType<Camera>();
    }
	
	// Update is called once per frame
	void Update () {
        if (!(gameObject.GetComponent<Renderer>().isVisible))
            if (gameObject.transform.position.y < cam.transform.position.y)
                Destroy(gameObject);
    }
}
