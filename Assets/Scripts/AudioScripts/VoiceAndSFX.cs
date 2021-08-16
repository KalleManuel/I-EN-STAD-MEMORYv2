using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VoiceAndSFX : MonoBehaviour
{

    public AudioSource sfxPlayer;
    public float SfxVolume;

    public int scene;

    [Header("Start Scene")]

    public AudioClip [] startClips;

    public bool next, second, third, timeToPlay;

    public float waitBetween;
    public float randomWait;

    [Header("Start Menu")]

    public AudioClip[] menuVoiceClip;

     [Header("Game Scene")]

    public AudioSource audioSource;

    public AudioClip[] happyMayor;

    public AudioClip[] sadMayor;

    public AudioClip[] happyPip;

    public AudioClip[] sadPip;

    public AudioClip[] positive;

    public AudioClip[] negative;

    public AudioClip[] SFX; // 1 get point, 2 sucess, 3 card up, 4 card down, 5 Gong

    public AudioClip[] teamMayor;
    public AudioClip[] teamPip;


    public AudioClip[] endTalk;

    public JoinedPlayers myChoice;
    public HudController hud;

    public int getComponents;


    // Start is called before the first frame update

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    void Start()
    {

        getComponents = 0;
       


        scene = 1;
        SfxVolume = 0.5f;


        second = false;
        third = false;
        next = false;

        StartCoroutine(PlayFirst());
    }

    // Update is called once per frame
    void Update()
    {
        if (getComponents == 1)
        {
            GameObject joinedPlayers = GameObject.FindGameObjectWithTag("PlayersChoice");
            myChoice = joinedPlayers.GetComponent<JoinedPlayers>();
            getComponents = 0;

        }
        else if (getComponents == 2)
        {
            GameObject hudController = GameObject.FindGameObjectWithTag("HUD");
            hud = hudController.GetComponent<HudController>();

            getComponents = 0;
        }
       


        if (scene == 1)
        {
            if (timeToPlay)
            {
                if (second)
                {
                    timeToPlay = false;
                    PlaySecond();

                }

                else if (third)
                {
                    timeToPlay = false;
                    PlayThird();

                }
            }

        }

    }

    IEnumerator WaitClipLenght()
    {
        yield return new WaitForSeconds(waitBetween);

        if (next)
        {
            if (!second && !third)
            {
                second = true;
                third = false;
                next = false;
                timeToPlay = true;
            }


            else if (second)
            {
                second = false;
                third = true;
                next = false;
                timeToPlay = true;
            }

            else if (third)
            {
                second = true;
                third = false;
                next = false;
                timeToPlay = true;
            }


        }

    }


    IEnumerator PlayFirst()
    {
        yield return new WaitForSeconds(1);

  
        sfxPlayer.clip = startClips[0];
        sfxPlayer.Play();

         randomWait = Random.Range(5f, 10f);
        waitBetween = startClips[0].length + randomWait;
        next = true;
        StartCoroutine(WaitClipLenght());

        
    }

    public void PlaySecond()
    {
        sfxPlayer.clip = null;

        sfxPlayer.clip = startClips[1];
        sfxPlayer.Play();
        randomWait = Random.Range(5f, 10f);
        waitBetween = startClips[1].length + randomWait;
        next = true;
        StartCoroutine(WaitClipLenght());
    }

    public void PlayThird()
    {


        //VoicePlayer.clip = pressPlay;
        sfxPlayer.clip = startClips[1];
        sfxPlayer.Play();
        randomWait = Random.Range(5f, 10f);
        waitBetween = startClips[2].length + randomWait;
        next = true;
        StartCoroutine(WaitClipLenght());


    }

    public void PlayMenuVoice(int _index)
    {
        sfxPlayer.clip = menuVoiceClip[_index];
        sfxPlayer.Play();

    }

    public void PlayGong()
    {
        sfxPlayer.PlayOneShot(SFX[5], SfxVolume);
    }

    public void CardupSFX()
    {
        sfxPlayer.PlayOneShot(SFX[3], SfxVolume);
    }

    public void CardDownSFX()
    {
        sfxPlayer.PlayOneShot(SFX[4], SfxVolume);
    }

    public void GivePointSFX()
    {
        sfxPlayer.PlayOneShot(SFX[1], SfxVolume);
    }



    public void PlayHarp()
    {
        sfxPlayer.PlayOneShot(SFX[2], SfxVolume);
    }

    public void SetVoiceOnePlayerGame()
    {
       

        if (myChoice.myPlayerMode == JoinedPlayers.PlayerMode.ONEPLAYER)
        {

            if (myChoice.myHelpers == JoinedPlayers.Helpers.MAYOR)
            {
                negative = sadMayor;
                positive = happyMayor;
            }

            else if (myChoice.myHelpers == JoinedPlayers.Helpers.PIP)
            {
                positive = happyPip;
                negative = sadPip;
            }
        }
    }

    public void SetVoiceForTwoPlayerGame()
    {
        if (hud.whosTurn == 1)
         {
             negative = sadPip;
                positive = happyPip;

            }


            else if (hud.whosTurn == 2)
            {

                negative = sadMayor;
                positive = happyMayor;

            }
        
    }

    public void PlayPositiveVoice()
    {
        if (myChoice.myPlayerMode == JoinedPlayers.PlayerMode.TWOPLAYERS)
        {
            SetVoiceForTwoPlayerGame();
            sfxPlayer.clip = positive[Random.Range(0, positive.Length)];
            sfxPlayer.Play();
        }

        else
        {
            sfxPlayer.clip = positive[Random.Range(0, positive.Length)];
            sfxPlayer.Play();
        }
           

            
    }

    public void PlayNegativeVoice()
    {
        if (myChoice.myPlayerMode == JoinedPlayers.PlayerMode.TWOPLAYERS)
        {
            SetVoiceForTwoPlayerGame();
            sfxPlayer.clip = negative[Random.Range(0, negative.Length)];
            sfxPlayer.Play();
        }

        else
        {
            sfxPlayer.clip = negative[Random.Range(0, negative.Length)];
            sfxPlayer.Play();
        }
    }

    public void PlayEndTalk(int track)
    {
        sfxPlayer.clip = endTalk[track];
        sfxPlayer.Play();
    } 



}
