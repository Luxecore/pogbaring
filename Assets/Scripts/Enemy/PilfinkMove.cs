using UnityEngine;
using UnityEngine.AI;

public class PilfinkMove : MonoBehaviour
{
    Transform target;
    NavMeshAgent agent;

    SpriteRenderer spriteRenderer;

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
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Get direction from player to enemy
        Vector3 direction = (transform.position - target.position).normalized;

        // Calculate a destination that is 3 units away from the player
        Vector3 destination = target.position + direction * desiredDistance;

        // Move towards that destination
        agent.SetDestination(destination);

        // Flip depending on movement direction
        if (agent.velocity.x > 0.01f)
        {
            // Moving right
            spriteRenderer.flipX = false;
        }
        else if (agent.velocity.x < -0.01f)
        {
            // Moving left
            spriteRenderer.flipX = true;
        }
    }
}