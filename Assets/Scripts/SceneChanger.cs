using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
	public DataPersistenceManager dataPersistenceManager;

	public void ChangeScene(string sceneName)
	{
		dataPersistenceManager.SaveGame();
		SceneManager.LoadScene(sceneName);
	}
	public void Exit()
	{
		Application.Quit();
	}
}
