using UnityEngine;
using System.Collections.Generic;

public class LoginManager : MonoBehaviour
{
	public static LoginManager instance { get; private set; }

	private void Awake()
	{
		instance = this;
	}

	private void Start()
	{
	
	}
	
	private void Update()
	{
	
	}
}
