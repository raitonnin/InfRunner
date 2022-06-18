using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Scoring : MonoBehaviour
{
    [SerializeField] private Transform player;
    public TMP_Text scoreText;
    private TMP_Text youDied;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = player.position.z.ToString("0");
    }
    public void YouDied()
    {
        youDied.text = "Game Over";
    }
}
