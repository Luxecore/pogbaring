using UnityEngine;
using UnityEngine.AI;

public class SkataMovement : MonoBehaviour
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

        // Check which direction the enemy is moving
        if (agent.velocity.x > 0.01f)
        {
            spriteRenderer.flipX = true;
        }
        else if (agent.velocity.x < -0.01f)
        {
            spriteRenderer.flipX = false;
        }
    }
}