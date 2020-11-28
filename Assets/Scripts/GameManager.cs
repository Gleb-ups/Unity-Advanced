using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public static GameManager GM { get; set; }
	private Dictionary<string, bool> state = new Dictionary<string, bool>();
	[SerializeField]
	Canvas canvas;

	void Awake()
	{
		if (GM != null && GM != this)
		{
			Destroy(GM);
		}
		GM = this;
		DontDestroyOnLoad(gameObject);
		state["gameOver"] = false;
		canvas.enabled = false;
	}

	public bool GetStateByKey(string key)
    {
        bool res;
        state.TryGetValue(key, out res);
		return res;
	}

	public void SetStateByKey(string key, bool value)
	{
		state[key] = value;
	}

    private void Update()
    {
        if (state["gameOver"])
        {
			GameOverHandle();
        }
    }

	private void GameOverHandle()
    {
		Cursor.visible = true;
		canvas.enabled = true;
    }

	public void Restart()
    {
		SceneManager.LoadScene("MainScene");
    }
}
