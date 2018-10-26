using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleButton : MonoBehaviour
{
    public List<Sprite> _Sprites;
    public Image _Image;
    public Button _Button;
    public int MenuId;
    public bool Open;
    public float DisabledAlpha = .2f;
    public float EnabledAlpha = 1f;
    // Use this for initialization
    void Start()
    {
        _Image = GetComponent<Image>();
        _Button = GetComponent<Button>();
        Open = false;
    }
    public void CloseMenu()
    {
        print("Close!");
        _Image.sprite = _Sprites[0];

        Color c = _Image.color;
        c.a = DisabledAlpha;
        _Image.color = c;
        Open = false;
    }
    public void OpenMenu()
    {
        print("Open!");

        _Image.sprite = _Sprites[1];
        Color c = _Image.color;
        c.a = EnabledAlpha;
        _Image.color = c;
        Open = true;

    }

    // Update is called once per frame
    void Update()
    {

    }
}
