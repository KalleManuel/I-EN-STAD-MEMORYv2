using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneController : MonoBehaviour
{

    public GameObject playersInGame;


    // Start is called before the first frame update
    void Start()
    {
        playersInGame = GameObject.FindGameObjectWithTag("Players");
    }

    // Update is called once per frame
    void Update()
    {
        
    }


        // controll levels

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

    public void GoToCommercial()
        {
        SceneManager.LoadScene(4);
        GameObject.Destroy(playersInGame);
    }

    public void GoToMenu()
        {
        SceneManager.LoadScene(0);
        GameObject.Destroy(playersInGame);
       }

        public void PlayAgain()
        {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void doquit()
        {
        Application.Quit();

        }

    }
