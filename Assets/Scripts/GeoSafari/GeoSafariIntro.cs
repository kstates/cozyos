using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GeoSafariIntro : MonoBehaviour
{
    public TextAsset randomGreetingsFile; 
    public Button enterGameButton;
    private Greetings greetings;
    private int greetingsLen;
    private SceneChanger sceneChanger;

    /**
     * Set up the capybara game intro scene, which mostly consists of a random greeting and an invitation to enter the game. 
     * TODO: I might end up moving the game selection from the geosafarigame scene to this scene
     */
    void Start()
    {
        sceneChanger = gameObject.AddComponent<SceneChanger>();

        greetings = JsonUtility.FromJson<Greetings>(randomGreetingsFile.text);
        greetingsLen = greetings.greetings.Length;

        float randomGreeting = Random.Range(0, greetingsLen);
    
        GetComponentInChildren<TextMeshProUGUI>().text = greetings.greetings[(int)randomGreeting].greeting;

    }

    /**
     * Enters the geosafarigame scene, which handles the bulk of the actual geosafari game
     */ 
    private void LaunchGame()
    {
        sceneChanger.ChangeScene("GeoSafariGame");
    } 
}
