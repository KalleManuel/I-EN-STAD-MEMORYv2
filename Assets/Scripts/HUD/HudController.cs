using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudController : MonoBehaviour
{
    public GameObject playersChoices;
    public JoinedPlayers joinedPlayers;


    [Header("Avatars")]
    public GameObject mayorAvatar;
    public GameObject pipAvatar;
    

    public Vector3 firstAvatarPos;
    public Vector3 secondAvatorPos;

    [Header("Score Display")]

    public Text Player1Score;
    public Text Player2Score;

    public int score1 = 0;
    public int score2 = 0;

    public GameObject timerDisplay;
    public GameObject timer;
    public GameObject playerTwoDisplay;

    [Header("Player Turns")]
    public int whosTurn = 1;



    public int guesses = 0;


    public Color activeColor;

    public Color white;

    public int activeSize;
    public int inactiveSize;

    public GameObject pipBackground;
    public GameObject borgisBackground;
    public Sprite greenBack;
    public Sprite redBack;



    // Start is called before the first frame update
    void Start()
    {
        // get components

        playersChoices = GameObject.FindGameObjectWithTag("PlayersChoice");
        joinedPlayers = playersChoices.GetComponent<JoinedPlayers>();

        // set avatars positions
        firstAvatarPos = new Vector3(-200,0, 0);
        secondAvatorPos = new Vector3(210, 0, 0);

        // set avatar start colors

        pipBackground.GetComponent<Image>().sprite = greenBack;
        borgisBackground.GetComponent<Image>().sprite = redBack;

        // set player display

       

       
        if (joinedPlayers.myPlayerMode == JoinedPlayers.PlayerMode.ONEPLAYER)
        {
            playerTwoDisplay.SetActive(false);
            timerDisplay.SetActive(true);
            pipBackground.GetComponent<Image>().sprite = greenBack;
            borgisBackground.GetComponent<Image>().sprite = greenBack;

            if (joinedPlayers.myHelpers == JoinedPlayers.Helpers.MAYOR)
            {
                mayorAvatar.SetActive(true);
                mayorAvatar.transform.localPosition = firstAvatarPos;
                pipAvatar.SetActive(false);
            }
            else if (joinedPlayers.myHelpers == JoinedPlayers.Helpers.PIP)
            {
                pipAvatar.SetActive(true);
                pipAvatar.transform.localPosition = firstAvatarPos;
                mayorAvatar.SetActive(false);
            }


        }
        else if (joinedPlayers.myPlayerMode == JoinedPlayers.PlayerMode.TWOPLAYERS)
        {
            playerTwoDisplay.SetActive(true);
            timerDisplay.SetActive(false);
            pipBackground.GetComponent<Image>().sprite = greenBack;
            borgisBackground.GetComponent<Image>().sprite = redBack;

            if (joinedPlayers.myHelpers == JoinedPlayers.Helpers.BOTH)
            {
                pipAvatar.SetActive(true);
                mayorAvatar.SetActive(true);
                pipAvatar.transform.localPosition = firstAvatarPos;
                mayorAvatar.transform.localPosition = secondAvatorPos;
            }

        }

        Player1Score.text = "" + score1;
        Player2Score.text = "" + score2;

    }

    // Update is called once per frame
    void Update()
    {
        if (joinedPlayers.myPlayerMode == JoinedPlayers.PlayerMode.ONEPLAYER)
        {
            Player1Score.text = "" + guesses;

        }

        else if (joinedPlayers.myPlayerMode == JoinedPlayers.PlayerMode.TWOPLAYERS)
        {
            Player1Score.text = "" + score1;
            Player2Score.text = "" + score2;

            if (whosTurn == 1)
            {
                pipBackground.GetComponent<Image>().sprite = greenBack;
                borgisBackground.GetComponent<Image>().sprite = redBack;

                Player1Score.color = activeColor;
                Player2Score.color = white;
                if (Player1Score.fontSize < 65)
                {
                    Player1Score.fontSize++;
                }

                if (Player2Score.fontSize > 35)
                {
                    Player2Score.fontSize--;
                }


            }


            else if (whosTurn == 2)
            {
                pipBackground.GetComponent<Image>().sprite = redBack;
                borgisBackground.GetComponent<Image>().sprite = greenBack;

                Player1Score.color = white;
                Player2Score.color = activeColor;

                if (Player1Score.fontSize > 35)
                {
                    Player1Score.fontSize--;
                }

                if (Player2Score.fontSize < 60)
                {
                    Player2Score.fontSize++;
                }

            }

        }

    }

    public void ChangePlayer()
    {
        whosTurn++;

        if (whosTurn > 2)
        {
            whosTurn = 1;

        }
    }

    public void Givescore()
    {
        if (whosTurn == 1)
        {
            score1++;
        }

        else if (whosTurn == 2)
        {
            score2++;
        }

    }
}
