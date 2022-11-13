using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BushCreator : MonoBehaviour
{
    public GameObject bushPreFab;
    public GameObject lawn;

    public void createBushesFromMap(bool[][] map, Vector2 topLeft, Vector2 spacing)
    {
        Vector2 curr = topLeft;
        for (int row = 0; row < map.Length; row++)
        {
            curr.x = topLeft.x;
            for (int col = 0; col < map[row].Length; col++)
            {
                if (map[row][col])
                {
                    Instantiate(bushPreFab, new Vector3(curr.x, curr.y, 0), Quaternion.identity);
                }
                curr.x += spacing.x;
            }
            curr.y += spacing.y;
        }
    }
}
