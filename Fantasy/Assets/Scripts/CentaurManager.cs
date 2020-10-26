using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CentaurManager : MonoBehaviour
{
    //Transform del enemigo
    public Transform player;

    //Distancia de detección
    public float distance = 16f;

    //Animator del enemigo
    public Animator anim;

    public float LifeBoss = 35.0f;

    public float attackCentaur = 8.0f;

    UnityEngine.AI.NavMeshAgent nav;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.position, this.transform.position) < distance)
        {
            Vector3 direction = player.position - this.transform.position;
            direction.y = 0;

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);

            anim.SetBool("dle_battle", true);

            if (direction.magnitude < 12)
            {
                anim.SetBool("dle_battle", false);
                anim.SetBool("attack", false);
                anim.SetBool("trick", true);
                anim.SetInteger("moving", 1);
                nav = GetComponent<NavMeshAgent>();
                nav.SetDestination(player.position);
            }

            if (direction.magnitude < 5)
            {
                anim.SetBool("trick", false);
                anim.SetInteger("moving", 0);
                anim.SetBool("attack", true);
            }
        }
    }
}
