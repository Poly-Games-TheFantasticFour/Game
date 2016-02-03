using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour {
	
		public GameObject loadingImage;
		
		public void LoadScene(int level)
		{
			loadingImage.SetActive(true);
            SceneManager.LoadScene(level);
        }
	}