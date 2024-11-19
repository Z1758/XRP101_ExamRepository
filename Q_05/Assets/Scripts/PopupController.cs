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
        // Ÿ�� �������� 0�� �Ǿ� �ڷ�ƾ�� �۵����� ����
        // Ÿ�� �������� 0�϶��� �ڷ�ƾ�� �۵��Ϸ��� WaitForSecondsRealtime�� ����ؾ� ��
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
