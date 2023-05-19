using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro; 

public class GeoSafariGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        createQuestionDropdown();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private static FileInfo[] getAllQuestions() 
    {
        string questionsPath = Application.dataPath + "/JSON/GeoSafari/Questions";
        DirectoryInfo dir = new DirectoryInfo(questionsPath);
        FileInfo[] questions = dir.GetFiles("*.json");

        return questions; 
    }

    private void createQuestionDropdown() 
    {
        FileInfo[] questions = getAllQuestions(); 
        foreach (var questionSetPath in questions)
        {
            string jsonTextFile = File.ReadAllText(questionSetPath.FullName);
            Questions questionJSON = JsonUtility.FromJson<Questions>(jsonTextFile); 
        }
    }
}
