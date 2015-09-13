using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public static int highScore;
	public static int currentScore;

	public static int currentLevel = 0;
	public static int unlockedLevel;

	// Use this for initialization
	public static void completeLevel () {
		Application.LoadLevel(++currentLevel);
	}
}
