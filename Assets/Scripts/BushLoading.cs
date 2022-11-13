using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BushLoading : MonoBehaviour
{

    private static bool[][][] images;

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
        // memoizes images
        if (images == null) images = Resources.LoadAll<Texture2D>("bushes").Select(x => LoadTexture(x)).ToArray();

        return images[Random.Range(0, images.Length)];
    }

    public static bool[][] GetNoise(int width, int height, float threshold = 0.5f)
    {
        bool[][] output = new bool[height][];
        for (int i = 0; i < height; i++)
        {
            output[i] = new bool[width];
            for (int j = 0; j < width; j++)
            {
                output[i][j] = Random.Range(0, 1f) < threshold;
            }
        }

        return output;
    }
}
