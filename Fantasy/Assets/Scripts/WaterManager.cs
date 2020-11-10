using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaterManager : MonoBehaviour
{

    private Collider waterCollider;

    // Start is called before the first frame update
    void Start()
    {
        waterCollider = GetComponent<Collider>();
    }


    private void OnTriggerEnter(Collider waterCollider)
    {
        if (waterCollider.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
