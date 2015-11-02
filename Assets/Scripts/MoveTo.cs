using UnityEngine;
using System.Collections;

public class MoveTo : MonoBehaviour
{
    [SerializeField]
    private Transform goal;

    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = 3f;
    }

    void Update()
    {
        agent.destination = goal.position;
    }
}