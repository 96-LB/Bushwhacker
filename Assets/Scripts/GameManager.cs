using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{




    static bool chopping = true;
    static GameObject[][] bushes;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public static bool ToggleGameState()
    {
        chopping = !chopping;
        DestroyBushes();
        if (chopping)
        {
            bool[][] map = BushLoading.GetNoise(17, 17, .85f);
            GameObject bush = Resources.Load<GameObject>("Prefabs/bush");
            bushes = BushCreator.createBushesFromMap(map, bush, new Vector2(-8, -8), new Vector2(1, 1));
        }
        else
        {
            bool[][] map = BushLoading.GetImage();
            GameObject bush = Resources.Load<GameObject>("Prefabs/fakebush");
            Vector2 pos = new Vector2(-map[0].Length / 2, -map.Length / 2);
            bushes = BushCreator.createBushesFromMap(map, bush, pos, new Vector2(1, 1));
        }
        return chopping;
    }


    public static void DestroyBushes()
    {
        if(bushes != null)
            foreach (GameObject[] i in bushes)
                foreach (GameObject j in i)
                    Destroy(j);
        bushes = null;
    }


    public bool[][] GetYard()
    {
        return bushes.Select(row => row.Select(x => (bool)x).ToArray()).ToArray();
    }
}
