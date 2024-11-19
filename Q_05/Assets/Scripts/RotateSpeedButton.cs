using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotateSpeedButton : MonoBehaviour
{
    [SerializeField] private Button _plusButton;
    [SerializeField] private Button _minusButton;
    [SerializeField] private Button _stopButton;
    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        SubscribeEvent();
    }

    private void SubscribeEvent()
    {
        _plusButton.onClick.AddListener(PlusScore);
        _minusButton.onClick.AddListener(MinusScore);
        _stopButton.onClick.AddListener(StopScore);
    }

    private void PlusScore() => GameManager.Intance.Score += 0.05f;
    private void MinusScore() => GameManager.Intance.Score -= 0.05f;

    private void StopScore() => GameManager.Intance.Score = 0;
}
