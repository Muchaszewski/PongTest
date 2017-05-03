using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Main game controller, handling game states and initialization
/// </summary>
public class GameController : MonoBehaviour
{

    public static GameController Instance { get; private set; }

    /// <summary>
    ///     Top wall collider
    /// </summary>
    [Tooltip("Top wall collider")]
    [SerializeField]
    public Collider2D WallTopCollider;
    /// <summary>
    ///     Bottom wall colider
    /// </summary>
    [Tooltip("Bottom wall colider")]
    [SerializeField]
    public Collider2D WallBottomCollider;

    /// <summary>
    ///     Game object of ball
    /// </summary>
    [Tooltip("Game object of ball")]
    [SerializeField]
    public GameObject BallGameObject;

    /// <summary>
    ///     Player 1 controller (right)
    /// </summary>
    [Tooltip("Player 1 controller (right)")]
    [SerializeField]
    public GenericController Player1;
    /// <summary>
    ///     Player 2 controller (left)
    /// </summary>
    [Tooltip("Player 2 controller (left)")]
    [SerializeField]
    public GenericController Player2;
    /// <summary>
    ///     Player 2 human GameObject prefab (left)
    /// </summary>
    [Tooltip("Player 2 human GameObject prefab (left)")]
    [SerializeField]
    public GameObject Player2Human;

    /// <summary>
    ///     Scoreboard TextMeshProUGUI
    /// </summary>
    [Tooltip("Scoreboard TextMeshProUGUI")]
    [SerializeField]
    public TextMeshProUGUI Scoreboard;
    /// <summary>
    ///     WinText TextMeshProUGUI
    /// </summary>
    [Tooltip("WinText TextMeshProUGUI")]
    [SerializeField]
    public TextMeshProUGUI WinText;
    /// <summary>
    ///     GameSettings Button
    /// </summary>
    [Tooltip("GameSettings Button")]
    [SerializeField]
    public Button GamesettingsButton;

    /// <summary>
    ///     MaxScore required to win the game
    /// </summary>
    [Tooltip("MaxScore required to win the game")]
    [SerializeField]
    public int MaxScore = 3;

    /// <summary>
    ///     Scores for both players, index 1 is player 1 (right), index 2 is player 2 (left) and so on
    /// </summary>
    [HideInInspector]
    public int[] Score;

    /// <summary>
    /// Is one of the player winner;
    /// </summary>
    private bool _isWin;

    void Awake()
    {
        Instance = this;
        Score = new [] { 0, 0 };
        GamesettingsButton.onClick.AddListener(delegate
        {
            var ballActor = BallGameObject.GetComponent<BallActor>();
            ballActor.BouncesRandomly = !ballActor.BouncesRandomly;
            if (ballActor.BouncesRandomly)
            {
                GamesettingsButton.GetComponentInChildren<TextMeshProUGUI>().text = "Randomly bounces";
            }
            else
            {
                GamesettingsButton.GetComponentInChildren<TextMeshProUGUI>().text = "Physics based";
            }
        });
    }

    void Update()
    {
        if (_isWin && Input.GetKeyDown(KeyCode.Space))
        {
            GoToMenu();
        }
    }

    /// <summary>
    ///     Adds score to the right player
    /// </summary>
    public void ScoreLeft()
    {
        Score[0]++;
        UpdateScore();
        BallGameObject.transform.position = Vector3.zero;
        BallGameObject.GetComponent<BallActor>().GenerateBallRandomDireciton();
    }

    /// <summary>
    ///     Adds score to the right player
    /// </summary>
    public void ScoreRight()
    {
        Score[1]++;
        UpdateScore();
        BallGameObject.transform.position = Vector3.zero;
        BallGameObject.GetComponent<BallActor>().GenerateBallRandomDireciton();
    }

    /// <summary>
    ///     Updates score on scoreboard
    /// </summary>
    private void UpdateScore()
    {
        Scoreboard.text = Score[1] + " - " + Score[0];
        if(Score[1] > MaxScore)
        {
            WinGame(2);
        }
        else if(Score[0] > MaxScore)
        {
            WinGame(1);
        }
    }

    private void WinGame(int player)
    {
        _isWin = true;
        WinText.gameObject.SetActive(true);
        WinText.text = "Player " + player + " win! Press space to enter menu.";
        BallGameObject.SetActive(false);
    }

    /// <summary>
    ///     Loads menu scene
    /// </summary>
    private void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

}
