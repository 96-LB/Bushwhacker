using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{

    public static float Compare(bool[][] yard, bool[][] goal, int x = 0, int y = 0)
    {
        float score1 = 0;
        float max1 = 0;

        float score2 = 0;
        float max2 = 0;


        for (int i = 0; i < goal.Length; i++)
        {
            for (int j = 0; j < goal[i].Length; j++)
            {
                if (goal[i][j])
                {
                    max1++;
                    if (yard[i + y][j + x])
                    {
                        score1 += 1;
                    }
                }
                else
                {
                    max2++;
                    if (!yard[i + y][j + x])
                    {
                        score2++;
                    }
                }
            }
        }

        return (score1 / max1 + score2 / max2) / 2;
    }

    public static float MaxScore(bool[][] yard, bool[][] goal)
    {
        float score = 0;

        for (int i = 0; i <= yard.Length - goal.Length; i++)
        {
            for (int j = 0; j <= yard[0].Length - goal[0].Length; j++)
            {
                score = Mathf.Max(score, Compare(yard, goal, j, i));
            }
        }

        return score;
    }
}
