using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
     Define.CameraMode _mode = Define.CameraMode.QuarterView;//Define���� ������ ī�޶��� �� ���ͺ並 �⺻���� ����
    [SerializeField]
    Vector3 _delta = new Vector3(0.0f, 6.0f, -5.0f);//Player �������� �󸶳� �������ִ����� ���� ���⺤��
    [SerializeField]
    GameObject _player = null;//ī�޶� ����� �÷��̾�

    
    void Start()
    {
        
    }

    
    void LateUpdate()//ī�޶� ��Ʈ�� ������ Update���� ������, PlayerController�� Update�� ���� �ִ� ��ư�̺�Ʈ�� ���� ������ ����-->�÷��̾� �̵� �� ���� �߻�
        //LateUpdate()�� ������ Update()���� ���� �Ŀ� ����ǹǷ� ���� ������ ������ �� �ִ�.
    {
        if (_mode == Define.CameraMode.QuarterView)
        {
            transform.position = _player.transform.position + _delta;//ī�޶� ������ = �÷��̾� ������ + ���⺤��-->ī�޶� �÷��̾ ���� �̵�
            transform.LookAt(_player.transform);//LookAt()�Լ� : ī�޶� ������ �÷��̾��� ��ǥ�� �ֽ��ϵ��� ��
        }

        
    }

    public void SetQuarterView(Vector3 delta)//QuarterView�� �ڵ������ �����ϰ��� �� �� ���
    {
        _mode = Define.CameraMode.QuarterView;
        _delta = delta;
    }
}
