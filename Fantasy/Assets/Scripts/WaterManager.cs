using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaterManager : MonoBehaviour
{
    // Colisión del agua
    private Collider waterCollider;

    // Start is called before the first frame update
    void Start()
    {
        waterCollider = GetComponent<Collider>();
    }

    // Si el jugador colisiona con el agua, carga la escena actual
    private void OnTriggerEnter(Collider waterCollider)
    {
        if (waterCollider.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
