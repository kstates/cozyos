using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;

public class QuestionsHandler : MonoBehaviour 
{
    /**
     * Go through the questions json files, grab their name data, and add that to the questions dropdown.
     */ 
    public void createQuestionDropdown(TMP_Dropdown questionDropdown, string questionsFolderPath) 
    {
        questionDropdown.ClearOptions();
        questionDropdown.captionText.text = "Choose a game";
        
        FileInfo[] questions = getAllQuestions(questionsFolderPath); 
        foreach (var questionSetPath in questions)
        {
            string jsonTextFile = File.ReadAllText(questionSetPath.FullName);
            Questions questionJSON = JsonUtility.FromJson<Questions>(jsonTextFile); 

            questionDropdown.options.Add(new TMP_Dropdown.OptionData(questionJSON.questionSetTitle));
        }

    }

   /**
     * Go through the geosafari JSON questions directory and get all the question set files
     */ 
    private static FileInfo[] getAllQuestions(string questionsFolderPath) 
    {
        DirectoryInfo dir = new DirectoryInfo(questionsFolderPath);
        FileInfo[] questions = dir.GetFiles("*.json");

        return questions; 
    } 

}
