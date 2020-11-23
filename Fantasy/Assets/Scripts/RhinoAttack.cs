using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhinoAttack : MonoBehaviour
{

    //Daño del ataque
    public int attackRhino = 2;

    // Colisión del cuero
    private Collider hornCollider;

    // Audio del ataque
    public Sound hitHorn;

    // Start is called before the first frame update
    void Start()
    {
        hornCollider = GetComponent<Collider>();
    }

    // Si el cuerno colisiona con el jugador, le resta vida y reproduce el sonido del cuerno
    private void OnTriggerEnter(Collider hornCollider)
    {
        if (hornCollider.gameObject.CompareTag("Player"))
        {
            (hornCollider.gameObject.GetComponent("PlayerLife") as PlayerLife).currentHealth -= attackRhino;
            AudioManager.Instance.PlaySound(hitHorn);
        }
    }
}
