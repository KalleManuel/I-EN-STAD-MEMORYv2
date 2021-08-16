using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndGame : MonoBehaviour
{
    [Header("End and score")]


    public GameObject gameoverplate;
    public Text endMessage;
    public Text endmessage2;
    public TMP_Text pepTalk;

    public VoiceAndSFX sfx;
    public HudController hud;
    public JoinedPlayers myChoice;

    public AudioSource music;

    // Start is called before the first frame update
    void Start()
    {
        gameoverplate.SetActive(false);

        GameObject SFX = GameObject.FindGameObjectWithTag("SFX");
        sfx = SFX.GetComponent<VoiceAndSFX>();

        GameObject HUD = GameObject.FindGameObjectWithTag("HUD");
        hud = HUD.GetComponent<HudController>();

        GameObject PC = GameObject.FindGameObjectWithTag("PlayersChoice");
        myChoice = PC.GetComponent<JoinedPlayers>();

        GameObject musicController = GameObject.FindGameObjectWithTag("Music");
        music = musicController.GetComponent<AudioSource>();

    }

    public IEnumerator DisplayEnd()
    {
        yield return new WaitForSeconds(0.5f);
        
        music.Stop();

        gameoverplate.SetActive(true);

        if (myChoice.myPlayerMode == JoinedPlayers.PlayerMode.ONEPLAYER)
        {
            Timer endTime = hud.timer.GetComponent<Timer>();

            pepTalk.text = "Bra hittat!";
            endMessage.text = "Tid: " + endTime.timer.text;
            endmessage2.text = "Försök: " + hud.guesses;

            if (myChoice.myHelpers == JoinedPlayers.Helpers.PIP)
            {
                if (endTime.timerValue < 10)
                {
                    sfx.PlayEndTalk(0);
                }

                else if (endTime.timerValue < 20)
                {
                    sfx.PlayEndTalk(1);
                }

                else if (endTime.timerValue < 30)
                {
                    sfx.PlayEndTalk(2);
                }

                else if (endTime.timerValue < 60)
                {
                    sfx.PlayEndTalk(3);
                }
                else if (endTime.timerValue < 90)
                {
                    sfx.PlayEndTalk(4);
                }

                else if (endTime.timerValue < 120)
                {
                    sfx.PlayEndTalk(5);
                }

                else if (endTime.timerValue < 300)
                {
                    sfx.PlayEndTalk(6);
                }
            }

            else if (myChoice.myHelpers == JoinedPlayers.Helpers.MAYOR)
            {
                if (endTime.timerValue < 10)
                {
                    sfx.PlayEndTalk(7);
                }

                else if (endTime.timerValue < 20)
                {
                    sfx.PlayEndTalk(8);
                }

                else if (endTime.timerValue < 30)
                {
                    sfx.PlayEndTalk(9);
                }

                else if (endTime.timerValue < 60)
                {
                    sfx.PlayEndTalk(10);
                }
                else if (endTime.timerValue < 90)
                {
                    sfx.PlayEndTalk(11);
                }

                else if (endTime.timerValue < 120)
                {
                    sfx.PlayEndTalk(12);
                }

                else if (endTime.timerValue < 300)
                {
                    sfx.PlayEndTalk(13);
                }
            }
        }

        else if (myChoice.myPlayerMode == JoinedPlayers.PlayerMode.TWOPLAYERS)
        {
            if (hud.score1 > hud.score2)
            {
                pepTalk.text = "Grattis Lag Pip!";
                sfx.PlayEndTalk(Random.Range(14, 17));
            }


            else if (hud.score2 > hud.score1)
            {
                pepTalk.text = "Grattis Lag Borgmästaren!";
                sfx.PlayEndTalk(Random.Range(18, 19));
            }


            else if (hud.score1 == hud.score2)
            {
                pepTalk.text = "Lika! Grattis till er båda!";
            }

            endMessage.text = "Team Pip: " + hud.score1;
            endmessage2.text = " Team Borgis: " + hud.score2;
        }
    }


}

