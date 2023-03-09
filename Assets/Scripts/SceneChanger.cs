using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{

	public void ChangeScene(string sceneName)
	{
		DataPersistenceManager.instance.SaveGame();
		SceneManager.LoadScene(sceneName);
	}
	public void Exit()
	{
		Application.Quit();
	}
}
