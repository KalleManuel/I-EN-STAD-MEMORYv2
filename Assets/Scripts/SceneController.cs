using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneController : MonoBehaviour
{


    // controll scenes

    public void StartFromStcratch()
    {
        StartCoroutine(WaitforSeconds(1f));
       
    }

    public void StartMenu()
    {
        GameObject joinedPlayers = GameObject.FindGameObjectWithTag("PlayersChoice");
        Destroy(joinedPlayers);

        SceneManager.LoadScene(1);
        


    }

    public void Play()
        {

        SceneManager.LoadScene(2);

        }

     public void PlayAgain()
        {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

     public void doquit()
        {
        Application.Quit();

        }

    IEnumerator WaitforSeconds(float sec)
    {

        yield return new WaitForSeconds(sec);

        StartMenu();

    }

    }
