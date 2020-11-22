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

    public void GameOver()
    {
        if(playerScript.currentHealth <= 0 && isGameActive)
        {
            isGameActive = false;
            AudioManager.Instance.PlaySound(playerDeath);
            StartCoroutine(LoadScene());
        }
    }

    public IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(0.7f);
        SceneManager.LoadScene("Forest");
    }

    public void WinGame()
    {
        if(isGameActive)
        {
            isGameActive = false;
            StartCoroutine(ShowGameWinPanelCoroutine());
            Cursor.lockState = CursorLockMode.Confined;
        }
    }

    public IEnumerator ShowGameWinPanelCoroutine()
    {
        yield return new WaitForSeconds(1.5f);
        panelWinGame.SetActive(true);
        Time.timeScale = 0;
    }
}
