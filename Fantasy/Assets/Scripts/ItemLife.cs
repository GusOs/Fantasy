using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemLife : MonoBehaviour
{
    //Colision
    private Collider itemCollision;

    //Audio al colisionar
    public Sound life;

    //Referencia a la vida del jugador
    public GameObject lifePlayer;

    //Referencia al script del jugador
    private PlayerMovement playerScript;

    void Start()
    {
        itemCollision = GetComponent<Collider>();
    }

    /*Comprobar si ha colisionado con el jugador
     * Reproducir audio de vida
     * añadir 20 de vida al jugador
     * desactivar el item
    */
    private void OnTriggerEnter(Collider itemCollision)
    {
        if (itemCollision.CompareTag("Player"))
        {
             AudioManager.Instance.PlaySound(life);
             (itemCollision.gameObject.GetComponent("PlayerLife") as PlayerLife).currentHealth += 20;
             this.gameObject.SetActive(false);
        }
    }
}
