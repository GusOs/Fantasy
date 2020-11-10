using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Instancia de la clase
    public static GameManager Instance;

    // Referencia al script del jugador
    private PlayerMovement playerScript;

    // Referencia al script del jefe final
    private CentaurManager centaurScript;

    //Referencia al objeto de la vida del centauro
    public GameObject lifeCentaur;

    //Referencia al objeto de la vida del jugador
    public GameObject lifeplayer;

    //Variable para comprobar que el juego está activo
    public bool isGameActive;


    private void Awake()
    {
        Instance = this;
        isGameActive = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        playerScript = lifeplayer.GetComponent<PlayerMovement>();
        Time.timeScale = 1;
    }

    public void GameOver()
    {
        if(playerScript.lifePlayer <= 0)
        {
            isGameActive = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void WinGame()
    {
        if(centaurScript.lifeBoss <= 0)
        {
            //texto victoria
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
