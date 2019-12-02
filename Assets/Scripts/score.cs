using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour {
    private float scoree = 0.0f;

    public Text scoreText;

    private int difficultyLeve = 1;
    private int maxDifficultyLevel = 10;
    private int scoreToNextLevel = 10;

    private bool isDead = false;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (isDead)
       return;
        if (scoree >= scoreToNextLevel)
            LevelUp();
        scoree += Time.deltaTime * difficultyLeve;
        scoreText.text = ((int)scoree).ToString();

    }
    void LevelUp()
    {
        if (difficultyLeve == maxDifficultyLevel)
            return;

        scoreToNextLevel *= 2;
        difficultyLeve++;
       GetComponent<playermove>(). SetSpeed(difficultyLeve);

        Debug.Log(difficultyLeve);
    }
   public void OnDeath()
    {
       isDead = true;
    }

}
