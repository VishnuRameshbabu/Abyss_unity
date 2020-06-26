using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AgentScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;
    public GameObject enemy;
    public int flag = 0;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
        // approaches a destination point).
        agent.autoBraking = false;

        GotoNextPoint();
    }


    void GotoNextPoint()
    {
        // Returns if no points have been set up
        if (points.Length == 0)
            return;

        // Set the agent to go to the currently selected destination.
        agent.destination = points[destPoint].position;
        //Debug.Log(flag);
        Debug.Log(points[destPoint].position);
        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % points.Length;
    }
    void Update()
    {
        // Choose the next destination point when the agent gets
        // close to the current one.
        //Debug.Log(flag);
        if (!agent.pathPending && agent.remainingDistance < 0.5f && flag==0)
          //  Debug.Log(flag);
        GotoNextPoint();
               }

    private void OnTriggerStay(Collider other)
    {
        {
            if (other.gameObject.name == "Player")
            {
                Debug.Log(other.gameObject.tag);
                flag = 1;
                agent.destination = other.gameObject.transform.position;
            }
            else { flag = 0; }
        }
    }

}
