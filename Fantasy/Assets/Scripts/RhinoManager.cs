using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RhinoManager : MonoBehaviour
{
    //Transform del enemigo
    public Transform player;

    //Distancia de detección
    public float distance = 25f;

    //Daño del ataque
    public float attackRhino = 5.0f;

    //Daño del ataque al embestir
    public float attackRun = 8.0f;

    //Vida del enemigo
    public float lifeRhino = 20.0f;

    //Animator del enemigo
    public Animator anim;

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

            anim.SetBool("eat", true);

            if (direction.magnitude < 15)
            {
                anim.SetBool("eat", false);
                anim.SetBool("shout", true);
            }

            if (direction.magnitude < 12)
            {
                anim.SetBool("attack", false);
                anim.SetBool("eat", false);
                anim.SetBool("idle", false);
                anim.SetInteger("moving", 6);
                nav = GetComponent<NavMeshAgent>();
                nav.SetDestination(player.position);
            }

            if (direction.magnitude < 6)
            {
                anim.SetInteger("moving", 0);
                anim.SetBool("attack", true);
            }
        }
    }

    public void CheckDead()
    {
        float timeDestroy = 3f;

        if (lifeRhino == 0)
        {
            //Instantiate(lifeItem, this.transform.position, Quaternion.LookRotation(this.transform.position));
            anim.SetBool("death", true);
            Destroy(this.gameObject, timeDestroy);       
        }
    }
}
