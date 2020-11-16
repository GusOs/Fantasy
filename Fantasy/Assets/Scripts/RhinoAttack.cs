using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhinoAttack : MonoBehaviour
{

    //Daño del ataque
    public int attackRhino = 2;

    private Collider hornCollider;

    public RhinoAttack Instance;

    // Start is called before the first frame update
    void Start()
    {
        hornCollider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider hornCollider)
    {
        if (hornCollider.gameObject.CompareTag("Player"))
        {
            (hornCollider.gameObject.GetComponent("PlayerLife") as PlayerLife).currentHealth -= attackRhino;
            GameManager.Instance.GameOver();
        }
    }
}
