using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameMenu : MonoBehaviour
{
    [Header("Menu")]

    public GameObject menuPlate;
    public GameObject sliderBack;

    public HudController hud;
    public JoinedPlayers myChoice;



    // Start is called before the first frame update
    void Start()
    {
        menuPlate.SetActive(false);

        GameObject hudController = GameObject.FindGameObjectWithTag("HUD");
        hud = hudController.GetComponent<HudController>();

        GameObject joinedPlayers = GameObject.FindGameObjectWithTag("PlayersChoice");
        myChoice = joinedPlayers.GetComponent<JoinedPlayers>();
    }

    public void OpenMeny()
    {


        if (myChoice.myPlayerMode == JoinedPlayers.PlayerMode.ONEPLAYER)
        {
            Timer timercounting = hud.timer.GetComponent<Timer>();

            timercounting.counting = false;
            menuPlate.SetActive(true);
            sliderBack.SetActive(false);
        }

        else if (myChoice.myPlayerMode == JoinedPlayers.PlayerMode.TWOPLAYERS)
        {
            menuPlate.SetActive(true);
            sliderBack.SetActive(false);
        }

    }

    public void CloseMenu()
    {
        if (myChoice.myPlayerMode == JoinedPlayers.PlayerMode.ONEPLAYER)
        {
            Timer timercounting = hud.timer.GetComponent<Timer>();

            timercounting.counting = true;
            sliderBack.SetActive(true);
            menuPlate.SetActive(false);
        }

        else if (myChoice.myPlayerMode == JoinedPlayers.PlayerMode.TWOPLAYERS)
        {
            menuPlate.SetActive(false);
        }
    }
}
