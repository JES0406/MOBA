using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerScript : MonoBehaviour
{
    public Camera camera;
    public int layer = 3;
    public GameObject moveIcon;
    private NavMeshAgent myNavMeshAgent;
    float clickOffset = 1f;

    // Start is called before the first frame update
    void Start()
    {
        myNavMeshAgent = GetComponent<NavMeshAgent>();
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
                if (hitInfo.collider.gameObject.layer == layer)
                {
                    if (Input.GetMouseButtonDown(1))
                    {
                        Vector3 offset = new Vector3(hitInfo.point.x, hitInfo.point.y + clickOffset, hitInfo.point.z);

                        GameObject marker = Instantiate(moveIcon, offset, Quaternion.identity);

                    }
                    myNavMeshAgent.SetDestination(hitInfo.point);

                }
            }
        }
    }
}
