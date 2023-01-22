using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChangeName : MonoBehaviour
{
    [Header("Referencias")]
    public TextMeshProUGUI uiTextName;
    public TMP_InputField uiInputField;
    public GameObject changeNameInput;
    public Player player;

    private string playerName;

    private void Awake()
    {
        player.SetName("unnamed");
    }

    public void TrocaNome()
    {
        playerName = uiInputField.text;
        uiTextName.text = playerName;
        changeNameInput.SetActive(false);
        player.SetName(playerName);
    }
}
