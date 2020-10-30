using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MirrorManager : MonoBehaviour
{

    public Sound mirror;

    private Collider playerCollision;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider playerCollision)
    {
        if(playerCollision.CompareTag("Player"))
        {
            AudioManager.Instance.PlaySound(mirror);
            SceneManager.LoadScene("Temple_Jungle");
        }
    }
}
