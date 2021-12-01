using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowResults : MonoBehaviour
{
    public GameObject playerPointGo;
    public GameObject enemyPointGo;
    public GameObject resultsGo;

    TextMeshProUGUI playerPointMesh;
    TextMeshProUGUI enemyPointMesh;
    TextMeshProUGUI resultsMesh;


    int player;
    int enemy;

    void Start()
    {
        playerPointMesh = playerPointGo.GetComponent<TextMeshProUGUI>();
        enemyPointMesh = enemyPointGo.GetComponent<TextMeshProUGUI>();
        resultsMesh = resultsGo.GetComponent<TextMeshProUGUI>();

        player = PlayerPrefs.GetInt("PLAYER");
        enemy = PlayerPrefs.GetInt("ENEMY");

        playerPointMesh.text = player.ToString();
        enemyPointMesh.text = enemy.ToString();
        if (player>enemy)
        {
            resultsMesh.text = "You Won!";
        }
        else
        {
            resultsMesh.text = "You Lost!";
        }

        Cursor.lockState = CursorLockMode.None;
    }
}
