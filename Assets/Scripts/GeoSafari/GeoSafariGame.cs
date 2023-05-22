using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class GeoSafariGame : MonoBehaviour
{
    public TMP_Dropdown questionDropdown;
    private string questionsFolderPath;
    private QuestionsHandler questionsHandler;

    /**
     * Set up the game scene by creating the dropdown of which question set to use in the game. 
     */
    void Start()
    {
        questionsHandler = gameObject.AddComponent<QuestionsHandler>();
        questionsFolderPath = Application.dataPath + "/JSON/GeoSafari/Questions"; 

        questionsHandler.createQuestionDropdown(questionDropdown, questionsFolderPath);
    }
}
