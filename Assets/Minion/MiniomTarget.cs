using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MiniomTarget : MonoBehaviour
{
    public List<GameObject> targetList = new List<GameObject>();
    public MinionAIScript minionAIScript;
    public NavMeshAgent minionAgent;
    public bool isBlue;
    public GameObject closestTarget = null;

    // Start is called before the first frame update
    void Start()
    {
        minionAIScript = GetComponentInParent<MinionAIScript>();
        minionAgent = GetComponentInParent<NavMeshAgent>();
        isBlue = minionAIScript.isBlue;
    }

    // Update is called once per frame
    void Update()
    {
        if (targetList.Count > 0 && !minionAIScript.hasTarget)
        {

            foreach (GameObject target in targetList)
            {
                float closestDistance = Mathf.Infinity;
                float distance = Vector3.Distance(target.transform.position, gameObject.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestTarget = target;
                }
            }
            minionAIScript.targetMinion = closestTarget;
            minionAIScript.hasTarget = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isBlue)
        {
            if (!targetList.Contains(other.gameObject) && other.gameObject.layer == 10)
            {
                targetList.Add(other.gameObject);
            }
        }
        else
        {
            if (!targetList.Contains(other.gameObject) && other.gameObject.layer == 9)
            {
                targetList.Add(other.gameObject);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (targetList.Contains(other.gameObject))
        {
            targetList.Remove(other.gameObject);
        }
    }
}