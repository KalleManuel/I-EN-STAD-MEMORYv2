using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzelLayout : MonoBehaviour
{
    public GameObject gameController;

    public GameObject playersChoices;
    public JoinedPlayers ChoiceOfLevel;
    public GameObject gridControll;
    public GridLayoutGroup puzzleFieldLayout;






    // Start is called before the first frame update
    void Awake()
    {
        // wait with gamecontroll
        gameController.SetActive(false);

        // get components
        playersChoices = GameObject.FindGameObjectWithTag("PlayersChoice");
        ChoiceOfLevel = playersChoices.GetComponent<JoinedPlayers>();

        puzzleFieldLayout = gridControll.GetComponent<GridLayoutGroup>();

        // Set board
        if (ChoiceOfLevel.myDyfficulty == JoinedPlayers.Difficulty.EASY)
        {
            puzzleFieldLayout.cellSize = new Vector2(200, 200);
            puzzleFieldLayout.spacing = new Vector2(30, 30);
            puzzleFieldLayout.constraintCount = 2;

            gameObject.transform.localPosition = new Vector3(0, -80, 0);

           StartGameControll();
        }

        else if (ChoiceOfLevel.myDyfficulty == JoinedPlayers.Difficulty.MEDIUM)
        {
            puzzleFieldLayout.cellSize = new Vector2(130, 130);
            puzzleFieldLayout.spacing = new Vector2(40, 20);
            puzzleFieldLayout.constraintCount = 3;

            gameObject.transform.localPosition = new Vector3(0, -78, 0);

            StartGameControll();
        }

        else if (ChoiceOfLevel.myDyfficulty == JoinedPlayers.Difficulty.HARD)
        {
            puzzleFieldLayout.cellSize = new Vector2(100, 100);
            puzzleFieldLayout.spacing = new Vector2(15, 12);
            puzzleFieldLayout.constraintCount = 5;

            gameObject.transform.localPosition = new Vector3(0, -80, 0);

            StartGameControll();
        }

    }
    // Activate Gamecontroll
    public void StartGameControll()
    {
        gameController.SetActive(true);
    }

}