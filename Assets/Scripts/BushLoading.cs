using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BushLoading : MonoBehaviour
{

    private static bool[][][] images;

    public void Start()
    {
        LoadAll();
        debug(GetImage());
        debug(GetImage());
        debug(GetImage());
        debug(GetImage());
        debug(GetImage());
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

    public static void LoadAll()
    {
        images = Resources.LoadAll<Texture2D>("bushes").Select(x => LoadTexture(x)).ToArray();
    }

    private static bool[][] LoadTexture(Texture2D texture)
    {
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

    public static bool[][] GetImage()
    {
        if (images == null || images.Length == 0) throw new System.Exception("no bushes loaded!");
        return images[Random.Range(0, images.Length)];
    }
}
