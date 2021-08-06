using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EasyLevel : MonoBehaviour {

    public float offsetAngle;

    [SerializeField]
    private Transform puzzleField;

    [SerializeField]
    private GameObject btn;

    public GameObject playersChoices;
    public JoinedPlayers ChoiceOfLevel;
 

    void Awake()
    {
        playersChoices = GameObject.FindGameObjectWithTag("PlayersChoice");
        ChoiceOfLevel = playersChoices.GetComponent<JoinedPlayers>();


        if (ChoiceOfLevel.myDyfficulty == JoinedPlayers.Difficulty.EASY)
        {
            for (int i = 0; i < 8; i++)
            {
                GameObject button = Instantiate(btn);
                button.name = "" + i;
                button.transform.SetParent(puzzleField, false);
                offsetAngle = Random.Range(-5, 5);
                Vector3 offset = new Vector3(0, 0, offsetAngle);
                button.transform.rotation = Quaternion.Euler(0, 0, offsetAngle);
            }

            
        }

        else if (ChoiceOfLevel.myDyfficulty == JoinedPlayers.Difficulty.MEDIUM)
        {
           

            for (int i = 0; i < 18; i++)
            {
                GameObject button = Instantiate(btn);
                button.name = "" + i;
                button.transform.SetParent(puzzleField, false);
                offsetAngle = Random.Range(-5, 5);
                Vector3 offset = new Vector3(0, 0, offsetAngle);
                button.transform.rotation = Quaternion.Euler(0, 0, offsetAngle);

            }
        }

        else if (ChoiceOfLevel.myDyfficulty == JoinedPlayers.Difficulty.HARD)
        {
            for (int i = 0; i < 40; i++)
            {
                GameObject button = Instantiate(btn);
                button.name = "" + i;
                button.transform.SetParent(puzzleField, false);
                offsetAngle = Random.Range(-5, 5);
                Vector3 offset = new Vector3(0, 0, offsetAngle);
                button.transform.rotation = Quaternion.Euler(0, 0, offsetAngle);

            }

        }
    }

    

}
