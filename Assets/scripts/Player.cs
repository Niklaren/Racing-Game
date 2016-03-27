using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    private Camera cam;
    public GameObject p;
    [SerializeField]
    float speed;
    [SerializeField]
    float acceleration = 0.5f;
    [SerializeField]
    float startSpeed = 1.5f;
    [SerializeField]
    float topSpeed = 5.0f;

    [SerializeField]
    int lives = 3;
	[SerializeField]
    int maxLives = 3;

    [SerializeField]
    float score;

    [SerializeField]
    Track track;

    // Use this for initialization
    void Start()
    {
        cam = FindObjectOfType<Camera>();
        speed = startSpeed;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        p.transform.Translate(0.0f, speed * Time.deltaTime, 0.0f);
        cam.transform.Translate(0.0f, speed * Time.deltaTime, 0.0f);

        float distanceTravelled = speed * Time.deltaTime;
        score += distanceTravelled;
        track.TickSpawnDistance(distanceTravelled);

        Accelerate();

        if (Input.GetKeyDown(KeyCode.A))
            MoveLeft();
        else if(Input.GetKeyDown(KeyCode.D))
            MoveRight();

        if (Input.GetKeyDown(KeyCode.Z))
            MoveToLeft();
        else if (Input.GetKeyDown(KeyCode.X))
            MoveToCentre();
        else if (Input.GetKeyDown(KeyCode.C))
            MoveToRight();
    }

    private void Accelerate()
    {
        speed += acceleration * Time.deltaTime;

        if (speed > topSpeed)
            speed = topSpeed;
    }

    private void MoveLeft()
    {
        if(p.transform.position.x>=0.0f)
            p.transform.Translate(-1.8f, 0.0f, 0.0f);
    }

    private void MoveRight()
    {
        if (p.transform.position.x <= 0.0f)
            p.transform.Translate(1.8f, 0.0f, 0.0f);
    }

    private void MoveToLeft()
    {
        p.transform.position = new Vector3(track.leftLaneX, p.transform.position.y, p.transform.position.z);
    }
    private void MoveToCentre() {
        p.transform.position = new Vector3(track.midLaneX, p.transform.position.y, p.transform.position.z);
    }
    private void MoveToRight() {
        p.transform.position = new Vector3(track.rightLaneX, p.transform.position.y, p.transform.position.z);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("obstacle"))
        {
			LoseLife();
        }
        else if (other.CompareTag("life"))
        {
			GainLife();
        }
		Destroy(other.gameObject);
    }

    private void GainLife()
    {
        if (lives < maxLives)
            lives++;
    }

    private void LoseLife()
    {
        lives--;
        //if (lives <= 0)
            //; //gameover
    }
}
