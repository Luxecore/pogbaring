using UnityEngine;
using UnityEngine.AI;

public class PilfinkMove : MonoBehaviour
{
    Transform target;
    NavMeshAgent agent;

    float desiredDistance = 3.5f;

    private void Awake()
    {
        target = GameObject.Find("Pogba").transform;
    }

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        agent.stoppingDistance = 0.2f;
    }

    void Update()
    {
        // Get direction from player to enemy
        Vector3 direction = (transform.position - target.position).normalized;

        // Calculate a destination that is 3 units away from the player
        Vector3 destination = target.position + direction * desiredDistance;

        // Move towards that destination
        agent.SetDestination(destination);
    }
}