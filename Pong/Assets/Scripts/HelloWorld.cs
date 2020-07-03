using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelloWorld : MonoBehaviour {

    public Text helloEng;
    public Text helloChn;
    public Text txtFile;
    public TextAsset file;

    // Use this for initialization
    void Start () {
        helloChn.text = "你好, 世界!";
        helloChn.color = Color.black;

        helloEng.text = "Hello, World!";

        txtFile.text = "" + file;

        // Starting in 2 seconds
        // cange the color of the text every 1 seconds
        InvokeRepeating("ChangeColor", 2.0f, 1f);
    }

    // Change the color of the text
    void ChangeColor()
    {
        helloEng.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        helloChn.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        txtFile.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
    }
	
	// Update is called once per frame
	void Update () {
        //if (Input.GetKeyDown("space"))
        //{
            //Debug.Log("Hello, World!");
        //}
    }
}
