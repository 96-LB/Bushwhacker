using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BushCreator : MonoBehaviour
{

    public static GameObject[][] createBushesFromMap(bool[][] map, GameObject bush, Vector2 bottomLeft, Vector2 spacing)
    {
        GameObject[][] bushes = new GameObject[map.Length][];
        Vector2 curr = bottomLeft;
        for (int row = 0; row < map.Length; row++)
        {
            bushes[row] = new GameObject[map[row].Length];
            curr.x = bottomLeft.x;
            for (int col = 0; col < map[row].Length; col++)
            {
                if (map[row][col])
                {
                    bushes[row][col] = Instantiate(bush, new Vector3(curr.x, curr.y, 0), Quaternion.identity);
                }
                curr.x += spacing.x;
            }
            curr.y += spacing.y;
        }
        return bushes;
    }
}
