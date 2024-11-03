using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MinionAIScript : MonoBehaviour
{
    public Vector3 destination;
    public Vector3 finalDestination;
    public bool passedMid = false;
    NavMeshAgent agent;

    public Material blueMat;
    public Material redMat;

    public bool isBlue = false;

    public GameObject targetMinion;
    public bool hasTarget = false;

    public float health = 100f;
    public float attackDamage = 10f;
    public float attackRange = 2f;
    public float attackSpeed = 0.5f;
    public float attackTimer = 2f;


    // Start is called before the first frame update
    void Start()
    {
        if (isBlue)
        {
            this.GetComponent<MeshRenderer>().material = blueMat;
            this.gameObject.layer = 9;
        }
        else
        {
            this.GetComponent<MeshRenderer>().material = redMat;
            this.gameObject.layer = 10;
        }
        agent = this.GetComponent<NavMeshAgent>();
        agent.SetDestination(destination);
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.remainingDistance < 0.5f)
        {
            passedMid = true;
            agent.SetDestination(finalDestination);
        }

        if (hasTarget && targetMinion != null)
        {
            agent.SetDestination(targetMinion.transform.position);
            attackTimer -= Time.deltaTime;
            if (attackTimer <= 0)
            {
                Attack();
                attackTimer = 1 / attackSpeed;
            }

        }
        

        if (targetMinion == null)
        {
            hasTarget = false;
            if (passedMid)
            {
                agent.SetDestination(finalDestination);
            }
            else
            {
                agent.SetDestination(destination);
            }
        }
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void Attack()
    {
        if (Vector3.Distance(targetMinion.transform.position, gameObject.transform.position) < attackRange)
        {
            targetMinion.GetComponent<MinionAIScript>().health -= attackDamage;
        }
    }
}
