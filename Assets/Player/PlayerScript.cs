using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerScript : MonoBehaviour
{
    public Camera camera;
    int layerGround = 3;
    public GameObject moveIcon;
    private NavMeshAgent myNavMeshAgent;
    float clickOffset = 1f;
    public Material redMat;
    public Material blueMat;

    public GameObject minimapIcon;
    public Sprite blueIcon;
    public Sprite redIcon;

    int layerRedMinion = 10;
    int layerBlueMinion = 9;

    public float health = 100f;
    public float attackRange = 5f;
    public float damage = 10f;
    public float attackSpeed = 0.5f;
    public float attackTimer = 2f;
    public bool isBlue = false;

    GameObject target;
    bool hasTarget = false;


    // Start is called before the first frame update
    void Start()
    {
        myNavMeshAgent = GetComponent<NavMeshAgent>();
        if (isBlue)
        {
            gameObject.layer = 11;
            gameObject.GetComponent<MeshRenderer>().material = blueMat;
            minimapIcon.GetComponent<SpriteRenderer>().sprite = blueIcon;

        }
        else
        {
            gameObject.layer = 12;
            gameObject.GetComponent<MeshRenderer>().material = redMat;
            minimapIcon.GetComponent<SpriteRenderer>().sprite = redIcon;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray myRay = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(myRay, out hitInfo))
            {
                if (hitInfo.collider.gameObject.layer == layerGround)
                {
                    if (Input.GetMouseButtonDown(1))
                    {
                        Vector3 offset = new Vector3(hitInfo.point.x, hitInfo.point.y + clickOffset, hitInfo.point.z);

                        GameObject marker = Instantiate(moveIcon, offset, Quaternion.identity);

                    }
                    myNavMeshAgent.SetDestination(hitInfo.point);
                    myNavMeshAgent.stoppingDistance = 0;
                    hasTarget = false;

                }
                else
                {
                    int layer = isBlue ? layerRedMinion : layerBlueMinion;
                    if (hitInfo.collider.gameObject.layer == layer)
                    {
                        target = hitInfo.collider.gameObject;
                        hasTarget = true;
                    }
                }
            }
        }

        if (hasTarget && target != null)
        {
            myNavMeshAgent.SetDestination(target.transform.position);
            myNavMeshAgent.stoppingDistance = attackRange;

            if (Vector3.Distance(target.transform.position, transform.position) <= attackRange)
            {
                Attack();
            }
        }
    }

    void Attack()
    {
        attackTimer -= Time.deltaTime;
        if (attackTimer <= 0)
        {
            MinionAIScript minionAIScript = target.GetComponent<MinionAIScript>();
            minionAIScript.health -= damage;
            if (minionAIScript.health <= 0)
            {
                Destroy(target);
                hasTarget = false;
            }
            attackTimer = 1 / attackSpeed;
        }

    }
}
