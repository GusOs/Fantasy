using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestEnemyAttack : MonoBehaviour
{
    
    //Daño de ataque
    public int attackForest = 3;

    private Collider legsCollider;

    public Sound hitForestCreature;

    // Start is called before the first frame update
    void Start()
    {
        legsCollider = GetComponent<Collider>();
    }

    // Si las garras, colisionan con el jugador, le resta vida y reproduce el sonido del ataque
    private void OnTriggerEnter(Collider legsCollider)
    {
        if (legsCollider.gameObject.CompareTag("Player"))
        {
            (legsCollider.gameObject.GetComponent("PlayerLife") as PlayerLife).currentHealth -= attackForest;
            AudioManager.Instance.PlaySound(hitForestCreature);
        }
    }
}
