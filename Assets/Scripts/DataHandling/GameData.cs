using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * 
 *
 */
[System.Serializable]
public class GameData
{
    public long lastUpdated;
    [SerializeField] private string userName;

    public GameData() 
    {
        this.userName = "";
    }

    public string getUserName()
    {
       return this.userName; 
    }

    public void setUserName(string name) 
    {
       this.userName = name; 
    }

}
