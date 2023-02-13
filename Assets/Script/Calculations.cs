using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Calculations : MonoBehaviour
{
    public int AddToIt_INT;
    public int Sum;

    private int SumCounter;
    private int winsCounter = 0;
    private int TotalScore;
    public int HighScore;
    
    private float BonusTime = 100;

    public Color ClickedColor;
    public Color ReleasedColor;
    public Color DisabledColor;

    public GameObject[] Buttons;
    public GameObject ScoreObject;
    public GameObject winPanel;
    public GameObject LosePanel;

    public bool[] ButtonsDisabled;
    private bool win = false;

    public Text ScoreTXT;
    public Text ScoreTXT1;
    public Text Timer;
    public Text Timer1;
    public Text winPanelScore;
    public Text winPanelHighScore;

    public Text LosePanelScore;
    public Text LosePanelHighScore;

    // Start is called before the first frame update
    void Start()
    {
        HighScore = PlayerPrefs.GetInt("HIGH");
        for (int i = 0; i < Buttons.Length; i++)
        {
            Buttons[i] = GameObject.Find("Number (" + (i + 1).ToString() + ")");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (winsCounter < 15)
        {
            BonusTime -= Time.deltaTime*8; 
        }
        else if (winsCounter >= 15 && winsCounter < 30)
        {
            BonusTime -= Time.deltaTime * 9;
        }
        else if (winsCounter >= 30 && winsCounter < 45)
        {
            BonusTime -= Time.deltaTime * 10;
        }
        else if (winsCounter >= 45 && winsCounter < 60)
        {
            BonusTime -= Time.deltaTime * 11;
        }
        else if (winsCounter >= 60)
        {
            BonusTime -= Time.deltaTime * 11;
        }
        Timer.text = ((int)BonusTime).ToString();
        Timer1.text = ((int)BonusTime).ToString();
        if (BonusTime < 0 && win == false)
        {
            BonusTime = 0;
            LosePanel.SetActive(true);
            LosePanelScore.text = "Your score is\n" + ScoreTXT.text;
            LosePanelHighScore.text = "Your HighScore is\n" + HighScore.ToString();
        }
    }

    public void Summition(string Name)
    {
        GameObject.Find(Name).GetComponent<Image>().color = ClickedColor;
        GameObject.Find(Name).GetComponent<Button>().interactable = false;

        Sum = Sum + int.Parse(GameObject.Find(Name).GetComponentInChildren<Text>().text);
        SumCounter += 1;
        if (Sum > AddToIt_INT)
        {
            Sum = 0;
            SumCounter = 0;
            ResetColors();
        }
        else if (Sum == AddToIt_INT)
        {
            Calculate_Score(SumCounter);
            Disabling();
            Sum = 0;
        }
    }

    private void Calculate_Score(int Counter)
    {
        TotalScore = TotalScore + (SumCounter*50*SumCounter) + (int)BonusTime;
        ScoreTXT.text = TotalScore.ToString();
        ScoreTXT1.text = TotalScore.ToString();
        BonusTime = 100;
    }

    private void ResetColors()
    {
        for (int i = 0; i < Buttons.Length; i++)
        {
            if (Buttons[i].GetComponent<Image>().color == ClickedColor)
            {
                Buttons[i].GetComponent<Button>().interactable = true;
                Buttons[i].GetComponent<Image>().color = ReleasedColor;
            }
        }
    }
    private void Disabling()
    {
        for (int i = 0; i < Buttons.Length; i++)
        {
            if (Buttons[i].GetComponent<Image>().color == ClickedColor)
            {
                GameObject NewScore = Instantiate(ScoreObject, Buttons[i].GetComponent<RectTransform>());
                NewScore.GetComponent<RectTransform>().localPosition = new Vector3(0,0,0);
                NewScore.GetComponentInChildren<Text>().text = (SumCounter * 50).ToString();
                Buttons[i].GetComponent<Image>().color = DisabledColor;
                Buttons[i].GetComponent<Button>().interactable = false;
                Buttons[i].GetComponentInChildren<Text>().enabled = false;
                FindObjectOfType<Numbering>().numsCounter[int.Parse(Buttons[i].GetComponentInChildren<Text>().text)-1] -= 1;
                ButtonsDisabled[i] = true;
            }
        }
        SumCounter = 0;
        CheckWin();
    }

    private void CheckWin()
    {
        win = true;
        winsCounter = 0;
        for (int i = 0; i < ButtonsDisabled.Length; i++)
        {
            if (ButtonsDisabled[i] == false)    
                win = false;
            else 
                winsCounter += 1;
        }
        if (win == true)
        {
            winPanelScore.text = "Your score is\n" + ScoreTXT.text;
            winPanelHighScore.text = "Your HighScore is\n" + HighScore.ToString();
            winPanel.SetActive(true);
        }        
        if (winsCounter > 69)
        {
            int num0 = 0;
            int num1 = 0;
            for (int i = 0; i < Buttons.Length; i++)
            {   
                if (ButtonsDisabled[i] == false)
                {
                    if (num0 == 0)
                    {
                        num0 = int.Parse(Buttons[i].GetComponentInChildren<Text>().text);
                    }
                    else
                    {
                        num1 = int.Parse(Buttons[i].GetComponentInChildren<Text>().text);
                        
                    }
                        FindObjectOfType<Numbering>().NewNumber(num0, num1);
                }
            }
        }
        else
        {
            FindObjectOfType<Numbering>().NewNumber(0, 0);
        }
    }
    
    void OnDestroy()
    {
        Debug.Log("HIGH:" + HighScore);
        Debug.Log("Score:" + TotalScore);
        if (HighScore < TotalScore)
        {
            PlayerPrefs.SetInt("HIGH", TotalScore);
        }
        //PlayerPrefs.SetInt("HIGH", 0);
    }

}
