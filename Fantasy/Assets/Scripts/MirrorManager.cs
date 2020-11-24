using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MirrorManager : MonoBehaviour
{
    // Sonido al entrar el jugador
    public Sound mirror;

    // Colisión del jugador
    private Collider playerCollision;

    // Referencia al jugador
    public GameObject player;

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    // Si el jugador colisiona, reproduce un audio y carga la escena indicada
    private void OnTriggerEnter(Collider playerCollision)
    {
        if(playerCollision.CompareTag("Player"))
        {
            //DontDestroyOnLoad(player);
            AudioManager.Instance.PlaySound(mirror);
            SceneManager.LoadScene("Temple_Jungle");
        }
    }
}
