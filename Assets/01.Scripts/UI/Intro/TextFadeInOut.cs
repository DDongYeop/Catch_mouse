using System;
using TMPro;
using UnityEngine;

public class TextFadeInOut : MonoBehaviour
{
    private TextMeshProUGUI _text;
    private float _time = 0;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        _time = Mathf.Sin(Time.time * 5f);
        _time = (_time + 1) / 2;

        _text.color = new Color(1, 1, 1, _time);
    }
}
