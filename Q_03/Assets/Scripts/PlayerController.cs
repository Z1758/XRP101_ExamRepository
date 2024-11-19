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
        // 사망 하면서 오브젝트가 비활성화 되면서 동시에 AudioSource도 비활성화 되기 때문에 소리가 재생 되지 않음 
        // 오디오를 관리할 객체를 따로 설정하는것이 좋음
        //_audio.Play();
     
        AudioSource.PlayClipAtPoint(_audio.clip,transform.position);
        gameObject.SetActive(false);
    }
}
