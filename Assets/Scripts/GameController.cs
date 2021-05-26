using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public UnityEngine.UI.Text scoreLabel;

    public UnityEngine.UI.Image menu;
    public UnityEngine.UI.Button startButton;

    public static bool isStarted = false;

    public static float score = 0;

    // Start is called before the first frame update
    void Start()
    {
        startButton.onClick.AddListener(delegate
        {
            menu.gameObject.SetActive(false);
            isStarted = true;
        });
    }

    // Update is called once per frame
    void Update()
    {
        scoreLabel.text = "Score: " + score;
    }
}
