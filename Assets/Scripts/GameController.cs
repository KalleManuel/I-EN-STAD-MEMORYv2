using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;


public class GameController : MonoBehaviour {

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

    public GameObject gameoverplate;

    public int gameLevel;
    public bool firstCard;
    public bool secondCard;


    // shuffle cards

    public Sprite tempGO;



    // Players turn & score

    public GameObject playersInGame;
    public int thePlayers;

    public string firstPlayerName;
    public string secondPlayerName;
    public string thirdPlayerName;
    public string forthPlayerName;

    public TextMeshProUGUI Player1Score;
    public TextMeshProUGUI Player2Score;
    public TextMeshProUGUI Player3Score;
    public TextMeshProUGUI Player4Score;

    public GameObject scoreHolder1;
    public GameObject scoreHolder2;
    public GameObject scoreHolder3;
    public GameObject scoreHolder4;

    public int score1 = 0;
    public int score2 = 0;
    public int score3 = 0;
    public int score4 = 0;

  

    public int whosTurn = 1;

    public GameObject scoreholderSolo;

    public TextMeshProUGUI counter;

    public int guesses = 0;


    public Color activeColor;

    public Color white;

    public GameObject EndScoreHolder;

    public float waitSeconds = 0.0001f;
    public int flipTimer;
    public int rotationSpeed = 5;
    


    // AUDIO

    // pips talk

    public AudioSource randompos;

    public AudioSource randomneg;

    public AudioClip[] audioClipArray;

    public AudioClip[] audioClipArrayneg;

    // Scoresound

    public AudioSource getPoint;

    // winning game

    public AudioSource success;

    public AudioSource endTalk;

    // Music

    public AudioSource music;

  
    // Cardflips
    public AudioSource cardUp;

    public AudioSource CardDown;

    
    // METHODS

    // at scene awake


    void Awake()
    {
        puzzles = Resources.LoadAll<Sprite>("Sprites/Memcards");
        

        randompos = GetComponent<AudioSource>();
        randomneg = GetComponent<AudioSource>();
    

    
   }
    
    void Start()
    {
        ShuffleDeck();
        GetButtons();
        AddGamePuzzles();
        Addlisteners();
        Shuffle(gamePuzzles);
        gameGuesses = gamePuzzles.Count / 2;
        gameoverplate.SetActive(false);
        firstCard = false;
        secondCard = false;
        


        // get player amount

        playersInGame = GameObject.FindGameObjectWithTag("Players");
        thePlayers = playersInGame.GetComponent<JoinedPlayers>().joinedPlayers;

        firstPlayerName = playersInGame.GetComponent<JoinedPlayers>().player1Name;
        secondPlayerName = playersInGame.GetComponent<JoinedPlayers>().player2Name;
        thirdPlayerName = playersInGame.GetComponent<JoinedPlayers>().player3Name;
        forthPlayerName = playersInGame.GetComponent<JoinedPlayers>().player4Name;

        gameLevel = playersInGame.GetComponent<JoinedPlayers>().level;

    


        // get player scoreboards

        if (thePlayers == 1)

        {
            scoreholderSolo.SetActive(true);

            scoreHolder1.SetActive(false);
            scoreHolder2.SetActive(false);
            scoreHolder3.SetActive(false);
            scoreHolder4.SetActive(false);
        }

        else if (thePlayers == 2)
        {
            TwoInARow();
            scoreHolder1.SetActive(true);
            scoreHolder2.SetActive(true);

            scoreHolder3.SetActive(false);
            scoreHolder4.SetActive(false);
            scoreholderSolo.SetActive(false);


        }

        else if (thePlayers == 3)
        {
            ThreeInARow();
            scoreHolder1.SetActive(true);
            scoreHolder2.SetActive(true);
            scoreHolder3.SetActive(true);



            scoreHolder4.SetActive(false);
            scoreholderSolo.SetActive(false);
        }



        else if (thePlayers == 4)
        {
            scoreHolder1.SetActive(true);
            scoreHolder2.SetActive(true);
            scoreHolder3.SetActive(true);
            scoreHolder4.SetActive(true);

            scoreholderSolo.SetActive(false);
        }

        // replace empty names

        if (firstPlayerName == "")
        {
            firstPlayerName = "Spelare 1";
        }

        if (secondPlayerName == "")
        {
            secondPlayerName = "Spelare 2";
        }

        if (thirdPlayerName == "")
        {
            thirdPlayerName = "Spelare 3";
        }

        if (forthPlayerName == "")
        {
            forthPlayerName = "Spelare 4";
        }
    }

    private void Update()
    {

       

        // sologame scoretext

        counter.text =  firstPlayerName + ": " + guesses + " försök!";

        // Player 1 scoretext

        Player1Score.text = firstPlayerName + ": " + score1;

        // player 2 scoretext

        Player2Score.text =  secondPlayerName + ": " + score2;

        // player 3 scoretext

        Player3Score.text = thirdPlayerName + ": " + score3;

        // player 4 scoretext

        Player4Score.text = forthPlayerName+ ": " + score4;

        //Player Indicator

        if (whosTurn == 1)
        {
         
            Player1Score.color = activeColor;

            Player2Score.color = white;
            Player3Score.color = white;
            Player4Score.color = white;

        }


        else if (whosTurn == 2)
        {

            Player1Score.color = white;

            Player2Score.color = activeColor;
            Player3Score.color = white;
            Player4Score.color = white;
        }

        else if (whosTurn == 3)
        {

            Player1Score.color = white;

            Player2Score.color = white;
            Player3Score.color = activeColor;
            Player4Score.color = white;

            Player4Score.fontStyle = FontStyles.Normal;
        }

        else if (whosTurn == 4)
        {

            Player1Score.color = white;

            Player2Score.color = white;
            Player3Score.color = white;
            Player4Score.color = activeColor;
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
            
            cardUp.Play();

            firstGuess = true;
            firstCard = true;
            firstGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
            firstGuessPuzzle = gamePuzzles[firstGuessIndex].name;

            // Flip Card

            StartFlip();
           

        } else if (!secondGuess) {

            
            cardUp.Play();
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
        }

        else if (secondCard)
        {
            btns[secondGuessIndex].image.sprite = gamePuzzles[secondGuessIndex];
            countGuesses++;
            guesses++;
            secondCard = false;
            StartCoroutine(CheckIfThePuzzlesMatch());
        }
    }
    void ChangePlayer()
    {
        whosTurn++;

            if (whosTurn > thePlayers)
        {
            whosTurn = 1;

        }
    }

    void Givescore()
    {
        if (whosTurn == 1)
        {
            score1++;
        }

        else if (whosTurn == 2)
        {
            score2++;
        }

        else if (whosTurn == 3)
        {
            score3++;
        }

        else if (whosTurn == 4)
        {
            score4++;
        }
    }

    IEnumerator CheckIfThePuzzlesMatch ()
    {
        yield return new WaitForSeconds (.5f);

        if (firstGuessPuzzle == secondGuessPuzzle) {

            randompos.clip = audioClipArray[Random.Range(0, audioClipArray.Length)];
            randompos.PlayOneShot(randompos.clip);

            getPoint.Play();
            Givescore();
           
            yield return new WaitForSeconds(1.5f);

            btns[firstGuessIndex].interactable = false;
            btns[secondGuessIndex].interactable = false;

            btns[firstGuessIndex].image.color = new Color (217, 150, 204, 60);
            // btns[secondGuessIndex].image.color = new Color (0, 0, 0, 0);

            

            CheckIfGameIsFinished();
        }

        else { 

            yield return new WaitForSeconds(.5f);

            CardDown.Play();
            yield return new WaitForSeconds(.3f);
            
            randomneg.clip = audioClipArrayneg[Random.Range(0, audioClipArrayneg.Length)];
            randomneg.PlayOneShot(randomneg.clip);

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
                }
            }
        btns[firstGuessIndex].interactable = true;
        ChangePlayer();
        flipTimer = 0;
        
    }


        void CheckIfGameIsFinished() { 
        countCorrectGuesses++;
      
        if (countCorrectGuesses == gameGuesses) {
         
            success.Play();
            music.Stop();
            endTalk.Play();
            gameoverplate.SetActive(true);
            EndScoreHolder.transform.localPosition = new Vector2(0, -150); 
    
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
    public void TwoInARow()
    {
        if (gameLevel == 1)
        {
            Player1Score.transform.localPosition = new Vector2(-250, 350);

            Player2Score.transform.localPosition = new Vector2(250, 350);
        }
        else if (gameLevel == 2)
        {
            Player1Score.transform.localPosition = new Vector2(-250, 380);

            Player2Score.transform.localPosition = new Vector2(250, 380);
        }

        else if (gameLevel == 3)
        {
            Player1Score.transform.localPosition = new Vector2(-250, 350);

            Player2Score.transform.localPosition = new Vector2(250, 350);
        }

       
    }

        public void ThreeInARow()
    {
        if (gameLevel == 1)
        {
            Player1Score.transform.localPosition = new Vector2(-500, 350);

            Player2Score.transform.localPosition = new Vector2(0, 350);

            Player3Score.transform.localPosition = new Vector2(500, 350);
        }

        else if (gameLevel == 2)
        {
            Player1Score.transform.localPosition = new Vector2(-500, 380);

            Player2Score.transform.localPosition = new Vector2(0, 380);

            Player3Score.transform.localPosition = new Vector2(500, 380);
        }

        else if (gameLevel == 3)
        {
            Player1Score.transform.localPosition = new Vector2(-500, 350);

            Player2Score.transform.localPosition = new Vector2(0, 350);

            Player3Score.transform.localPosition = new Vector2(500, 350);
        }


    }


    

 }