using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public bool onePlayerGame;
    public bool twoPlayerGame;

    public bool mayor;
    public bool pip;
    public bool both;
    public Button pipButton;
    public Button mayorButton;

    public GameObject pipBackground;
    public GameObject borgisBackground;
    public Sprite redBack;
    public Sprite greenBack;
    public Image borgisImage, pipImage;

    public Animator PipFrameshake;
    public Animator borgisFrameShake;

    public int dificulty;

    public Animator anim;

    public Quaternion pos1;
    public Quaternion pos2;
    public Quaternion pos3;
    public GameObject arrow;

    public Text difDisplay;

    public float speed;
   

    public JoinedPlayers joinedPlayers;

    public Image onePlayerImage;
    public Image twoPlayersImage;

    public Color selected;
    public Color deselected;

    public GameObject infoPrefab;


    public float timer;
    public int hint;
    public int TimeUntilNextHint = 20;

    public GameObject SFXController;
    public VoiceAndSFX sfx;

    public GameObject explained;
    public bool helpMode;
    public float helpTime;
    




    // Start is called before the first frame update
    void Start()
    {
        
        //Default playmode
        onePlayerGame = true;
        twoPlayerGame = false;

        helpMode = false;
        //default helper
        mayor = false;
        pip = true;


        // default difficulty
        dificulty = 1;
        speed = 90;

        pos1 =  Quaternion.Euler(new Vector3(0f, 0f, 65f));
        pos2 = Quaternion.Euler(new Vector3(0f, 0f, 0));
        pos3 = Quaternion.Euler(new Vector3(0f, 0f, -65f));

        pipBackground.GetComponent<Image>().sprite = greenBack;
        borgisBackground.GetComponent<Image>().sprite = redBack;

        timer = TimeUntilNextHint;
        hint = 7;

        SFXController = GameObject.FindGameObjectWithTag("SFX");
        sfx = SFXController.GetComponent<VoiceAndSFX>();

        explained.SetActive(false);

        helpTime = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if (helpMode)
        {
            helpTime += Time.deltaTime;

            if (helpTime > 33.5f)
            {
                CloseHelp();
            }
        }

        // Play a hint

        float degreesPerSecond = speed * Time.deltaTime;

        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            sfx.PlayMenuVoice(hint);
       
            timer = TimeUntilNextHint;

            if (hint == 7)
            {
                hint = 8;
            }

            else hint = 7;
        }

        // change rotattion of arrow in dificulty meter

        if (dificulty == 1)
        { 
            arrow.transform.localRotation = Quaternion.RotateTowards(arrow.transform.rotation, pos1, degreesPerSecond);
            difDisplay.text = "Lätt";
            
        }


        else if (dificulty == 2)
        {
            arrow.transform.localRotation = Quaternion.RotateTowards(arrow.transform.rotation, pos2, degreesPerSecond);
            difDisplay.text = "Medel";
            
        }

        else if (dificulty == 3)
        {
            arrow.transform.localRotation = Quaternion.RotateTowards(arrow.transform.rotation, pos3, degreesPerSecond);
            difDisplay.text = "Svår";
           
        }

        if (twoPlayerGame)
        {
            pipBackground.GetComponent<Image>().sprite = greenBack;
            borgisBackground.GetComponent<Image>().sprite = greenBack;
            pipImage.color = selected;
            borgisImage.color = selected;
            onePlayerImage.color = deselected;
            twoPlayersImage.color = selected;



        }

       else if (mayor)
        {
            pipBackground.GetComponent<Image>().sprite = redBack;
            borgisBackground.GetComponent<Image>().sprite = greenBack;
            pipImage.color = deselected;
            borgisImage.color = selected;
            


        }

        else if (pip)
        {
            pipBackground.GetComponent<Image>().sprite = greenBack;
            borgisBackground.GetComponent<Image>().sprite = redBack;
            pipImage.color = selected;
            borgisImage.color = deselected;
            
        }

      

    }
    // select playmode (with buttons)

    public void SelectOnePlayer()
    {
       

        if (twoPlayerGame)
        {
            anim.SetTrigger("GoLeft");
            onePlayerGame = true;
            twoPlayerGame = false;
            both = false;
            onePlayerImage.color = selected;
            twoPlayersImage.color = deselected;
            pipImage.color = selected;
            borgisImage.color = deselected;
            joinedPlayers.myPlayerMode = JoinedPlayers.PlayerMode.ONEPLAYER;
            joinedPlayers.myHelpers = JoinedPlayers.Helpers.PIP;
            timer = TimeUntilNextHint;

            if (!helpMode)
            {
                sfx.PlayMenuVoice(0);
            }

        }
        else return;

    }

    public void SelectTwoPlayers()
    {

        if (onePlayerGame)
        {
            anim.SetTrigger("GoRight");
            onePlayerGame = false;
            twoPlayerGame = true;
            both = true;
            joinedPlayers.myPlayerMode = JoinedPlayers.PlayerMode.TWOPLAYERS;

            joinedPlayers.myHelpers = JoinedPlayers.Helpers.BOTH;
            PipFrameshake.SetTrigger("PShake");
            borgisFrameShake.SetTrigger("BShake");
            timer = TimeUntilNextHint;

            if (!helpMode)
            {
                sfx.PlayMenuVoice(1);
            }
          
        }
        else return;
      
    }

    // select helper (with buttons)

    public void SelectMayor()
    {
        if (pip && onePlayerGame)
        {
            borgisFrameShake.SetTrigger("BShake");
            mayor = true;
            pip = false;

            joinedPlayers.myHelpers = JoinedPlayers.Helpers.MAYOR;
            timer = TimeUntilNextHint;

            if (!helpMode)
            {
                sfx.PlayMenuVoice(3);
            }
        }

        else
        {
           
           

        }
    }

    public void SelectPip()
    {
        if (mayor)
        {

            PipFrameshake.SetTrigger("PShake");
            pip = true;
            mayor = false;
            joinedPlayers.myHelpers = JoinedPlayers.Helpers.PIP;
            timer = TimeUntilNextHint;

            if (!helpMode)
            {
                sfx.PlayMenuVoice(2);
            }
        }

        else
        {
            if (!helpMode)
            {
                sfx.PlayMenuVoice(10);
                timer = TimeUntilNextHint;
            }

        }
    }

    public void SelectEasy()
    {
        dificulty = 1;
        joinedPlayers.myDyfficulty = JoinedPlayers.Difficulty.EASY;
        timer = TimeUntilNextHint;

        if (!helpMode)
        {
            sfx.PlayMenuVoice(4);
        }
    }

    public void SelectMedium()
    {
        dificulty = 2;
        joinedPlayers.myDyfficulty = JoinedPlayers.Difficulty.MEDIUM;
        timer = TimeUntilNextHint;

        if (!helpMode)
        {
            sfx.PlayMenuVoice(5);
        }
    }

    public void SelectHard()
    {
        dificulty = 3; 
        joinedPlayers.myDyfficulty = JoinedPlayers.Difficulty.HARD;
        timer = TimeUntilNextHint;

        if (!helpMode)
        {
            sfx.PlayMenuVoice(6);
        }
    }

    public void Info()
    {

        GameObject infosquare = Instantiate(infoPrefab, new Vector3(0, 0, 0), Quaternion.identity, GameObject.FindGameObjectWithTag("Canvas").transform);
        timer = 500;
    }

    public void Help()
    {
        explained.SetActive(true);
        helpMode = true;
        SelectTwoPlayers();
        SelectPip();
        SelectMedium();

        sfx.PlayMenuVoice(9);
        timer = sfx.menuVoiceClip[9].length + TimeUntilNextHint;

        StartCoroutine(TimeLine());
       
    }

    public void CloseHelp()
    {
        explained.SetActive(false);
        StopAllCoroutines();
        sfx.sfxPlayer.Stop();
        sfx.sfxPlayer.clip = null;
        SelectOnePlayer();
        SelectPip();
        SelectEasy();
        helpMode = false;
        helpTime = 0;
        
    }

    IEnumerator TimeLine()
    {
        yield return new WaitForSeconds(3.1f);
        SelectOnePlayer();

        yield return new WaitForSeconds(3.25f);
        SelectTwoPlayers();

        yield return new WaitForSeconds(2f);
        SelectOnePlayer();

        yield return new WaitForSeconds(1.5f);
        SelectMayor();

        yield return new WaitForSeconds(1.8f);
        SelectPip();

        yield return new WaitForSeconds(2.5f);
        SelectTwoPlayers();

        yield return new WaitForSeconds(10f);
        SelectEasy();

        yield return new WaitForSeconds(0.5f);
        SelectMedium();

        yield return new WaitForSeconds(0.9f);
        SelectHard();
    }  
}

