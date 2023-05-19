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

    // Start is called before the first frame update
    void Start()
    {
        sceneChanger = gameObject.AddComponent<SceneChanger>();

        greetings = JsonUtility.FromJson<Greetings>(randomGreetingsFile.text);
        greetingsLen = greetings.greetings.Length;

        float randomGreeting = Random.Range(0, greetingsLen);
    
        GetComponentInChildren<TextMeshProUGUI>().text = greetings.greetings[(int)randomGreeting].greeting;
        enterGameButton = GetComponentInChildren<Button>();

        enterGameButton.onClick.AddListener(EnterGame);
        
    }

    private void EnterGame()
    {
        sceneChanger.ChangeScene("GeoSafariGame");
    } 
}
