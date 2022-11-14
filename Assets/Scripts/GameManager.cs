using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{


    const int ROUNDS = 5;


    static bool started = false;
    static bool chopping = false;
    static GameObject[][] bushes;
    static List<int> scores = new List<int>();
    static bool[][] goal;
    static int round = 0;

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
            scores.Clear();
            round = 0;
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
            round++;
            if (round > ROUNDS)
            {
                started = false;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }

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

    public static int GetScore()
    {
        return scores.Sum();
    }

    public static int[] GetScores()
    {
        return scores.ToArray();
    }
}
