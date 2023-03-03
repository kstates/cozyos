using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GeoSafari : MonoBehaviour
{
    public TextAsset randomGreetingsFile; 
    private Greetings greetings;
    private int greetingsLen;

    // Start is called before the first frame update
    void Start()
    {
        greetings = JsonUtility.FromJson<Greetings>(randomGreetingsFile.text);
        greetingsLen = greetings.greetings.Length;

        float randomGreeting = Random.Range(0, greetingsLen);
    
        GetComponentInChildren<TextMeshProUGUI>().text = greetings.greetings[(int)randomGreeting].greeting;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
