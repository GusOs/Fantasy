using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentaurAttackMagic : MonoBehaviour
{

    private Collider sphereMagic;

    public float magicAttack = 5.0f;

    public float speedMagicAttack = 5.0f;

    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        sphereMagic = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        MagicAttack();
    }

    public void MagicAttack()
    {
            transform.position = Vector3
                .MoveTowards(transform.position, player.position, speedMagicAttack * Time.deltaTime);
    }


    private void OnTriggerEnter(Collider sphereMagic)
    {
        if (sphereMagic.gameObject.CompareTag("Player"))
        {
            (sphereMagic.gameObject.GetComponent("PlayerMovement") as PlayerMovement).lifePlayer -= magicAttack;
        }
    }
}
