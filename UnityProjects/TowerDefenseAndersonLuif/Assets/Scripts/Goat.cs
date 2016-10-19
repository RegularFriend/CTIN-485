using UnityEngine;
using System.Collections;

public class Goat : MonoBehaviour {




    public float range = 10.0f;

    public NavMeshAgent n;
    public Animator animator;

    private Vector3 startPos;
    public Transform target;

    private Vector3 currentTargetPos;

    void Start()
    {

        n = GetComponent<NavMeshAgent>();

        startPos = transform.position;
        currentTargetPos = target.position;
    }


    void Update()
    {
        
        if (n.isOnNavMesh)
            n.SetDestination(currentTargetPos);

        Debug.DrawRay(currentTargetPos,Vector3.up * 3f);


        //if(n.remainingDistance < 0.06f)
        //{
        //    if (currentTargetPos == target.position)
        //        currentTargetPos = startPos;
        //    else
        //        currentTargetPos = target.position;
        //}

        animator.SetFloat("Velocity", n.velocity.magnitude);

    }

   
}
