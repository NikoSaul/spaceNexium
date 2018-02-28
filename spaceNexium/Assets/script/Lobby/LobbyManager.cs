using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class LobbyManager : MonoBehaviour
{
	public static LobbyManager instance { get; private set; }

	private void Awake()
	{
		instance = this;
        if(!Statics.isInit)
            SceneManager.LoadScene("Global", LoadSceneMode.Additive);
	}

	private void Start()
	{
	
	}
	
	private void Update()
	{
	
	}
}
