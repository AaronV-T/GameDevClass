using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameMasterScripts : MonoBehaviour {
	[SerializeField]
	//This variable controls the last stage completed by the player. Unlocks the next stage
	int stageProgress;
	[SerializeField]
	//This gameObject is the current ship that the player has selected. Can be used to spawn the players ship in a level
	GameObject currentShip;
	//This variable controls which menu is active
	int currentMenu;
	[SerializeField]
	//An array of menus. Used to select menus and deactivate them
	Canvas[] menus;

	// Use this for initialization
	void Start () {
		/*This object must persist when loading levels as it controls when the player goes back to the menu and
		saves progress */
		//DontDestroyOnLoad (this.gameObject);
		/*Activate the start menu*/
		for (int i = 0; i < menus.Length; i++) {
			if (i > 0) {
				menus [i].enabled = false;
			}
		}
	}
	/// <summary>
	/// Call this when the player finishes the level. Increments the progress tracker.
	/// </summary>
	public void ClearLevel(){
		stageProgress++;
	}
	/// <summary>
	/// Toggles legacy controsl on and off
	/// </summary>
	public void LegacyToggle(bool choice){
        if (choice)
            UserSettings.ControlType = ControlType.Legacy;
        else
            UserSettings.ControlType = ControlType.MouseAim;

        SaveController.SaveSetting(SIMember.CONTROL_TYPE);
    }
	/// <summary>
	/// Call this when navigating menus. It takes an int, which tells it which menu to pick
	/// </summary>
	public void MenuMove(int choice){
		switch (choice) {
		case 0:
			menus [choice].enabled = true;
			menus [currentMenu].enabled = false;
			currentMenu = choice;
			break;
		case 1:
			menus [choice].enabled = true;
			menus [currentMenu].enabled = false;
			currentMenu = choice;
			break;
		case 2:
			menus [choice].enabled = true;
			menus [currentMenu].enabled = false;
			menus [choice].enabled = true;
			currentMenu = choice;
			break;
		case 3:
			menus [choice].enabled = true;
			menus [currentMenu].enabled = false;
			menus [choice].enabled = true;
			currentMenu = choice;
			break;
		}
	}
	/// <summary>
	/// Call this when the player returns to the menu. Failed mission, quit etc.
	/// </summary>
	public void ReturnToMenu(){
		//return to main menu...
		SceneManager.LoadScene ("Title");
	}

	/// <summary>
	/// Takes an integer, the level to load. Call this to load a specific stage
	/// </summary>
	public void LoadLevel(int choice){
        switch (choice)
        {
            case 0:
                SceneManager.LoadScene("TestAaron");
                break;
            case 1:
                SceneManager.LoadScene("Trench");
                break;
            case 2:
                SceneManager.LoadScene("Level1");
                break;
            case 3:
                SceneManager.LoadScene("Escort");
                break;
            case 4:
                SceneManager.LoadScene("Level3");
                break;
        }
	}

	public void ExitGame()
    {
        Application.Quit();
    }
}
