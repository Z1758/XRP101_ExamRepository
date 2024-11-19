using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [field: SerializeField]
    [field: Range(0, 100)]
    public int Hp { get; private set; }

    private AudioSource _audio;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        _audio = GetComponent<AudioSource>();
    }
    
    public void TakeHit(int damage)
    {
        Hp -= damage;

        if (Hp <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        // ��� �ϸ鼭 ������Ʈ�� ��Ȱ��ȭ �Ǹ鼭 ���ÿ� AudioSource�� ��Ȱ��ȭ �Ǳ� ������ �Ҹ��� ��� ���� ���� 
        // ������� ������ ��ü�� ���� �����ϴ°��� ����
        //_audio.Play();
     
        AudioSource.PlayClipAtPoint(_audio.clip,transform.position);
        gameObject.SetActive(false);
    }
}
