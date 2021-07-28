using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{

    public GameObject startPlate;
    public GameObject amountPlayers;
    public GameObject levelMenu;
    public GameObject rules;

    public GameObject inputField1;
    public GameObject inputField2;
    public GameObject inputField3;
    public GameObject inputField4;
    public GameObject getPlayers;
    public GameObject okbutton;
    public GameObject giveNames;

    public int JoinedPlayersInt;
    public TextMeshProUGUI playerCount;






    // controll start

    private void Start()
    {
        startPlate.SetActive(true);
        amountPlayers.SetActive(false);
        levelMenu.SetActive(false);

        inputField1.SetActive(false);
        inputField2.SetActive(false);
        inputField3.SetActive(false);
        inputField4.SetActive(false);
        rules.SetActive(false);
        giveNames.SetActive(false);



    }

    public void Update()
    {
        JoinedPlayersInt = getPlayers.GetComponent<JoinedPlayers>().joinedPlayers;


    }


    // Controll plates

    public void PressStart()
    {
        startPlate.SetActive(false);
        amountPlayers.SetActive(true);

    }




    public void HowMenyInputFields()
    {
        if (JoinedPlayersInt == 1)
        {
            giveNames.SetActive(false);
            inputField1.SetActive(true);
            okbutton.transform.localPosition = new Vector2(0, -55);
           
        }

        else if (JoinedPlayersInt == 2)
        {
            giveNames.SetActive(false);
            inputField1.SetActive(true);
            inputField2.SetActive(true);
            okbutton.transform.localPosition = new Vector2(0, -105);
            

        }

        else if (JoinedPlayersInt == 3)
        {
            giveNames.SetActive(false);
            inputField1.SetActive(true);
            inputField2.SetActive(true);
            inputField3.SetActive(true);
            okbutton.transform.localPosition = new Vector2(0, -155);
           
        }

        else if (JoinedPlayersInt == 4)
        {
            giveNames.SetActive(false);
            inputField1.SetActive(true);
            inputField2.SetActive(true);
            inputField3.SetActive(true);
            inputField4.SetActive(true);
            okbutton.transform.localPosition = new Vector2(0, -205);
          
        }

    }


    public void PressAmountPlayers()
    {
        amountPlayers.SetActive(false);

        giveNames.SetActive(true);


    }

    public void GiveNamesYes()
    {
        HowMenyInputFields();
        giveNames.SetActive(false);
    }

    public void GiveNamesNo()
    {
        OKNames();


    }



    public void ReadRules()
    {
        rules.SetActive(true);
        levelMenu.SetActive(false);

    }

    public void OKNames()
    {
        levelMenu.SetActive(true);
        inputField1.SetActive(false);
        inputField2.SetActive(false);
        inputField3.SetActive(false);
        inputField4.SetActive(false);
        giveNames.SetActive(false);
        rules.SetActive(false);
        playerCount.text = JoinedPlayersInt + " spelare";

   

    }

    public void PressNewPlayerAmount()
    {
        amountPlayers.SetActive(true);
        levelMenu.SetActive(false);

    }
}