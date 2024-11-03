using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MinionAIScript : MonoBehaviour
{
    public Vector3 destination;
    public Vector3 finalDestination;
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        agent.SetDestination(destination);
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.remainingDistance < 0.5f)
        {
            agent.SetDestination(finalDestination);
        }
    }
}
