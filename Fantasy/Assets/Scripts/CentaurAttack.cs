using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentaurAttack : MonoBehaviour
{
    //Daño de ataque
    public int attackBoss = 5;

    // Colisión del arma
    private Collider weaponCollider;

    // Sonido de ataque
    public Sound centaurHit;

    // Start is called before the first frame update
    void Start()
    {
        weaponCollider = GetComponent<Collider>();
    }

    //Si el arma colisiona con el jugador, le resta vida y se reproduce el sonido
    private void OnTriggerEnter(Collider weaponCollider)
    {
        if (weaponCollider.gameObject.CompareTag("Player"))
        {
            (weaponCollider.gameObject.GetComponent("PlayerLife") as PlayerLife).currentHealth -= attackBoss;
            AudioManager.Instance.PlaySound(centaurHit);
        }
    }
}
