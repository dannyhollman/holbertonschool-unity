using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.XR.ARFoundation;

public class TargetAI : MonoBehaviour
{
    //private NavMeshAgent navMeshAgent;
    //public float travelTime;
    //private float timer;
    //private Vector3 randomDirection;
    //private bool moving;
    //private float speed = 1;
    //private Rigidbody rb;
    Vector3 randomTarget;
    Vector3 normalized;
    bool offEdge;
    Bounds bounds;

    void Awake()
    {
        //navMeshAgent = GetComponent<NavMeshAgent>();
        //timer = travelTime;
        bounds = PlaneController.selectedPlane.GetComponent<MeshCollider>().bounds;
        randomTarget = new Vector3(PlaneController.selectedPlane.center.x + Random.Range(bounds.min.x, bounds.max.x), transform.position.y, PlaneController.selectedPlane.center.z + Random.Range(bounds.min.z, bounds.max.z));
        normalized = (randomTarget - transform.position).normalized;
        transform.LookAt(normalized);
    }

    // Update is called once per frame
    /*
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > travelTime)
        {
            //Vector2 planeSize = PlaneController.selectedPlane.size;
            //float radius = (planeSize[0] < planeSize[1] ? planeSize[0] : planeSize[1]) / 2;

            for (int i = 0; i < 30; i++)
            {
                Vector3 randomDirection = Random.insideUnitSphere * 2 + transform.position;
                NavMeshHit navHit;
                if (NavMesh.SamplePosition(randomDirection, out navHit, 1, NavMesh.AllAreas))
                {
                    navMeshAgent.SetDestination(navHit.position);
                    //Debug.Log("Destination set: " + navHit.position);
                    break;
                }
                //else
                    //Debug.Log("Destination failed: " + navHit.position);
            }
            timer = 0;
        }
    }
    */

    void Update()
    {
        if (!CheckEdge())
            return;
        //transform.position += normalized * speed * Time.deltaTime;
        transform.position += normalized * (Time.deltaTime / 2);
    }

    private bool CheckEdge()
    {
        RaycastHit objectHit;
        Vector3 pos = transform.position;
        pos.y += 0.07f;
        if (Physics.Raycast(pos, transform.forward + (-transform.up), out objectHit, 50))
        {
            if (offEdge)
            {
                normalized = (randomTarget - transform.position).normalized;
                offEdge = false;
            }
            return true;
        }
        else
        {
            offEdge = true;
            randomTarget = new Vector3(PlaneController.selectedPlane.center.x + Random.Range(bounds.min.x, bounds.max.x), transform.position.y, PlaneController.selectedPlane.center.z + Random.Range(bounds.min.z, bounds.max.z));
            transform.LookAt(randomTarget);
            return false;
        }
    }
}
