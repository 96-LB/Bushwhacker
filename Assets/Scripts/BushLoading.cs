using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BushLoading : MonoBehaviour
{

    public void Start()
    {
        debug(LoadImage("a"));
        debug(LoadImage("b"));
    }

    static void debug(bool[][] a) {
        string o = "";
        foreach (bool[] i in a)
        {
            foreach (bool j in i)
                o += j ? 1 : 0;
            o += "\n";
        }
        Debug.Log(o);

    }


    public static bool[][] LoadImage(string name)
    {
        Texture2D texture = (Texture2D)Resources.Load($"bushes/{name}");

        bool[][] output = new bool[texture.height][];
        for (int i = 0; i < texture.height; i++)
        {
            output[i] = new bool[texture.width];
            for (int j = 0; j < texture.width; j++)
            {
                output[i][j] = texture.GetPixel(j, i) == Color.black;
            }
        }

        return output;
    }

}
