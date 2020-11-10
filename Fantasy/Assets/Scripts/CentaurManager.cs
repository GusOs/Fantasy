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

    public float lifeBoss = 35.0f;

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
        checkAnimation();
        checkDead();
    }

    public void checkAnimation()
    {
        if (Vector3.Distance(player.position, this.transform.position) < distance)
        {
            Vector3 direction = player.position - this.transform.position;
            direction.y = 0;

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);

            anim.SetInteger("moving", 0);

            if (direction.magnitude < 12)
            {
                nav = GetComponent<NavMeshAgent>();
                nav.isStopped = false;
                anim.SetBool("attack", false);
                anim.SetBool("trick", true);             
                anim.SetInteger("moving", 1);
                nav.SetDestination(player.position);
            }

            if (direction.magnitude < 5)
            {
                nav = GetComponent<NavMeshAgent>();
                nav.isStopped = true;
                anim.SetBool("trick", false);
                anim.SetInteger("moving", 0);            
                anim.SetBool("attack", true);
            }
        }
    }

    public void checkDead()
    {
        float timeDestroy = 1.6f;

        if (lifeBoss == 0)
        {
            //Instantiate(lifeItem, this.transform.position, Quaternion.LookRotation(this.transform.position));
            anim.SetBool("death", true);
            Destroy(this.gameObject, timeDestroy);
            GameManager.Instance.WinGame();
        }
    }
}
