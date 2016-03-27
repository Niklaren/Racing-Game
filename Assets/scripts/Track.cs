using UnityEngine;
using System.Collections;

public class Track : MonoBehaviour {

    [SerializeField]
    GameObject Obstacle;
    [SerializeField]
    GameObject Life;
	[SerializeField]
	GameObject TrackSection;
	[SerializeField]
	GameObject LaneSection;

    [SerializeField]
    GameObject SectionA;
    [SerializeField]
    Transform LaneA0;
    [SerializeField]
    Transform LaneA1;
    [SerializeField]
    Transform LaneA2;
    [SerializeField]
    GameObject SectionB;
    //[SerializeField]
    //Transform LaneB0;
    //[SerializeField]
    //Transform LaneB1;
    //[SerializeField]
    //Transform LaneB2;

    private GameObject bottomSection;
    private GameObject topSection;

	private float sectionHeight;

    [SerializeField]
    private const float TimeBetweenObstacleSpawns = 1.0f;
    [SerializeField]
    private const float TimeBetweenLifeSpawns = 1.0f;
    private float obstacleSpawnTimer;
    private float lifeSpawnTimer;

    [SerializeField]
    private const float DistanceBetweenObstacleSpawns = 5.1f;
    [SerializeField]
    private const float DistanceBetweenLifeSpawns = 12.0f;
    private float obstacleSpawnDistancer;
    private float lifeSpawnDistancer;


    [SerializeField]
    GameObject p;

	public float leftLaneX;
	public float midLaneX;
	public float rightLaneX;

//    public float LeftLaneX() { return LaneA0.position.x; }
//    public float MidLaneX() { return LaneA1.position.x; }
//    public float RightLaneX() { return LaneA2.position.x; }

    // Use this for initialization
    void Start () {

		bottomSection = (GameObject) Instantiate (TrackSection, Vector3.zero, Quaternion.identity);
		sectionHeight = bottomSection.GetComponent<Renderer> ().bounds.size.y;
		topSection = (GameObject) Instantiate (TrackSection, new Vector3(0,sectionHeight,0), Quaternion.identity);

		float third = bottomSection.GetComponent<Renderer> ().bounds.size.x / 3;
		leftLaneX = -third;
		midLaneX = 0;
		rightLaneX = third;

        //bottomSection = SectionA;
        //topSection = SectionB;

        obstacleSpawnTimer = TimeBetweenObstacleSpawns;
        lifeSpawnTimer = TimeBetweenLifeSpawns;

        obstacleSpawnDistancer = DistanceBetweenObstacleSpawns;
        lifeSpawnDistancer = DistanceBetweenLifeSpawns;
}
	
	// Update is called once per frame
	void Update () {
        Scroll();
        //TickSpawnTimer();
	}

    private void Scroll(){
		if (!(bottomSection.GetComponent<Renderer> ().isVisible)  && (topSection.GetComponent<Renderer> ().isVisible))
		{
			bottomSection.transform.Translate(0.0f, sectionHeight*2, 0.0f);
			SwitchSections();
		}
    }

    private void SwitchSections()
    {
        GameObject temp = bottomSection;
        bottomSection = topSection;
        topSection = temp;
    }

    private void TickSpawnTimer()
    {
        obstacleSpawnTimer -= Time.deltaTime;
        lifeSpawnTimer -= Time.deltaTime;

        if (obstacleSpawnTimer <= 0)
        {
            SpawnObstacle();
            obstacleSpawnTimer = TimeBetweenObstacleSpawns;
        }

        if (lifeSpawnTimer <= 0)
        {
            SpawnLife();
            lifeSpawnTimer = TimeBetweenLifeSpawns;
        }
    }

    public void TickSpawnDistance(float distanceToTick)
    {
        obstacleSpawnDistancer -= distanceToTick;
        lifeSpawnDistancer -= distanceToTick;

        if (obstacleSpawnDistancer <= 0)
        {
            SpawnObstacle();
            obstacleSpawnDistancer = DistanceBetweenObstacleSpawns;
        }

        if (lifeSpawnDistancer <= 0)
        {
            SpawnLife();
            lifeSpawnDistancer = DistanceBetweenLifeSpawns;
        }
    }

    private void SpawnObstacle()
    {
        //GameObject obstacle = Instantiate(Obstacle);
        int lane = Random.Range(0, 2);

        if (lane == 0)
        {
            //obstacle.transform.position = new Vector3(leftLaneX(), p.transform.position.y + 5.0f, 0.0f);
            Instantiate(Obstacle, new Vector3(leftLaneX, p.transform.position.y + 5.0f, 0.0f), Quaternion.identity);
        }
        else if (lane == 1)
        {
            //obstacle.transform.position = new Vector3(midLaneX(), p.transform.position.y + 5.0f, 0.0f);
            Instantiate(Obstacle, new Vector3(midLaneX, p.transform.position.y + 5.0f, 0.0f), Quaternion.identity);
        }
        else if (lane == 2)
        {
            //obstacle.transform.position = new Vector3(rightLaneX(), p.transform.position.y + 5.0f, 0.0f);
            Instantiate(Obstacle, new Vector3(rightLaneX, p.transform.position.y + 5.0f, 0.0f), Quaternion.identity);
        }

    }

    private void SpawnLife()
    {
        GameObject life = Instantiate(Life);
        int lane = Random.Range(0, 2);

        if (lane == 0)
            life.transform.position = new Vector3(leftLaneX, p.transform.position.y + 5.0f, 0.0f);
        else if (lane == 1)
            life.transform.position = new Vector3(midLaneX, p.transform.position.y + 5.0f, 0.0f);
        else if (lane == 2)
            life.transform.position = new Vector3(rightLaneX, p.transform.position.y + 5.0f, 0.0f);

    }
}
