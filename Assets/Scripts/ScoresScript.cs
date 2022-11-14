using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoresScript : MonoBehaviour
{
    public bool total = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<TextMeshProUGUI>().text = total ? ""+GameManager.GetScore() : "SCORES:\n" + string.Join('\n', GameManager.GetScores());
    }
}
