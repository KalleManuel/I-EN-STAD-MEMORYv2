using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;



public class PictureGameController : MonoBehaviour {

    // Game controll variables

    [Header("Memory Game Settings")]
    [SerializeField]
    private Sprite bgImage;

    public Sprite[] puzzles;

    public List<Sprite> gamePuzzles = new List<Sprite>();

    public List<Button> btns = new List<Button>();

    private bool firstGuess, secondGuess;

    private int countGuesses;
    private int countCorrectGuesses;
    private int gameGuesses;

    private int firstGuessIndex, secondGuessIndex;

    private string firstGuessPuzzle, secondGuessPuzzle;

    public bool firstCard;
    public bool secondCard;
    public int openedCards;


    // shuffle cards

    public Sprite tempGO;

    // Other Scripts


  
   

    [Header("Player Turns")]
    public int whosTurn = 1;



    [Header("Flip cards")]

    public float waitSeconds = 0.0001f;
    public int flipTimer;
    public int rotationSpeed = 5;


    [Header("Inherited Components")]
   
    public VoiceAndSFX sfx;
    public EndGame end;
    public JoinedPlayers myChoice;
    public HudController hud;

    // Lets go!

    void Awake()
    {
    
        puzzles = Resources.LoadAll<Sprite>("Sprites/CARDSV2");

    }
    
    void Start()
    {

        // get components

    
        GameObject hudController = GameObject.FindGameObjectWithTag("HUD");
        hud = hudController.GetComponent<HudController>();

        GameObject playersChoices = GameObject.FindGameObjectWithTag("PlayersChoice");
        myChoice = playersChoices.GetComponent<JoinedPlayers>();

        GameObject sfxCon = GameObject.FindGameObjectWithTag("SFX");
        sfx = sfxCon.GetComponent<VoiceAndSFX>();

        GameObject sceneControl = GameObject.FindGameObjectWithTag("SceneController");
        end = sceneControl.GetComponent<EndGame>();


        //Set game

        ShuffleDeck();
        GetButtons();
        AddGamePuzzles();
        Addlisteners();
        Shuffle(gamePuzzles);
        gameGuesses = gamePuzzles.Count / 2;
        firstCard = false;
        secondCard = false;
        openedCards = 0;


        // Play gong

        sfx.sfxPlayer.PlayOneShot(sfx.SFX[5],sfx.SfxVolume);

      // set correct voices

        if (myChoice.myPlayerMode == JoinedPlayers.PlayerMode.ONEPLAYER)
        {

            if (myChoice.myHelpers == JoinedPlayers.Helpers.MAYOR)
            {
               sfx.negative = sfx.sadMayor;
                sfx.positive = sfx.happyMayor;
            }

            else if (myChoice.myHelpers == JoinedPlayers.Helpers.PIP)
            {
                sfx.positive = sfx.happyPip;
                sfx.negative = sfx.sadPip;
            }
        }
    }

    private void Update()
    {
        // set right voice for right player

        if (myChoice.myPlayerMode == JoinedPlayers.PlayerMode.TWOPLAYERS)
        {

            if (whosTurn == 1)
            {
                sfx.negative = sfx.sadPip;
                sfx.positive = sfx.happyPip;

            }


            else if (whosTurn == 2)
            {
                
                sfx.negative = sfx.sadMayor;
                sfx.positive = sfx.happyMayor;

            }
        }
    }


    void GetButtons()
    {

        GameObject[] objects = GameObject.FindGameObjectsWithTag("PuzzleButton");
        for (int i = 0; i < objects.Length; i++) {
            btns.Add(objects[i].GetComponent<Button>());
            btns[i].image.sprite = bgImage;
        }

    }
    void AddGamePuzzles()
    {
        int looper = btns.Count;
        int index = 0;
        for (int i = 0; i < looper; i++)
        {
            if (index == looper / 2)
            {
                index = 0;
            }


            gamePuzzles.Add(puzzles[index]);
            index++;

        }
    }

        void Addlisteners()
        {
            foreach (Button btn in btns)
            {
                btn.onClick.AddListener(() => PickAPuzzle());
           
            }
        }

        public void PickAPuzzle()
        {
            string name = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
           

        if (!firstGuess)
        {
            
            

            firstGuess = true;
            firstCard = true;
            firstGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
            firstGuessPuzzle = gamePuzzles[firstGuessIndex].name;
        

            // Flip Card

            StartFlip();
           

        } else if (!secondGuess) {

            
            
            secondGuess = true;
            secondCard = true;
            secondGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
            secondGuessPuzzle = gamePuzzles[secondGuessIndex].name;

            StartFlip();
           
          }
        }


    public void StartFlip()
    {
          StartCoroutine(FlipCards());

    }

    IEnumerator FlipCards()
    {
        if (firstCard)
        {
            for (int i = 0; i < 10; i++)
            {
                yield return new WaitForSeconds(waitSeconds);

                btns[firstGuessIndex].transform.Rotate(0, 18, 0);


                flipTimer += 18;

                if (flipTimer == 90 || flipTimer == -90)
                {
                    
                    Flip();
                }
            }
            flipTimer = 0;
        }

        else if (secondCard)
        {
            for (int i = 0; i < 10; i++)
            {
                yield return new WaitForSeconds(waitSeconds);

                btns[secondGuessIndex].transform.Rotate(0, 18, 0);


                flipTimer += 18;

                if (flipTimer == 90 || flipTimer == -90)
                {
                   
                    Flip();
                }
            }
            flipTimer = 0;
        }

    }

    public void Flip()
    {
        if (firstCard)
        {
            btns[firstGuessIndex].image.sprite = gamePuzzles[firstGuessIndex];
            btns[firstGuessIndex].interactable = false;
            firstCard = false;
            sfx.sfxPlayer.PlayOneShot(sfx.SFX[3], sfx.SfxVolume);
        }

        else if (secondCard)
        {
            btns[secondGuessIndex].image.sprite = gamePuzzles[secondGuessIndex];
            countGuesses++;
            sfx.sfxPlayer.PlayOneShot(sfx.SFX[3], sfx.SfxVolume);
            hud.guesses++;
            secondCard = false;
            StartCoroutine(CheckIfThePuzzlesMatch());
        }
    }
   

    IEnumerator CheckIfThePuzzlesMatch ()
    {
        yield return new WaitForSeconds (.5f);

        if (firstGuessPuzzle == secondGuessPuzzle) {

            openedCards += 2;

            if (openedCards == gamePuzzles.Count)
            {
                Timer endTime = hud.timer.GetComponent<Timer>();
                endTime.counting = false;
            }

            sfx.sfxPlayer.PlayOneShot(sfx.positive[Random.Range(0, sfx.positive.Length)], sfx.SfxVolume);

            sfx.sfxPlayer.PlayOneShot(sfx.SFX[1], sfx.SfxVolume);
            hud.Givescore();
           
            

            btns[firstGuessIndex].interactable = false;
            btns[secondGuessIndex].interactable = false;

            btns[firstGuessIndex].image.color = new Color (217, 150, 204, 60);
      

            CheckIfGameIsFinished();
        }

        else { 
            
            yield return new WaitForSeconds(.3f);
            
         
            sfx.sfxPlayer.PlayOneShot(sfx.negative[Random.Range(0, sfx.negative.Length)], sfx.SfxVolume);

            StartCoroutine(FlipCardsback());

        }

        yield return new WaitForSeconds(.5f); 
        firstGuess = secondGuess = false;
        


    }

    IEnumerator FlipCardsback()
    {
        
            for (int i = 0; i < 10; i++)
            {
                yield return new WaitForSeconds(waitSeconds);

                btns[firstGuessIndex].transform.Rotate(0, -18, 0);
                btns[secondGuessIndex].transform.Rotate(0, -18, 0);


            flipTimer += 18;

                if (flipTimer == 90 || flipTimer == -90)
                {
                btns[firstGuessIndex].image.sprite = bgImage;
                btns[secondGuessIndex].image.sprite = bgImage;
                sfx.sfxPlayer.PlayOneShot(sfx.SFX[4], sfx.SfxVolume);
            }
            }
        btns[firstGuessIndex].interactable = true;
        
        hud.ChangePlayer();
        flipTimer = 0;
        
    }


        void CheckIfGameIsFinished() { 
        countCorrectGuesses++;
      
        if (countCorrectGuesses == gameGuesses) {

            
            sfx.sfxPlayer.PlayOneShot(sfx.SFX[2], sfx.SfxVolume);


            StartCoroutine(end.DisplayEnd());
        }

    }

    // shuffles cards on table

  void Shuffle(List<Sprite> list)
    {
      for(int i = 0; i < list.Count; i++)
      {
           Sprite temp = list[i];
           int randomIndex = Random.Range(i, list.Count);
           list[i] = list[randomIndex];
           list[randomIndex] = temp;
       }
  }

    // Shuffles cards in pile

    public void ShuffleDeck()
    {
        for (int i = 0; i < puzzles.Length; i++)
        {
            int rnd = Random.Range(0, puzzles.Length);
            tempGO = puzzles[rnd];
            puzzles[rnd] = puzzles[i];
            puzzles[i] = tempGO;
        }
    }

 }