using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InterActionsPlay : MonoBehaviour
{
    public GameObject PauseCANVAS;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pause()
    {
        PauseCANVAS.SetActive(true);
        Time.timeScale = 0;
    }
    public void Resume()
    {
        PauseCANVAS.SetActive(false);
        Time.timeScale = 1;
    }
    public void Restart()
    {
        if (SceneManager.GetActiveScene().buildIndex != 2 || SceneManager.GetActiveScene().buildIndex != 5)
        {
            FindObjectOfType<InterstitialAd>().ShowAd();
        }
        if (InterActions.Tablet)
            SceneManager.LoadScene(4);
        else
            SceneManager.LoadScene(1);
        PauseCANVAS.SetActive(false);
        Time.timeScale = 0;
    }

    public void Menu()
    {
        if (InterActions.Tablet)
            SceneManager.LoadScene(3);
        else
            SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}
