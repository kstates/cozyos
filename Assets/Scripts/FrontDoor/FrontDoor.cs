using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/**
 * Main functionality class for Front Door scene
 *
 */
public class FrontDoor : MonoBehaviour, IDataPersistence
{
    public GameObject enterButton;
    public TMP_InputField userTextField;
    public DataPersistenceManager dataPersistenceManager;
    private string userName;

    // Select or create a new user
    public void SelectUser(string inputType)
    {
        switch (inputType) 
        {
            case "textInput": 
                this.CreateUserProfile(userTextField.text);
                break;
            case "dropdown":
                Debug.Log("Dropdown");
                break;
            default:
                Debug.Log("No input Type");
                return;
        }
    } 

    // Load data - uses IDataPersistence
    public void LoadData(GameData data) 
    {
        this.userName = data.getUserName();

        // Once we have our data, set up our scene
        this.setUpScene();
    }

    // Save data - uses IDataPersistence
    public void SaveData(GameData data) 
    {
        data.setUserName(this.userName);
    }

    // Create a new user profile if a new username is entered
    private void CreateUserProfile(string newUserName)
    {
       dataPersistenceManager.ChangeSelectedProfileId(System.Guid.NewGuid().ToString());
       this.userName = newUserName; 
    }

    // Switch to an existing user profile if one is chosen from the dropdown
    private void SelectUserProfile(string userProfileId)
    {
        // Todo - add functionality once dropdown exists
        return;
    }

    // Set up the scene based on the current profile and data
    private void setUpScene()
    {
         if (this.userName.Length <= 0)
        {
            this.enterButton.SetActive(false);
        }

    }

    // Create a dropdown with the profile and username that exist in our game data directory
    private void createUsersDropdown() 
    {
       Dictionary<string, GameData> profilesGameData = dataPersistenceManager.GetAllProfilesGameData();
       
       foreach (KeyValuePair<string, GameData> pair in profilesGameData) 
       { 
            Debug.Log(pair);
       }

    }

}
