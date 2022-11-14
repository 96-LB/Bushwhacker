using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BushScript : MonoBehaviour
{

    [System.Serializable]
    public record Probability
    {
        [SerializeField]
        Sprite sprite;
        [SerializeField]
        float probability;

        public void Deconstruct(out Sprite sprite, out float probability)
        {
            sprite = this.sprite;
            probability = this.probability;
        }
    }

    public Sprite test;
    public Probability[] mutations;

    // Start is called before the first frame update
    void Start()
    {
        foreach ((Sprite s, float p) in mutations)
        {
            if (Random.Range(0, 1f) < p)
            {
                GetComponent<SpriteRenderer>().sprite = s;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
