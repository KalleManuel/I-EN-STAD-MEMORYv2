using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{

    public AudioClip easy, medium, hard;

    public GameObject playersChoices;
    public JoinedPlayers choiceOfLevel;
    public AudioSource musicPlayer;

    // Start is called before the first frame update
    void Start()
    {
        playersChoices = GameObject.FindGameObjectWithTag("PlayersChoice");
        choiceOfLevel = playersChoices.GetComponent<JoinedPlayers>();

      


        if (choiceOfLevel.myDyfficulty == JoinedPlayers.Difficulty.EASY)
        {
            musicPlayer.clip = easy;
            musicPlayer.loop = true;
            
        }

        else if (choiceOfLevel.myDyfficulty == JoinedPlayers.Difficulty.MEDIUM)
        {
            musicPlayer.clip = medium;
            musicPlayer.loop = true;
        }

        else if (choiceOfLevel.myDyfficulty == JoinedPlayers.Difficulty.HARD)
        {
            musicPlayer.clip = hard;
            musicPlayer.loop = true;
        }

        musicPlayer.Play();
    }

}
