using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Instancia de la clase
    public static GameManager Instance;

    // Referencia al script del jugador
    private PlayerLife playerScript;

    // Referencia al script del jefe final
    private CentaurLife centaurScript;

    //Referencia al objeto de la vida del centauro
    public GameObject currentHealthCentaur;

    //Referencia al objeto de la vida del jugador
    public GameObject currentHealth;

    //Variable para comprobar que el juego está activo
    public bool isGameActive;

    //Objeto del panel wingame
    public GameObject panelWinGame;

    // Sonido de muerte del jugador
    public Sound playerDeath;


    private void Awake()
    {
        Instance = this;
        isGameActive = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        playerScript = currentHealth.GetComponent<PlayerLife>();
        centaurScript = currentHealth.GetComponent<CentaurLife>();
        Time.timeScale = 1;
    }

    /*
     * Si la vida del jugador es igual o menor o 0
     * reproduce sonido
     * inicia la corrutina de cargar escena
     */
    public void GameOver()
    {
        if(playerScript.currentHealth <= 0 && isGameActive)
        {
            isGameActive = false;
            AudioManager.Instance.PlaySound(playerDeath);
            StartCoroutine(LoadScene());
        }
    }

    // Cargar la escena indicada
    public IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(0.7f);
        SceneManager.LoadScene("Forest");
    }

    /*
     * Se llama cuando la vida del centauro es menor o igual a 0
     *  Activa la corrutina del panel de victoria
     *  muestra el cursor
     */
    public void WinGame()
    {
        if(isGameActive)
        {
            isGameActive = false;
            StartCoroutine(ShowGameWinPanelCoroutine());
            Cursor.lockState = CursorLockMode.Confined;
        }
    }

    // Muestra el panel de victoria y congela el juego
    public IEnumerator ShowGameWinPanelCoroutine()
    {
        yield return new WaitForSeconds(1.5f);
        panelWinGame.SetActive(true);
        Time.timeScale = 0;
    }
}
