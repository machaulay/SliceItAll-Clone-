using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game_Controller : MonoBehaviour
{
    public static bool carregarCena = false;
    public static bool gameOver = false;
    public static bool startGame = false;
    public static bool isPlaying;
    public Text gameOverTxt;
    public static int score = 0;
    public Text scoreTxt;
    public Text FinalScoreTxt;



    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        score = 0;
        gameOverTxt.enabled = false;
        FinalScoreTxt.gameObject.SetActive(false);
        gameOver = false;
        carregarCena = false;
        isPlaying = false;
        scoreTxt.text = score.ToString();
    }


    // Update is called once per frame
    void Update()
    {
        scoreTxt.text = score.ToString();


        if (carregarCena && !gameOver)
        {
            isPlaying = false;
            FinalScoreTxt.text = score.ToString();
            FinalScoreTxt.gameObject.SetActive(true);
        }

        if (gameOver)
        {
            isPlaying = false;
            gameOverTxt.enabled = true;
            StartCoroutine(carregaCena("Gameplay"));

        }

        if (startGame)
        {
            isPlaying = true;
            if (Input.GetMouseButtonDown(0))
            {
                Destroy(GameObject.Find("Base").gameObject);
                startGame = false;

            }
        }

    }

    IEnumerator carregaCena(string cena)
    {
        yield return new WaitForSecondsRealtime(3.0f);
        SceneManager.LoadScene(cena);

    }

    public void JogarNovamente()
    {
        SceneManager.LoadScene("Gameplay");
    }
    
}
