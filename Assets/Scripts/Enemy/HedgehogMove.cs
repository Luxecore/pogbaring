using UnityEngine;
using UnityEngine.AI;

public class HegehogMovement : MonoBehaviour
{
    Transform target;
    NavMeshAgent agent;
    SpriteRenderer spriteRenderer;

    private void Awake()
    {
        target = GameObject.Find("Pogba").transform;
    }

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    void Update()
    {
        agent.SetDestination(target.position);

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