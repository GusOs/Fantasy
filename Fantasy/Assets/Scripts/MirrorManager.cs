using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MirrorManager : MonoBehaviour
{

    public Sound mirror;

    private Collider playerCollision;

    public GameObject player;


    private void OnTriggerEnter(Collider playerCollision)
    {
        if(playerCollision.CompareTag("Player"))
        {
            DontDestroyOnLoad(player);
            AudioManager.Instance.PlaySound(mirror);
            SceneManager.LoadScene("Temple_Jungle");
        }
    }
}
