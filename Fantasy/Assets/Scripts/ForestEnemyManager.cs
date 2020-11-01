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

    //Daño de ataque
    public float attackForest = 5.0f;

    //Vida del enemigo
    public float lifeForest = 20.0f;

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

            if (direction.magnitude < 12)
            {
                anim.SetBool("Idle", false);
                anim.SetBool("attack", false);
                anim.SetInteger("moving", 3);
                nav = GetComponent<NavMeshAgent>();
                nav.SetDestination(player.position);
            }
            if (direction.magnitude < 2)
            {
                anim.SetInteger("moving", 0);
                anim.SetBool("attack", true);
            }
        }
    }

    public void CheckDead()
    {
        float timeDestroy = 5f;

        if (lifeForest == 0)
        {
            //Instantiate(lifeItem, this.transform.position, Quaternion.LookRotation(this.transform.position));
            anim.SetBool("death", true);
            Destroy(this.gameObject, timeDestroy);
        }
    }
}
