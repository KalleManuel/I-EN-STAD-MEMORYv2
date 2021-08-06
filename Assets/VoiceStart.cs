using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceStart : MonoBehaviour
{

    public AudioSource VoicePlayer;

    public AudioClip welcome, wannaPlay, pressPlay;

    public bool next, second, third, timeToPlay;

    public float waitBetween;
    public float randomWait;

   

    // Start is called before the first frame update
    void Start()
    {
       
        second = false;
        third = false;
        next = false;

        StartCoroutine(PlayFirst());
    }

    // Update is called once per frame
    void Update()
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

        //VoicePlayer.clip = welcome;
        VoicePlayer.PlayOneShot(welcome, 1);
        randomWait = Random.Range(5f, 10f);
        waitBetween = welcome.length + randomWait;
        next = true;
        StartCoroutine(WaitClipLenght());

        
    }

    public void PlaySecond()
    {
        //VoicePlayer.clip = wannaPlay;
        VoicePlayer.PlayOneShot(wannaPlay,1);
        randomWait = Random.Range(5f, 10f);
        waitBetween = wannaPlay.length + randomWait;
        next = true;
        StartCoroutine(WaitClipLenght());
    }

    public void PlayThird()
    {


        //VoicePlayer.clip = pressPlay;
        VoicePlayer.PlayOneShot(pressPlay, 1);
        randomWait = Random.Range(5f, 10f);
        waitBetween = pressPlay.length + randomWait;
        next = true;
        StartCoroutine(WaitClipLenght());






    }

    }
