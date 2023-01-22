using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    public int maxPoints = 2;
    public float speed = 10f;
    public Image uiPlayer;
    public string playerName;

    [Header("KEY SETUP")]
    public KeyCode keycodeMoveUp = KeyCode.UpArrow;
    public KeyCode keycodeMoveDown = KeyCode.DownArrow;

    public Rigidbody2D _rb;

    [Header("Points")]
    public int currentPoints;
    public TextMeshProUGUI uiTextPoints;

    private void Awake()
    {
        ResetPlayer();
    }

    public void SetName(string s)
    {
        playerName = s;
    }

    public void ResetPlayer()
    {
        currentPoints = 0;
        UpdateUI();
    }

    public void ChangeColor(Color c)
    {
        uiPlayer.color = c;
    }


    private void Update()
    {
        if (Input.GetKey(keycodeMoveUp))
        {
            _rb.MovePosition(transform.position + transform.up * speed);
            //transform.Translate(transform.up * speed);
        } else if (Input.GetKey(keycodeMoveDown))
        {
            _rb.MovePosition(transform.position + transform.up * -speed);
            //transform.Translate(transform.up * speed * -1);
        }
        
    }
    public void AddPoint()
    {
        currentPoints++;
        UpdateUI();
        CheckMaxPoints();
        Debug.Log(currentPoints);
    }

    private void UpdateUI()
    {
        uiTextPoints.text = currentPoints.ToString();
    }

    private void CheckMaxPoints()
    {
        if(currentPoints >= maxPoints)
        {
            GameManager.Instance.EndGame();
            HighscoreManager.Instance.SavePlayerWin(this);
        }
        else
        {
            StateMachine.Instance.ResetPosition();
        }
    }
}
