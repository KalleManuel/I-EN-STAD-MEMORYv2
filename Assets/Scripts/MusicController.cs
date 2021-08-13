using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{

    public AudioClip start, easy, medium, hard;

    public GameObject playersChoices;
    public JoinedPlayers choiceOfLevel;
    public AudioSource musicPlayer;
    public bool gameOn = false;
    public bool changeMusic;


    // Start is called before the first frame update
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        gameOn = false;
        changeMusic = true;
        
    }

    private void Update()
    {
        if (!gameOn && changeMusic)
        {
            musicPlayer.clip = start;
            musicPlayer.Play();
            musicPlayer.loop = true;
            changeMusic = false;
        }

        else if (gameOn && changeMusic)
        {
            playersChoices = GameObject.FindGameObjectWithTag("PlayersChoice");
            choiceOfLevel = playersChoices.GetComponent<JoinedPlayers>();

            if (choiceOfLevel.myDyfficulty == JoinedPlayers.Difficulty.EASY)
            {
                musicPlayer.clip = easy;

            }

            else if (choiceOfLevel.myDyfficulty == JoinedPlayers.Difficulty.MEDIUM)
            {
                musicPlayer.clip = medium;

            }

            else if (choiceOfLevel.myDyfficulty == JoinedPlayers.Difficulty.HARD)
            {
                musicPlayer.clip = hard;

            }

            musicPlayer.Play();
            musicPlayer.loop = true;
            changeMusic = false;
        }
    }

}
