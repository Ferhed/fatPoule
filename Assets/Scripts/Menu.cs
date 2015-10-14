using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

	public Text soundText ;
	public Text vibrateText ;
	int currentSound  = 0;
	int currentVibrate = 0;
	public Image fullProgressBar;
	public Text percentProgressBar;

	private AsyncOperation aSync = null;

	// Use this for initialization
	void Start () {
		Screen.orientation = ScreenOrientation.LandscapeLeft;

		currentSound = PlayerPrefs.GetInt ("sound");
		if (currentSound == 0) 
		{
			soundText.text = "Son : Activé";
		}
		else if (currentSound == 1)
		{
			soundText.text = "Son : Désactivé";
		}
		currentVibrate = PlayerPrefs.GetInt ("vibrate");
		if (currentVibrate == 0) 
		{
			vibrateText.text = "Vibration : Activé";
		}
		else if (currentVibrate == 1)
		{
			vibrateText.text = "Vibration : Désactivé";
		}
	}

	public void goToPlay()
	{
		//Application.LoadLevel(1);

		StartCoroutine("LoadLevel");
	}

	private IEnumerator LoadLevel()
	{
		aSync = Application.LoadLevelAsync("JEu");
		yield return aSync;
	}

	private void OnGUI()
	{
		if(aSync != null)
		{
			percentProgressBar.text = aSync.progress*100 + "%";
			fullProgressBar.rectTransform.anchoredPosition = new Vector2(aSync.progress * 290, 20 );

			Debug.Log(percentProgressBar.text);
			

		}
	}



	public void switchSound()
	{
		if (soundText.text == "Son : Activé") 
		{
			soundText.text = "Son : Désactivé";
			currentSound = 1;
			PlayerPrefs.SetInt("sound", currentSound);
		}
		else if (soundText.text == "Son : Désactivé")
		{
			soundText.text = "Son : Activé";
			currentSound = 0;
			PlayerPrefs.SetInt("sound", currentSound);
		}

	}

	public void switchVibrate()
	{
		if (vibrateText.text == "Vibration : Activé") 
		{
			vibrateText.text = "Vibration : Désactivé";
			currentVibrate = 1;
			PlayerPrefs.SetInt("vibration", currentVibrate);
		}
		else if (vibrateText.text == "Vibration : Désactivé")
		{
			vibrateText.text = "Vibration : Activé";
			currentVibrate = 0;
			PlayerPrefs.SetInt("vibration", currentVibrate);
		}
		
	}

	// Update is called once per frame
	void Update () {
	
	}
}
