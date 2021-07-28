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
    public Button pipButton;
    public Button mayorButton;
    public Color chosen;
    public Color disabled;

    public int dificulty;

    public Animator anim;

    public Vector3 pos1;
    public Vector3 pos2;
    public Vector3 pos3;
    public GameObject ram;

    public float speed;

        // Start is called before the first frame update
        void Start()
    {
        //Default playmode
        onePlayerGame = true;
        twoPlayerGame = false;

        //default helper
        mayor = false;
        pip = true;


        // default difficulty
        dificulty = 1;
        speed = 5;

        pos1 = new Vector3(-1.5f, -1.36f, 0);
        pos2 = new Vector3(0, -1.36f, 0);
        pos3 = new Vector3(1.5f, -1.36f, 0);


    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;

        if (dificulty == 1)
        { 
            ram.transform.position = Vector3.MoveTowards(ram.transform.position, pos1, step);
        }


        else if (dificulty == 2)
        {
            ram.transform.position = Vector3.MoveTowards(ram.transform.position, pos2, step);
        }

        else if (dificulty == 3)
        {
            ram.transform.position = Vector3.MoveTowards(ram.transform.position, pos3, step);
        }

        if (twoPlayerGame)
        {
            pipButton.image.color = chosen;
            mayorButton.image.color = chosen;
        }

       else if (mayor)
        {
            pipButton.image.color = disabled;
            mayorButton.image.color = chosen;
        }

        else if (pip)
        {
            pipButton.image.color = chosen;
            mayorButton.image.color = disabled;
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
        }
        else return;
      
    }

    // select helper (with buttons)

    public void SelectMayor()
    {
        if (pip)
        {
            mayor = true;
            pip = false;
           
        } 
    } 

    public void SelectPip() 
    {
        if (mayor)
        {
            pip = true;
            mayor = false;
        }
    }

    public void SelectEasy()
    {
        dificulty = 1;
    }

    public void SelectMedium()
    {
        dificulty = 2;
    }

    public void SelectHard()
    {
        dificulty = 3;
    }

    //Start Button

    public void StartGame()
    {
        if (onePlayerGame)
        {
            if (mayor)
            {
                Debug.Log("One player - Mayor");
            }

            else if (pip)
            {
                Debug.Log("One player - Pip");
            }
        }

        else if (twoPlayerGame)
        {
            Debug.Log("Two player game");
        }

        if (dificulty == 1)
        {
            Debug.Log("Easy");
        }

        if (dificulty == 2)
        {
            Debug.Log("Medium");
        }

        if (dificulty == 3)
        {
            Debug.Log("hard");
        }



    }


    public void Playeasy()
    {
        SceneManager.LoadScene(1);
    }

    public void Playmedium()
    {
        SceneManager.LoadScene(2);
    }

    public void Playhard()
    {
        SceneManager.LoadScene(3);
    }
}

