using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] GameObject titleUI;
    [SerializeField] GameObject endgameUI;
    [SerializeField] GameObject GameOverUI;
    [SerializeField] TMP_Text livesUI;
    [SerializeField] TMP_Text timerUI;
    [SerializeField] Slider healthUI;

    [SerializeField] GameObject respawn;

    [SerializeField] FloatVariable health;
    [SerializeField] IntVariables score;
    [Header("Events")]
    //[SerializeField] IntEvent scoreEvent;
    [SerializeField] VoidEvent gameStartEvent;
    [SerializeField] VoidEvent TimeEndEvent;
    [SerializeField] GameObjectEvent speedBoostEvent;
    [SerializeField] GameObjectEvent respawnEvent;

	public enum State
    {
        TITLE,
        START_GAME,
        PLAY_GAME,
        GAME_OVER,
		END_GAME
	}

    public State state = State.TITLE;
    public float timer = 0;
    public int lives = 0;


    public int Lives
    {
        get { return lives; }
        set
        {
            lives = value;
            livesUI.text = "Lives: " + lives.ToString();
        }
    }

    public float Timer
    {
        get { return timer; }
        set
        {
            timer = value;
            timerUI.text = string.Format("{0:F1}", timer);
        }
    }

    void OnEnable()
    {
        //	scoreEvent.Subscribe(OnAddPoints);
    }

    void OnDisable()
    {
        //	scoreEvent.Unsubscribe(OnAddPoints);
    }

    void Start()
    {
        GameOverUI.SetActive(false);
        endgameUI.SetActive(false);
	}

    void Update()
    {
        switch (state)
        {
            case State.TITLE:
                titleUI.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                break;
            case State.START_GAME:
                titleUI.SetActive(false);
                GameOverUI.SetActive(false);
				endgameUI.SetActive(false);
				Timer = 120;
                Lives = 3;
                health.value = 100;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                gameStartEvent.RaiseEvent();
                respawnEvent.RaiseEvent(respawn);
                state = State.PLAY_GAME;
                break;
            case State.PLAY_GAME:
                Timer = Timer - Time.deltaTime;
                if (Timer <= 0 || health.value <= 0)
                {
					state = State.GAME_OVER;
				}
                break;
            case State.GAME_OVER:
				GameOverUI.SetActive(true);
				Cursor.lockState = CursorLockMode.None;
				Cursor.visible = true;
				break;
            case State.END_GAME:
				endgameUI.SetActive(true);
				Cursor.lockState = CursorLockMode.None;
				Cursor.visible = true;
				break;
		}

        healthUI.value = health.value / 100.0f;
    }
	public void AddTime(float value)
	{
		timer += 5;
	}

	public void onEndGame()
    {
		state = State.END_GAME;
	}
    public void OnStartGame()
    {
        state = State.START_GAME;
    }
    public void onPlayerDead()
    {
        state = State.GAME_OVER;
    }
    public void onTimerEnd()
    {
        state = State.GAME_OVER;
	}

    public void OnAddPoints(int points)
    {
        print(points);
    }
}