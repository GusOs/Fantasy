﻿using System.Collections;
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
    private CentaurManager centaurScript;

    //Referencia al objeto de la vida del centauro
    public GameObject lifeBoss;

    //Referencia al objeto de la vida del jugador
    public GameObject currentHealth;

    //Variable para comprobar que el juego está activo
    public bool isGameActive;

    //Objeto del panel wingame
    public GameObject panelWinGame;


    private void Awake()
    {
        Instance = this;
        isGameActive = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        playerScript = currentHealth.GetComponent<PlayerLife>();
        Time.timeScale = 1;
    }

    public void GameOver()
    {
        if(playerScript.currentHealth <= 0 && isGameActive)
        {
            isGameActive = false;
            SceneManager.LoadScene("Forest");
        }
    }

    public void WinGame()
    {
        isGameActive = false;
        StartCoroutine(ShowGameWinPanelCoroutine());
        Cursor.lockState = CursorLockMode.Confined;
    }

    public IEnumerator ShowGameWinPanelCoroutine()
    {
        yield return new WaitForSeconds(1.5f);
        panelWinGame.SetActive(true);
    }
}
