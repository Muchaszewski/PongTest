using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    /// <summary>
    ///     Button for starting Player vs AI
    /// </summary>
    [Tooltip("WinText TextMeshProUGUI")]
    [SerializeField]
    public Button ButtonStartAI;
    /// <summary>
    ///     Button for starting 1v1
    /// </summary>
    [Tooltip("WinText TextMeshProUGUI")]
    [SerializeField]
    public Button ButtonStartVS;

    private AsyncOperation _sceneLoading;

    public void Start()
    {
        _sceneLoading = SceneManager.LoadSceneAsync("Game", LoadSceneMode.Additive);
        _sceneLoading.allowSceneActivation = false;
        ButtonStartAI.onClick.AddListener(delegate
        {
            StartCoroutine(WaitForGame(true));
        });
        ButtonStartVS.onClick.AddListener(delegate
        {
            StartCoroutine(WaitForGame(false));
        });
    }

    public IEnumerator WaitForGame(bool isAI)
    {
        _sceneLoading.allowSceneActivation = true;
        while (!_sceneLoading.isDone)
        {
            yield return new WaitForEndOfFrame();
        }
        if (!isAI)
        {
            var player2 = Instantiate(GameController.Instance.Player2Human);
            SceneManager.MoveGameObjectToScene(player2, SceneManager.GetSceneByName("Game"));

            var temp = GameController.Instance.Player2.PalletteActorScript.gameObject;
            PlayerController instancePlayer2 = player2.GetComponent<PlayerController>();
            instancePlayer2.Player = 1;
            GameController.Instance.Player2 = instancePlayer2;
            Destroy(temp);
        }
        SceneManager.UnloadSceneAsync("Menu");
    }
}
