using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSound : MonoBehaviour
{
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public AudioClip audioClip;//�����Ŭ���� ������ �� �ֵ��� ����->���õ� �����Ŭ���� �Ʒ� �޼����� ������ҽ� ��ü�� �޾� ���尡 ����� ��.
    public AudioClip audioClip2;
    int i = 0;
    private void OnTriggerEnter(Collider other)//Player�� OnTrigger�Ǿ��ִ� ���¿��� AudioSource�� �� ��ũ��Ʈ�� ���� ������Ʈ�� �浹�� �� ���� �߻�
    {
        
        // AudioSource audio = GetComponent<AudioSource>();//������Ʈ�� �ٿ����� ������ҽ��� ����
      //  audio.PlayClipAtPoint();//�Ű����� : �����Ŭ��, ��ġ --> Ư�� ��ġ�� Ư�� �Ҹ��� ������ �� �� ����
        // audio.PlayOneShot(audioClip);
        /*
        ���� �����Ŭ�� �ΰ�, PlayOneShot()�޼��� �ΰ� ���� �� ���� 2���� ���ÿ� �߻�
        audioClip.length : �����Ŭ���� ���̸� ��ȯ
        audio.PlayOneShot(audioClip);
        audio.PlayOneShot(audioClip2);
        float lifetime = Mathf.Max(audioClip.length, audioClip2.length);
        GameObject.Destroy(gameObject, lifetime); ==> �����Ŭ�� 2���� ������ �� �� ���� lifetime���� �޾� Destroy�� �ְ� �����Ű��, �����Ŭ�� �ΰ� ���� �� �� ������ ���� ��� ���� �� ������Ʈ�� ������
         */
        i++;

        if(i%2==0)
           Managers.Sound.Play(audioClip, Define.Sound.Bgm);
        else
           Managers.Sound.Play(audioClip2, Define.Sound.Bgm);
    }
}
