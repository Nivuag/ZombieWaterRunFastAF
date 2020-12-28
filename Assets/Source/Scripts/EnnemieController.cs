using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnnemieController : MonoBehaviour, IPoolable
{
    public GameObject Player;

    public Vector3 Target;

    public NavMeshAgent thisAgent;

    public GameObject patrolArea;

    public ObjectsPoolComponent AssociatedPool { get; set; }

    private float DETECTION_DISTANCE = 10;
    private float ARRIVAL_DISTANCE = 3;
    private float ABANDON_DISTANCE = 20;

    bool Pursuing = false;

    void Update()
    {

        float Distance = DistanceBetweenTwoPoints(Player.transform.position, this.gameObject.transform.position);



        if (Pursuing)
        {
            if (Distance < ABANDON_DISTANCE)
            {
                Target = Player.transform.position;
            }
            else
                Roam();
        }
        else
        {
            if (Distance < DETECTION_DISTANCE)
            {
                Target = Player.transform.position;
                Pursuing = true;
            }
            else
                Roam();
        }

        thisAgent.SetDestination(Target);
    }

    private float DistanceBetweenTwoPoints(Vector3 a , Vector3 b) => Mathf.Sqrt(Mathf.Pow(a.x - b.x, 2) + Mathf.Pow(a.y - b.y, 2));

    private void Roam()
    {
        if (Pursuing)
        {
            RandomPositionInRoamingArea();
        }
        else
        {
            float Distance = DistanceBetweenTwoPoints(Target, this.transform.position);
            if(Distance<= ARRIVAL_DISTANCE)
            {
                RandomPositionInRoamingArea();
            }
        }
    }

    private void RandomPositionInRoamingArea()
    {
        Pursuing = false;
        RectTransform dimention = patrolArea.transform.GetComponent<RectTransform>();
        Vector3[] array = new Vector3[4];
        dimention.GetLocalCorners(array);
        Target = new Vector3(Random.Range(0, array[2].x * 2), patrolArea.transform.position.y, Random.Range(0, array[2].y * 2));
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            //Player.GetComponent<PlayerStatsManager>().isAlive = false;
            Debug.Log(Player.GetComponent<PlayerStatsManager>().health);
            Player.GetComponent<PlayerStatsManager>().health -= 0.2f;
        }
    }
}
