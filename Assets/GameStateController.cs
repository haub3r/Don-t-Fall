using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class GameStateController : MonoBehaviour {
    private bool gameOver = false;
    private bool gameCompleted = false;
    public Canvas infoTextCanvas;
    public Canvas gameOverCanvas;
    public Canvas gameCompleteCanvas;
    private float savedTimeScale;

    // Use this for initialization
    void Start () {
        gameOverCanvas = GameObject.Find("GameOverCanvas").GetComponent<Canvas>();
        gameOverCanvas.enabled = false;

        gameCompleteCanvas = GameObject.Find("GameCompleteCanvas").GetComponent<Canvas>();
        gameCompleteCanvas.enabled = false;

        infoTextCanvas = GameObject.Find("InfoTextCanvas").GetComponent<Canvas>();
        infoTextCanvas.enabled = true;
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        else if (gameOver)
        {
            if (Time.timeScale != 0)
            {
                savedTimeScale = Time.timeScale;
            }
            Time.timeScale = 0;

            infoTextCanvas.enabled = false;

            //MouseLookEnabled(false);
            var fpscontroller = GameObject.Find("FPSController").GetComponent<FirstPersonController>();
            fpscontroller.enabled = false;

            gameOverCanvas.enabled = true;

            //gameOverCanvas.enabled = true;
            if (Input.GetKeyDown(KeyCode.R))
            {
                gameOver = false;
                Time.timeScale = savedTimeScale;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        else if (gameCompleted)
        {
            Time.timeScale = 0;
            infoTextCanvas.enabled = false;
            gameCompleteCanvas.enabled = true;

            var fpscontroller = GameObject.Find("FPSController").GetComponent<FirstPersonController>();
            fpscontroller.enabled = false;
        }
    }

    void OnControllerColliderHit(ControllerColliderHit collision)
    {
        if (collision.gameObject.tag == "GameOver")
        {
            Debug.Log("Game Over.");
            gameOver = true;
        }
        else if (collision.gameObject.tag == "GameComplete")
        {
            Debug.Log("Game Completed!");
            gameCompleted = true;
        }
    }

    //private void MouseLookEnabled(bool enable)
    //{
    //    GameObject FPC = GameObject.FindWithTag("Player");

    //    FPC.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().m_MouseLook.m_cursorIsLocked = false;
    //}
}
