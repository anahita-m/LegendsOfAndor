﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//This script enables redirection from Sign in Button to Login page in Legends of Andor

public class Play_Game : MonoBehaviour
{
	private const string SceneName = "Play_Game";

	public void Waiting()
	{
		SceneManager.LoadScene(SceneName);

	}

}