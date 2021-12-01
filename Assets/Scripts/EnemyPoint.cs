using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPoint : MonoBehaviour
{
    int enemyPoint;
    int round;
    int playerMatchPoint;
    int enemyMatchPoint;

    const int bank = 486;
    int hand = 486;

    public int getEnemyPoint(int round,int playerMatchPoint,int enemyMatchPoint)
    {
        enemyPoint = 0;

        if (playerMatchPoint == 4 && enemyMatchPoint == 4)
        {
            enemyPoint = hand;
            hand = 0;
        }
        else
        {
            if (round == 1)
            {
                enemyPoint = Random.Range(30, 151);
                hand = bank - enemyPoint;
            }

            else if (round == 2)
            {
                if (playerMatchPoint == 1)
                {
                    enemyPoint = Random.Range(20, hand / 5);
                    hand = hand - enemyPoint;
                }
                else if (enemyMatchPoint == 1)
                {
                    enemyPoint = Random.Range(hand / 6, hand / 4);
                    hand = hand - enemyPoint;
                }
                else
                {
                    enemyPoint = Random.Range(1, hand / 5);
                    hand = hand - enemyPoint;
                }
            }

            else if (round == 3)
            {
                if (playerMatchPoint == 2)
                {
                    enemyPoint = Random.Range(1, hand / 8);
                    hand = hand - enemyPoint;
                }
                else if (enemyMatchPoint == 2)
                {
                    enemyPoint = Random.Range(hand / 5, hand / 4);
                    hand = hand - enemyPoint;
                }
                else
                {
                    enemyPoint = Random.Range(hand / 7, hand / 5);
                    hand = hand - enemyPoint;
                }
            }

            else if (round == 4)
            {
                if (playerMatchPoint == 3)
                {
                    enemyPoint = Random.Range(hand / 4, hand / 3);
                    hand = hand - enemyPoint;
                }
                else if (enemyMatchPoint == 3)
                {
                    enemyPoint = Random.Range(hand / 5, hand / 3);
                    hand = hand - enemyPoint;
                }
                else
                {
                    enemyPoint = Random.Range(hand / 6, hand / 4);
                    hand = hand - enemyPoint;
                }
            }

            else if (round == 5)
            {
                if (playerMatchPoint == 4)
                {
                    enemyPoint = Random.Range(hand / 3, hand / 2);
                    hand = hand - enemyPoint;
                }
                else if (enemyMatchPoint == 4)
                {
                    enemyPoint = Random.Range(hand / 3, hand / 2);
                    hand = hand - enemyPoint;
                }
                else if (playerMatchPoint == 3 || enemyMatchPoint == 3)
                {
                    enemyPoint = Random.Range(hand / 4, hand / 3);
                    hand = hand - enemyPoint;
                }
                else
                {
                    enemyPoint = Random.Range(hand / 5, hand / 4);
                    hand = hand - enemyPoint;
                }
            }

            else if (round > 5)
            {
                if (playerMatchPoint == 4)
                {
                    enemyPoint = Random.Range(hand / 3, hand / 2);
                    hand = hand - enemyPoint;
                }
                else if (enemyMatchPoint == 4)
                {
                    enemyPoint = Random.Range(hand / 3, hand / 2);
                    hand = hand - enemyPoint;
                }
                else if (playerMatchPoint == 3 || enemyMatchPoint == 3)
                {
                    enemyPoint = Random.Range(hand / 4, hand / 3);
                    hand = hand - enemyPoint;
                }
                else
                {
                    enemyPoint = Random.Range(hand / 5, hand / 4);
                    hand = hand - enemyPoint;
                }
            }
        }

        return enemyPoint;
    }
}
