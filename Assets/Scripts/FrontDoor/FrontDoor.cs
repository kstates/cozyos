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
    public GameObject welcomePanel;
    public TMP_Text welcomeText;
    public TMP_Text errorText;
    public GameObject userSelectionPanel;
    public TMP_InputField userTextField;
    public TMP_Dropdown userDropdown;
    public GameObject userDropdownButton;
    private string userName;

    public void Start()
    {
       this.setUpScene(); 

        userDropdown.onValueChanged.AddListener(delegate {
            userDropdownValueChanged();
        });
    }

    // Select or create a new user
    public void SelectUser(string inputType)
    {
        switch (inputType) 
        {
            case "textInput": 
                this.CreateUserProfile(userTextField.text);
                break;
            case "dropdown":
                this.SelectUserProfile(userDropdown.options[userDropdown.value].text);
                break;
            default:
                Debug.Log("Invalid input type");
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

    // Stub that needs to be implemented for IDataPersistence
    public void NewGame(){}

    // Create a new user profile if a new username is entered
    private void CreateUserProfile(string newUserName)
    {
        if (newUserName == "") {
            this.errorText.text = "User name cannot be empty";
            return; 
        } 

        if (!unUniqCheck(newUserName))
        {
            this.errorText.text = "User name must be unique";
            return;
        }

        this.userName = newUserName; 
        DataPersistenceManager.instance.CreateNewProfile(System.Guid.NewGuid().ToString());
        this.setUpScene();
    }

    // Returns true if a username is unique
    private bool unUniqCheck(string newUserName) 
    {
        Dictionary<string, GameData> profilesGameData = DataPersistenceManager.instance.GetAllProfilesGameData();
       
        foreach (KeyValuePair<string, GameData> pair in profilesGameData) 
        { 
            GameData gameData = pair.Value; 
            if (gameData.getUserName() == newUserName) {
                return false;
            } 
        } 

        return true;
    }

    // Switch to an existing user profile if one is chosen from the dropdown
    private void SelectUserProfile(string userName)
    {
        Dictionary<string, GameData> profilesGameData = DataPersistenceManager.instance.GetAllProfilesGameData();
       
        foreach (KeyValuePair<string, GameData> pair in profilesGameData) 
        { 
            GameData gameData = pair.Value; 
            if (gameData.getUserName() == userName) {
                DataPersistenceManager.instance.ChangeSelectedProfileId(pair.Key);
                this.userName = userName; 
                break;
            } 
        } 
    }

    // Set up the scene based on the current profile and data
    private void setUpScene()
    {
        if (this.userName == null || this.userName.Length <= 0)
        {
            this.welcomePanel.SetActive(false);
            createUsersDropdown();
        } 
        else 
        {
            this.welcomeText.text = "Welcome, " + this.userName;
            this.welcomePanel.SetActive(true);
            this.userSelectionPanel.SetActive(false);
        }

    }

    // Create a dropdown with the profile and username that exist in our game data directory
    private void createUsersDropdown() 
    {
        Dictionary<string, GameData> profilesGameData = DataPersistenceManager.instance.GetAllProfilesGameData();
        userDropdownButton.SetActive(false); // We only set this to true once a user makes a selection

        if (profilesGameData.Count <= 0)
        {
            userDropdown.gameObject.SetActive(false);
        }
        else 
        {
            userDropdown.ClearOptions();
            userDropdown.captionText.text = "Choose a user"; 
    
            foreach (KeyValuePair<string, GameData> pair in profilesGameData) 
            { 
                GameData gameData = pair.Value; 
                userDropdown.options.Add(new TMP_Dropdown.OptionData(gameData.getUserName()));
            }
        }

    }

    // If a user is selected, reveal the user selection button. We don't need to check for values, any
    // change will make this different
    private void userDropdownValueChanged()
    {
        userDropdownButton.SetActive(true); 
    }

}
