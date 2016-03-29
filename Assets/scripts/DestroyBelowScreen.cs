using UnityEngine;
using System.Collections;

public class DestroyBelowScreen : MonoBehaviour {

    private Camera cam;

	// Use this for initialization
	void Start () {
        cam = FindObjectOfType<Camera>();
    }

    void OnBecameInvisible()
    {
        if (gameObject.transform.position.y < cam.transform.position.y)
            Destroy(gameObject);
    }
}
