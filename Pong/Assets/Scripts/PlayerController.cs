using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    private GameObject Player1;
    private GameObject Player2;
    public int P1Score;
    public int P2Score;
    public float speed;
    public Text winner;
    public Text P1ScoreText;
    public Text P2ScoreText;
    public Text WinnerText;
    public Text PauseText;
    public GameObject Winner;
    public int MaxScore;
    public int super1;
    public int super2;
    public Text SuperText1;
    public Text SuperText2;
    public GameObject P1;
    public GameObject P2;
    public GameObject P3;
    public GameObject P4;
    public GameObject NewBall;
    public GameObject NB;
    public GameObject[] Poof;
    public GameObject Pause;
    public GameObject InfoText;
    public GameObject fireworks1;
    public GameObject fireworks2;

    void Start () {
        Time.timeScale = 0;
        PauseText.text = "Ready?";
        InfoText.SetActive(true);
        Pause.SetActive(true);
        Invoke("AddBall", 0);
        super1 = 0;
        super2 = 0;
        WinnerText.text = "";
        fireworks1.SetActive(false);
        fireworks2.SetActive(false);
        Winner.SetActive(false);
        P2Score = 0;
        P1Score = 0;
        Player1 = GameObject.Find("Player1");
        Player2 = GameObject.Find("Player2");
        InvokeRepeating("increaseSuper", 1, 1);
    }

    void AddBall()
    {
        NB = (GameObject)Instantiate(NewBall, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update() {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
                PauseText.text = "Game Paused!";
                Pause.SetActive(false);
                InfoText.SetActive(false);
            }
            else
            {
                Time.timeScale = 0;
                Pause.SetActive(true);
                InfoText.SetActive(true);
            }
        }

        Poof = GameObject.FindGameObjectsWithTag("Ball");

        P1ScoreText.text = "" + P1Score.ToString();
        P2ScoreText.text = "" + P2Score.ToString();

        SuperText1.text = "" + super1;
        SuperText2.text = "" + super2;

        if (P1Score != MaxScore && P2Score != MaxScore)
        {
            if (Poof.Length < 3)
            {
                if (super1 >= 25)
                {
                    P2.SetActive(true);
                    if (Input.GetKeyDown(KeyCode.A))
                    {
                        Invoke("AddBall", 0);
                        super1 -= 25;
                    }
                }
                else
                {
                    P2.SetActive(false);
                }

                if (super2 >= 25)
                {
                    P4.SetActive(true);
                    if (Input.GetKeyDown(KeyCode.RightArrow))
                    {
                        Invoke("AddBall", 0);
                        super2 -= 25;
                    }
                }
                else
                {
                    P4.SetActive(false);
                }
            }
            else
            {
                P2.SetActive(false);
                P4.SetActive(false);
            }
        }

        if (super1 >= 15)
        {
            P1.SetActive(true);
        }
        else
        {
            P1.SetActive(false);
        }

        if (super2 >= 15)
        {
            P3.SetActive(true);
        }
        else
        {
            P3.SetActive(false);
        }

        if (P1Score == MaxScore || P2Score == MaxScore)
        {
            if (P1Score == MaxScore)
            {
                WinnerText.text = "Player 1 Wins!!!";
            }

            if (P2Score == MaxScore)
            {
                WinnerText.text = "Player 2 Wins!!!";
            }

            Winner.SetActive(true);
            P1.SetActive(false);
            P2.SetActive(false);
            P3.SetActive(false);
            P4.SetActive(false);
            fireworks1.SetActive(true);
            fireworks2.SetActive(true);

            foreach(GameObject ball in Poof)
            {
                Destroy(ball, 0);
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        }

        if (winner.text == "")
        {
            if (Player1.transform.position.y < 2.85f)
            {
                if (Input.GetKey(KeyCode.W))
                {
                    //rb.AddForce(0.0f, 20.0f, 0.0f);
                    Player1.transform.Translate(Vector3.up * speed * Time.deltaTime, Space.World);
                }
            }

            if (Player1.transform.position.y > -2.85f)
            {
                if (Input.GetKey(KeyCode.S))
                {
                    //rb.AddForce(0.0f, -20.0f, 0.0f);
                    Player1.transform.Translate(Vector3.down * speed * Time.deltaTime, Space.World);
                }
            }

            if (Player2.transform.position.y < 2.85f)
            {
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    //rbody.AddForce(0.0f, 20.0f, 0.0f);
                    Player2.transform.Translate(Vector3.up * speed * Time.deltaTime, Space.World);
                }
            }

            if (Player2.transform.position.y > -2.85f)
            {
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    //rbody.AddForce(0.0f, -20.0f, 0.0f);
                    Player2.transform.Translate(Vector3.down * speed * Time.deltaTime, Space.World);
                }
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    private void increaseSuper()
    {
        if (WinnerText.text == "")
        {
            super1 += 1;
            super2 += 1;
        }
    }
}