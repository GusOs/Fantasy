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
                nav = GetComponent<NavMeshAgent>();
                nav.isStopped = false;
                anim.SetBool("attack", false);            
                anim.SetInteger("moving", 6);
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
}
