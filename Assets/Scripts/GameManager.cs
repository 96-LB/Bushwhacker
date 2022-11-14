using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{




    static bool started = false;
    static bool chopping = false;
    static GameObject[][] bushes;
    static List<int> scores = new List<int>();
    static bool[][] goal;

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
        if (started)
        {
            if (!(chopping = !chopping)) // evil line
            {
                scores.Add(Mathf.RoundToInt(10000 * Score.MaxScore(GetYard(), goal)));
            }
        }
        else
        {
            chopping = false;
            started = true;
        }

        DestroyBushes();
        if (chopping)
        {
            bool[][] map = BushLoading.GetNoise(17, 17, .85f);
            GameObject bush = Resources.Load<GameObject>("Prefabs/bush");
            bushes = BushCreator.createBushesFromMap(map, bush, new Vector2(-8, -8), new Vector2(1, 1));
        }
        else
        {

            goal = BushLoading.GetImage();
            GameObject bush = Resources.Load<GameObject>("Prefabs/fakebush");
            Vector2 pos = new Vector2(-goal[0].Length / 2, -goal.Length / 2);
            bushes = BushCreator.createBushesFromMap(goal, bush, pos, new Vector2(1, 1));
        }

        return chopping;
    }


    public static void DestroyBushes()
    {
        if (bushes != null)
            foreach (GameObject[] i in bushes)
                foreach (GameObject j in i)
                    Destroy(j);
        bushes = null;
    }


    public static bool[][] GetYard()
    {
        return bushes.Select(row => row.Select(x => (bool)x).ToArray()).ToArray();
    }

    public static int[] GetScores()
    {
        return scores.ToArray();
    }
}
