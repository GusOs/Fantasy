using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ForestEnemyManager : MonoBehaviour
{
    //Transform del enemigo
    public Transform player;

    //Distancia de detección
    public float distance = 25f;

    //Animator del enemigo
    public Animator anim;

    //Vida del enemigo
    public float lifeForest = 20.0f;

    public GameObject lifeItem;

    UnityEngine.AI.NavMeshAgent nav;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    /*Si la posición del jugador respecto al enemigo es menor que la distancia
     * Siempre busca al jugador
     * si la dirección es mayor de 5, cambia de animación
    */
    void Update()
    {
        CheckAnimation();
        CheckDead();
    }

    public void CheckAnimation()
    {
        if (Vector3.Distance(player.position, this.transform.position) < distance)
        {
            Vector3 direction = player.position - this.transform.position;
            direction.y = 0;

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);

            if (direction.magnitude < 20)
            {
                anim.SetBool("attack", false);           
                nav = GetComponent<NavMeshAgent>();
                nav.isStopped = false;
                anim.SetInteger("moving", 3);
                nav.SetDestination(player.position);
            }
            if (direction.magnitude < 4.5f)
            {
                anim.SetInteger("moving", 0);
                nav = GetComponent<NavMeshAgent>();
                nav.isStopped = true;
                anim.SetBool("attack", true);
            }
        }
    }

    public void CheckDead()
    {
        if (lifeForest == 0)
        {
            anim.SetBool("death", true);
            nav.isStopped = true;
            Destroy(this.gameObject);
            Instantiate(lifeItem, this.transform.position, Quaternion.LookRotation(this.transform.position));
        }
    }
}
