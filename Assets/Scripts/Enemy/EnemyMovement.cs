using UnityEngine;
using UnityEngine.AI;
using static UnityEditor.Experimental.GraphView.GraphView;
using static UnityEngine.GraphicsBuffer;

public class EnemyMovement : MonoBehaviour
{
    Transform target;
    NavMeshAgent agent;

    private void Awake()
    {
        target = GameObject.Find("Pogba").transform;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
       

        agent.SetDestination(target.position);
    }

   
}
