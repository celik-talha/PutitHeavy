using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameScript : MonoBehaviour
{
    public float currTime = 0f;
    float startingTime = 10f;
    
    public GameObject clockObject;
    TextMeshProUGUI clockMesh;

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

    int round = 1;
    int playerEndScore;
    int enemyEndScore;
    int playerMatchScore = 0;
    int enemyMatchScore = 0;

    void Start()
    {
        clockMesh = clockObject.GetComponent<TextMeshProUGUI>();
        roundTextMesh = roundText.GetComponent<TextMeshProUGUI>();
        playerPointsMesh = playerPoints.GetComponent<TextMeshProUGUI>();
        enemyPointsMesh = enemyPoints.GetComponent<TextMeshProUGUI>();
        playerMatchScoreTextMesh = playerMatchScoreText.GetComponent<TextMeshProUGUI>();
        enemyMatchScoreTextMesh = enemyMatchScoreText.GetComponent<TextMeshProUGUI>();

        currTime = startingTime;
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

        clockObject.SetActive(false);
        panel.SetActive(true);

        roundTextMesh.text = "Round " + round;

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
        StartCoroutine(restartRound());
        currTime = 10f;
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
        yield return new WaitForSeconds(5);
        playerScript.playerIslive = true;
        camScript.camIsLive = true;
        putScript.putIsLive = true;

        clockObject.SetActive(true);
        panel.SetActive(false);

        round++;
        currTime = 10f;
    }
}
