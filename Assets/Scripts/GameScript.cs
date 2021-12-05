using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameScript : MonoBehaviour
{
    public float currTime = 0f;
    float startingTime = 45f;
    
    public GameObject clockObject;
    TextMeshProUGUI clockMesh;

    public GameObject joystick;

    public GameObject panel;
    public GameObject roundText;
    public GameObject playerPoints;
    public GameObject enemyPoints;
    public GameObject playerMatchScoreText;
    public GameObject enemyMatchScoreText;
    TextMeshProUGUI roundTextMesh;
    TextMeshProUGUI playerPointsMesh;
    TextMeshProUGUI enemyPointsMesh;
    TextMeshProUGUI playerMatchScoreTextMesh;
    TextMeshProUGUI enemyMatchScoreTextMesh;

    public PutBlock putScript;
    public CameraMovement camScript;
    public PlayerMovement playerScript;
    public EnemyPoint aiPointScript;

    public int round = 1;
    public int playerEndScore;
    public int enemyEndScore;
    public int playerMatchScore = 0;
    public int enemyMatchScore = 0;

    float roundTime = 15f;
    float roundEndTime = 2f;

    bool isMobile;

    void Start()
    {
        clockMesh = clockObject.GetComponent<TextMeshProUGUI>();
        roundTextMesh = roundText.GetComponent<TextMeshProUGUI>();
        playerPointsMesh = playerPoints.GetComponent<TextMeshProUGUI>();
        enemyPointsMesh = enemyPoints.GetComponent<TextMeshProUGUI>();
        playerMatchScoreTextMesh = playerMatchScoreText.GetComponent<TextMeshProUGUI>();
        enemyMatchScoreTextMesh = enemyMatchScoreText.GetComponent<TextMeshProUGUI>();

        currTime = startingTime;
        camScript.checkPlatform();
        isMobile = camScript.isMobile;

        if (!isMobile)
        {
            joystick.SetActive(false);
        }

    }

    void FixedUpdate()
    {
        if (currTime>0)
        {
            currTime -= 1 * Time.deltaTime;
            clockMesh.text = currTime.ToString("0");
        }
        else
        {
            endRound();
        }
    }

    void endRound()
    {
        playerScript.playerIslive = false;
        camScript.camIsLive = false;
        putScript.putIsLive = false;

        if (isMobile)
        {
            joystick.SetActive(false);
        }

        clockObject.SetActive(false);
        panel.SetActive(true);

        roundTextMesh.text = "Round " + round;

        enemyEndScore = aiPointScript.getEnemyPoint(round, playerMatchScore, enemyMatchScore);

        playerEndScore = putScript.score;
        playerPointsMesh.text = playerEndScore.ToString();
        enemyPointsMesh.text = enemyEndScore.ToString();

        if (playerEndScore > enemyEndScore)
        {
            playerMatchScore++;
        }
        else if (playerEndScore < enemyEndScore)
        {
            enemyMatchScore++;
        }
        else
        {
            Debug.Log("tie");
        }

        playerMatchScoreTextMesh.text = playerMatchScore.ToString();
        enemyMatchScoreTextMesh.text = enemyMatchScore.ToString();

        clearWeigher();
        if (playerMatchScore > 4 || enemyMatchScore > 4)
        {
            StartCoroutine(finishGame());
            currTime = 50f;
        }
        else
        {
            StartCoroutine(restartRound());
            currTime = roundTime;
        }
    }

    void clearWeigher()
    {
        GameObject[] clear1 = putScript.line1;
        GameObject[] clear2 = putScript.line2;
        GameObject[] clear3 = putScript.line3;
        GameObject[] clear4 = putScript.line4;

        foreach (var ob in clear1)
        {
            ob.SetActive(false);
        }
        foreach (var ob in clear2)
        {
            ob.SetActive(false);
        }
        foreach (var ob in clear3)
        {
            ob.SetActive(false);
        }
        foreach (var ob in clear4)
        {
            ob.SetActive(false);
        }

        putScript.score = 0;
        putScript.line1Count = 0;
        putScript.line2Count = 0;
        putScript.line3Count = 0;
        putScript.line4Count = 0;
    }

    public IEnumerator restartRound()
    {
        yield return new WaitForSeconds(roundEndTime);
        playerScript.playerIslive = true;
        camScript.camIsLive = true;
        putScript.putIsLive = true;

        if (isMobile)
        {
            joystick.SetActive(true);
        }

        clockObject.SetActive(true);
        panel.SetActive(false);

        round++;
        currTime = roundTime;
    }

    public IEnumerator finishGame()
    {
        yield return new WaitForSeconds(roundEndTime);

        PlayerPrefs.SetInt("PLAYER", playerMatchScore);
        PlayerPrefs.SetInt("ENEMY", enemyMatchScore);

        SceneManager.LoadScene("FinishScene");
    }
}
