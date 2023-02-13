using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Numbering : MonoBehaviour
{
    public int[] Numbers;

    public int[] numsCounter;

    public Text[] Buttons;

    private Text AddToIt;
    private Text AddToIt1;
    private int AddToIt_INT;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < Numbers.Length; i++)
        {
            Numbers[i] = Random.Range(1, 10);
            numsCounter[Numbers[i]-1] += 1;
            Buttons[i] = GameObject.Find("Number (" + (i+1).ToString() + ")").GetComponentInChildren<Text>();
            Buttons[i].text = Numbers[i].ToString();
        }
        AddToIt = GameObject.Find("AddItUp").GetComponent<Text>();
        AddToIt1 = GameObject.Find("AddItUp (1)").GetComponent<Text>();
        NewNumber(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewNumber(int num0, int num1)
    {
        if (num0 == 0)
        {
            AddToIt_INT = Random.Range(1, 21);
        }
        else
        {
            AddToIt_INT = num0 + num1;
        }
        
        if (AddToIt_INT < 10 && numsCounter[AddToIt_INT - 1] == 0)
        {
            if (num0 == 0)
                NewNumber(0, 0);
        }
        AddToIt1.text = AddToIt_INT.ToString();
        AddToIt.text = AddToIt_INT.ToString();
        FindObjectOfType<Calculations>().AddToIt_INT = AddToIt_INT;
    }
}
