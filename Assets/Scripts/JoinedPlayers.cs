using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class JoinedPlayers : MonoBehaviour
{

    public int joinedPlayers = 0;

    public GameObject okButton;

    public string player1Name;

    public string player2Name;

    public string player3Name;

    public string player4Name;

    public int level;

    public string[] randomNames1;

    public string[] randomNames2;

    public string[] randomNames3;

    public string[] randomNames4;

    public bool allNamesIn1;
    public bool allNamesIn2;
    public bool allNamesIn3;
    public bool allNamesIn4;



    public TextMeshProUGUI inputField1;
    public TextMeshProUGUI inputField2;
    public TextMeshProUGUI inputField3;
    public TextMeshProUGUI inputField4;




    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        
    }


    public void GetNames()
    {
        
            player1Name = inputField1.GetComponent<TextMeshProUGUI>().text;
            player2Name = inputField2.GetComponent<TextMeshProUGUI>().text;
            player3Name = inputField3.GetComponent<TextMeshProUGUI>().text;
            player4Name = inputField4.GetComponent<TextMeshProUGUI>().text;
        
        

       
    }


    private void Start()
    {
       
    }

   

    private void Update()
    {
        if (player1Name == "")
        {
            allNamesIn1 = false;
        }
        else
        {
            allNamesIn1 = true;
        }

        if (player2Name == "")
        {
            allNamesIn1 = false;
        }
        else
        {
            allNamesIn1 = true;
        }

        if (player3Name == "")
        {
            allNamesIn3 = false;
        }
        else
        {
            allNamesIn3 = true;
        }

        if (player4Name == "")
        {
            allNamesIn4 = false;
        }
        else
        {
            allNamesIn4 = true;
        }

        

        

    }

    public void NoNameInput()
    {
        player1Name = randomNames1[Random.Range(0, 10)];
        player2Name = randomNames2[Random.Range(0, 10)];
        player3Name = randomNames3[Random.Range(0, 10)];
        player4Name = randomNames4[Random.Range(0, 10)];

    }

    public void RandomNames()
    {
        if (player1Name == "")
        {
            player1Name = randomNames1[Random.Range(0, 10)];
        }

        if (player2Name == "")
        {
            player2Name = randomNames2[Random.Range(0, 10)];
        }

        if (player3Name == "")
        {
            player3Name = randomNames3[Random.Range(0, 10)];
        }

        if (player4Name == "")
        {
            player4Name = randomNames4[Random.Range(0, 10)];
        }
    }


    public void OnePlayer()
    {
        joinedPlayers = 1;
    }

    public void TwoPlayers()
    {
        joinedPlayers = 2;
    }

    public void ThreePlayers()
    {
        joinedPlayers = 3;
    }

    public void FourPlayers()
    {
        joinedPlayers = 4;
    }

    public void Level1()
    {
        level = 1;
    }

    public void Level2()
    {
        level = 2;
    }

    public void Level3()
    {
        level = 3;
    }

    
}

