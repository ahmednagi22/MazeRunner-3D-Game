using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEditor.AI;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.AI;
public class EnemyMovement : MonoBehaviour
{
    private float WalkRaduis = 40f;
    private float RunRaduis = 30f;
    private float AttackRaduis = 9f;
    private float lookRaduis = 20;
    
    public Transform target;
    public Animator animator;
    private NavMeshAgent agent;
    void Start()
    {   
        agent = GetComponent<NavMeshAgent>();
        
    }

    
    void Update()
    {
       float distance =Vector3.Distance(target.position, transform.position);
       Debug.Log(distance);
        if (distance <= WalkRaduis)
       {   animator.SetBool("WalkAnimation",true);
           agent.SetDestination(target.position);
            
       }
       else if (distance <= RunRaduis)
       {   
           animator.SetBool("RunAnimation",true);
           agent.SetDestination(target.position);
           
           
        }
       
       else if(distance <= AttackRaduis)
       {  
           animator.SetBool("AttackAnimation",true);
           agent.SetDestination(target.position);
       }
        else if(distance>=41f)
        {
            animator.SetBool("IdealAnimation",true);
           // agent.SetDestination();
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color=Color.red;
        Gizmos.DrawWireSphere(transform.position,lookRaduis);
    }
    void OnCollisionEnter(Collision collision)
    {
        //Check for a match with the specified name on any GameObject that collides with your GameObject

            //If the GameObject's name matches the one you suggest, output this message in the console
           // Debug.Log("Do something here");

        //Check for a match with the specific tag on any GameObject that collides with your GameObject

    }
}
