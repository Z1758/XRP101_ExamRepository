using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupController : MonoBehaviour
{
    [SerializeField] private float _deactiveTime;
    private WaitForSecondsRealtime _wait;
    private Button _popupButton;

    [SerializeField] private GameObject _popup;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        _wait = new WaitForSecondsRealtime(_deactiveTime);
        _popupButton = GetComponent<Button>();
        SubscribeEvent();
    }

    private void SubscribeEvent()
    {
        _popupButton.onClick.AddListener(Activate);
    }

    private void Activate()
    {
      
        _popup.gameObject.SetActive(true);
        GameManager.Intance.Pause();
        // 타임 스케일이 0이 되어 코루틴이 작동하지 않음
        // 타임 스케일이 0일때도 코루틴이 작동하려면 WaitForSecondsRealtime을 사용해야 함
        StartCoroutine(DeactivateRoutine());
    }

    private void Deactivate()
    {
        _popup.gameObject.SetActive(false);
        Time.timeScale = 1.0f;
    }

    private IEnumerator DeactivateRoutine()
    {
        yield return _wait;
        Deactivate();
    }
}
