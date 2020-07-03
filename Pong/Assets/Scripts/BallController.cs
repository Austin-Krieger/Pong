using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour {
    
    private Rigidbody ballrb;
    public float force;
    public AudioSource audioSource;
    public AudioClip Hit;
    public GameObject hitEffect;
    public GameObject Boom;

    // Use this for initialization
    void Start () {

        float RandX = Random.Range(1, 2);
        float RandY = Random.Range(1, 2);
        float RandDirection = Random.value;
        ballrb = this.GetComponent<Rigidbody>();

        if(RandDirection > 0.5f)
        {
            ballrb.velocity = new Vector3(force * RandX, force * RandY, 0f);
        }
        else
        {
            ballrb.velocity = new Vector3(-(force * RandX), force * RandY, 0f);
        }

    }

    private void Update()
    {
        var G = GameObject.Find("GameManager").GetComponent<PlayerController>();
        if (G.WinnerText.text == "Player 1 Wins!!!" || G.WinnerText.text == "Player 2 Wins!!!")
        {
            Destroy(this, 0.1f);
        }
    }

    void Explode()
    {
        Boom = (GameObject)Instantiate(hitEffect, transform.position, transform.rotation);
        Destroy(Boom, 0.7f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        var G = GameObject.Find("GameManager").GetComponent<PlayerController>();
        if (collision.gameObject.tag == "Player1")
        {
            Invoke("Explode", 0);

            if (G.super1 >= 15)
            {
                if (Input.GetKey(KeyCode.D))
                {
                    ballrb.AddForce(15, 0, 0, ForceMode.Impulse);
                    G.super1 -= 15;
                }
            }
        }

        if (collision.gameObject.tag == "Player2")
        {
            Invoke("Explode", 0);

            if (G.super2 >= 15)
            {
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    ballrb.AddForce(-15, 0, 0, ForceMode.Impulse);
                    G.super2 -= 15;
                }
            }
        }

        audioSource.PlayOneShot(Hit, 0.1f);
    }

    private void OnTriggerEnter(Collider other)
    {
        var G = GameObject.Find("GameManager").GetComponent<PlayerController>();
        if (other.gameObject.tag == "WallLeft")
        {
            //Increase player 2's score
            G.P2Score += 1;
            //Respawn ball
            this.transform.position = new Vector3(6, 0, 0);
            float RandX = Random.Range(1, 2);
            float RandY = Random.Range(1, 2);
            ballrb.velocity = new Vector3(-force * RandX, force * RandY, 0f);
        }

        if (other.gameObject.tag == "WallRight")
        {
            //Increase player 1's score
            G.P1Score += 1;
            //Respawn ball
            this.transform.position = new Vector3(-6, 0, 0);
            float RandX = Random.Range(1, 2);
            float RandY = Random.Range(1, 2);
            ballrb.velocity = new Vector3(force * RandX, force * RandY, 0f);
        }
    }
}