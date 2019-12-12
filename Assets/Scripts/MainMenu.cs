using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Text highscoretext;
    // Start is called before the first frame update
    void Start()
    {
        highscoretext.text = "Highscore : " + ((int)+PlayerPrefs.GetFloat("Highscore")).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ToGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void ToCharacter()
    {
        SceneManager.LoadScene("Character");
    }
}
