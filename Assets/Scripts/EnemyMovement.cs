using System.Collections;
using System.Collections.Generic;
using System.Xml;
//using UnityEditor.AI;
//using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.AI;
public class EnemyMovement : MonoBehaviour
{
    private int WalkRaduis = 50;
    private int RunRaduis = 40;
    private int AttackRaduis = 15;
    private float lookRaduis = 20;
    
    public Transform target;
    public Animator animator;
    private NavMeshAgent agent;
    void Start()
    {   
        agent = GetComponent<NavMeshAgent>();
        int distance =(int)Vector3.Distance(target.position, transform.position);
    }

    
    void Update()
    {
       int distance =(int)Vector3.Distance(target.position, transform.position);
       
      // Debug.Log(distance);
        if (distance <= WalkRaduis)
       {   animator.SetFloat("animationParameter",0.33f);
           agent.SetDestination(target.position);
           //Debug.Log("walk");
       }
        if (distance <= RunRaduis)
       {   
           animator.SetFloat("animationParameter",0.66f);
           agent.SetDestination(target.position);
           //Debug.Log("run");
           
        }
       
       if(distance <= AttackRaduis)
       {  //Debug.Log("attack");
           animator.SetFloat("animationParameter",1f);
           agent.SetDestination(target.position);
       }
       if(distance>50)
        {   //Debug.Log("ideal");
            animator.SetFloat("animationParameter",0f);
            agent.SetDestination(transform.position);
        }
    }

    
    void OnCollisionEnter(Collision collision)
    {
        //Check for a match with the specified name on any GameObject that collides with your GameObject

            //If the GameObject's name matches the one you suggest, output this message in the console
           // Debug.Log("Do something here");

        //Check for a match with the specific tag on any GameObject that collides with your GameObject

    }
}
