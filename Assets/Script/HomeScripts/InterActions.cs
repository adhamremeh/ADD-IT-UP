using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InterActions : MonoBehaviour
{
    public static bool DidStart = false;
    public static bool Tablet = false;

    public GameObject Back;
    
    public Text SCORE1;
    public Text SCORE2;

    private int HIGHSCORE = 0;

    void Awake()
    {
        if (Screen.width > 1100 && Tablet == false)
        {
            Tablet = true;
            SceneManager.LoadScene(3);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        HIGHSCORE = PlayerPrefs.GetInt("HIGH");
        SCORE1.text = "Your High Score is\n\n" + HIGHSCORE.ToString();
        SCORE2.text = "Your High Score is\n\n" + HIGHSCORE.ToString();
        if (DidStart == true)
        {
            Destroy(Back);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void StartB()
    {
        SceneManager.LoadScene(1);
        DidStart = true;
    }

    public void HowToB()
    {
        SceneManager.LoadScene(2);
        DidStart = true;
    }

    public void StartBTablet()
    {
        SceneManager.LoadScene(4);
    }
    public void HowToBTablet()
    {
        SceneManager.LoadScene(5);
    }
}
