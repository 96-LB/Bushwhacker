using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PixelArtCreator : MonoBehaviour
{
    public int mapWidth;
    public int mapHeight;

    GameObject[][] bushes;

    // Start is called before the first frame update
    void Start()
    {
        CreatePixelArt(mapWidth, mapHeight);
    }

    public void CreatePixelArt(int width, int height)
    {
        BushCreator bushCreator = Camera.main.GetComponent<BushCreator>();

        bool[][] map = new bool[8][7];
        map[0] = {false, false, false, false, false, false, false};
        map[1] = {false, false, true, true, true, false, false};
        map[2] = {false, true, true, true, true, true, false};
        map[3] = {false, true, false, true, false, true, false};
        map[4] = {false, true, true, true, true, true, false};
        map[5] = {false, false, true, true, true, false, false};
        map[6] = {false, false, true, false, true, false, false};
        map[7] = {false, false, false, false, false, false, false};

        bushes = bushCreator.createBushesFromMap(map, new Vector2(-30, -30), new Vector2(4, 4));
    }

    public bool[][] GetPixelArt()
    {
        return bushes.Select(row => row.Select(x => (bool)x).ToArray()).ToArray();
    }
}
