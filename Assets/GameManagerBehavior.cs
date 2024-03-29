using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerBehavior : MonoBehaviour
{
    public Text goldLabel;
    private int gold;
    public int Gold 
    {
        get
        { 
            return gold;
        }

        set
        {
            gold = value;
            goldLabel.GetComponent<Text>().text = "GOLD: " + gold;
        }
    }

    public Text waveLabel;
    public GameObject[] nextWaveLabels;
    public bool gameOver = false;
    private int wave;
    public int Wave
    {
        get
        {
            return wave;
        }

        set
        {
            wave = value;
            if (!gameOver)
            {
                for (int i = 0; i < nextWaveLabels.Length; i++)
                {
                    nextWaveLabels[i].GetComponent<Animator>().SetTrigger("nextWave");
                }
            }
            waveLabel.text = "WAVE: " + (wave + 1);
        }
    }

    public Text healthLabel;
    public GameObject[] healthIndicator;
    private int health;
    public int Health
    {
        get
        {
            return health;
        }

        set
        {
            health = value;
            healthLabel.text = "HEALTH: " + health;

            if (health <= 0 && !gameOver)
            {
                gameOver = true;
                GameObject gameOverText = GameObject.FindGameObjectWithTag("GameOver");
                gameOverText.GetComponent<Animator>().SetBool("gameOver", true);
            }

            for (int i = 0; i < healthIndicator.Length; i++)
            {
                if (i < Health)
                {
                    healthIndicator[i].SetActive(true);
                }
                else
                {
                    healthIndicator[i].SetActive(false);
                }
            }
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        Gold = 1200;
        Wave = 0;
        Health = 5;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
