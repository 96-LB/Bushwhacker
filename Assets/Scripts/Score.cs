using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{

    public static float Compare(bool[][] yard, bool[][] goal, int x = 0, int y = 0)
    {
        float score = 0;

        for (int i = 0; i < goal.Length; i++)
        {
            for (int j = 0; j < goal[i].Length; j++)
            {
                if (goal[i][j] == yard[i + y][j + x])
                {
                    score += 1;
                }
            }
        }

        Debug.Log(score);
        return score / (goal.Length * goal[0].Length);
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
