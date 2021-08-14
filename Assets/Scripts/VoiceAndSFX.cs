using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public AudioClip[] SFX; // 1 get point, 2 sucess, 3 card up, 4 card down

    public AudioClip[] teamMayor;
    public AudioClip[] teamPip;


    public AudioClip[] endTalk;


    // Start is called before the first frame update

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    void Start()
    {
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

        sfxPlayer.PlayOneShot(startClips[1],SfxVolume);
        randomWait = Random.Range(5f, 10f);
        waitBetween = startClips[1].length + randomWait;
        next = true;
        StartCoroutine(WaitClipLenght());
    }

    public void PlayThird()
    {


        //VoicePlayer.clip = pressPlay;
        sfxPlayer.PlayOneShot(startClips[2], SfxVolume);
        randomWait = Random.Range(5f, 10f);
        waitBetween = startClips[2].length + randomWait;
        next = true;
        StartCoroutine(WaitClipLenght());






    }

    }
