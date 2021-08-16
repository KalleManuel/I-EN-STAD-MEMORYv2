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
                    sfx.sfxPlayer.PlayOneShot(sfx.endTalk[0], sfx.SfxVolume);
                }

                else if (endTime.timerValue < 20)
                {
                    sfx.sfxPlayer.PlayOneShot(sfx.endTalk[1], sfx.SfxVolume);
                }

                else if (endTime.timerValue < 30)
                {
                    sfx.sfxPlayer.PlayOneShot(sfx.endTalk[2], sfx.SfxVolume);
                }

                else if (endTime.timerValue < 60)
                {
                    sfx.sfxPlayer.PlayOneShot(sfx.endTalk[3], sfx.SfxVolume);
                }
                else if (endTime.timerValue < 90)
                {
                    sfx.sfxPlayer.PlayOneShot(sfx.endTalk[4], sfx.SfxVolume);
                }

                else if (endTime.timerValue < 120)
                {
                    sfx.sfxPlayer.PlayOneShot(sfx.endTalk[5], sfx.SfxVolume);
                }

                else if (endTime.timerValue < 300)
                {
                    sfx.sfxPlayer.PlayOneShot(sfx.endTalk[6], sfx.SfxVolume);
                }
            }

            else if (myChoice.myHelpers == JoinedPlayers.Helpers.MAYOR)
            {
                if (endTime.timerValue < 10)
                {
                    sfx.sfxPlayer.PlayOneShot(sfx.endTalk[7], sfx.SfxVolume);
                }

                else if (endTime.timerValue < 20)
                {
                    sfx.sfxPlayer.PlayOneShot(sfx.endTalk[8], sfx.SfxVolume);
                }

                else if (endTime.timerValue < 30)
                {
                    sfx.sfxPlayer.PlayOneShot(sfx.endTalk[9], sfx.SfxVolume);
                }

                else if (endTime.timerValue < 60)
                {
                    sfx.sfxPlayer.PlayOneShot(sfx.endTalk[10], sfx.SfxVolume);
                }
                else if (endTime.timerValue < 90)
                {
                    sfx.sfxPlayer.PlayOneShot(sfx.endTalk[11], sfx.SfxVolume);
                }

                else if (endTime.timerValue < 120)
                {
                    sfx.sfxPlayer.PlayOneShot(sfx.endTalk[12], sfx.SfxVolume);
                }

                else if (endTime.timerValue < 300)
                {
                    sfx.sfxPlayer.PlayOneShot(sfx.endTalk[13], sfx.SfxVolume);
                }
            }
        }

        else if (myChoice.myPlayerMode == JoinedPlayers.PlayerMode.TWOPLAYERS)
        {
            if (hud.score1 > hud.score2)
            {
                pepTalk.text = "Grattis Lag Pip!";
                sfx.sfxPlayer.PlayOneShot(sfx.endTalk[Random.Range(14, 17)]);
            }


            else if (hud.score2 > hud.score1)
            {
                pepTalk.text = "Grattis Lag Borgmästaren!";
                sfx.sfxPlayer.PlayOneShot(sfx.endTalk[Random.Range(18, 19)]);
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

