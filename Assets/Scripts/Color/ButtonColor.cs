using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]

public class ButtonColor : MonoBehaviour
{
public Color color;

[Header("Referencias")]
public Image uiImage;

    public Player mPlayer;

    private void OnValidate()
    {
        uiImage = GetComponent<Image>();
    }

    private void Start()
    {
        uiImage.color = color;

        //GetComponent<Button>().onClick.AddListener(onClick);
    }

    public void onClick()
    {
        mPlayer.ChangeColor(color);
    }
}
