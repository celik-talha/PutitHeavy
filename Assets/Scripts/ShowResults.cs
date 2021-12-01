using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowResults : MonoBehaviour
{
    public GameObject playerPointGo;
    public GameObject enemyPointGo;
    TextMeshProUGUI playerPointMesh;
    TextMeshProUGUI enemyPointMesh;

    int player;
    int enemy;

    void Start()
    {
        playerPointMesh = playerPointGo.GetComponent<TextMeshProUGUI>();
        enemyPointMesh = enemyPointGo.GetComponent<TextMeshProUGUI>();

        player = PlayerPrefs.GetInt("PLAYER");
        enemy = PlayerPrefs.GetInt("ENEMY");

        playerPointMesh.text = player.ToString();
        enemyPointMesh.text = enemy.ToString();
        Cursor.lockState = CursorLockMode.None;
    }
}
