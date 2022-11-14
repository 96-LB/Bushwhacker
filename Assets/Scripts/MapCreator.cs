using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MapCreator : MonoBehaviour
{
    public int mapWidth;
    public int mapHeight;
    public GameObject bush;

    GameObject[][] bushes;
    
    // Start is called before the first frame update
    void Start()
    {
        CreateMap(mapWidth, mapHeight);
    }

    public void CreateMap(int width, int height)
    {
        bool[][] map = BushLoading.GetNoise(width, height);
        bushes = BushCreator.createBushesFromMap(map, bush, new Vector2(-30, -30), new Vector2(4, 4));
    }

    public bool[][] GetYard()
    {
        return bushes.Select(row => row.Select(x => (bool)x).ToArray()).ToArray();
    }
}
