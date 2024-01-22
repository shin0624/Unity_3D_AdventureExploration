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
            //ī�޶� �þ߸� ������Ʈ�� �����־� Player�� ������ ���� �� ī�޶� ������Ʈ�� ����ϵ��� ���� 
            RaycastHit hit;
            if(Physics.Raycast(_player.transform.position, _delta, out hit, _delta.magnitude, LayerMask.GetMask("Wall")))
            {//���� ī�޶� �þ߸� ������Ʈ�� �����ִٸ�, �켱 Player�� ������Ʈ �� �Ÿ��� ���Ѵ�
                float dist = (hit.point - _player.transform.position).magnitude * 0.8f;//Ray�� �浹�� ��ǥ�� hit.point���� Player�� ��ġ�� ���� ���⺤�Ͱ� ���� ���̰�, magnitude�� �ϸ� ���⺤���� ũ�Ⱑ ���� ��. �� ������ ���� �� ������ ��ܼ� Player�� ���� ���̹Ƿ� ���� ������� �����ش�. 
              //���� �ٲ� ī�޶� ��ġ = Player��ġ�� �������� _delta�� normalized�� ���� * dist
                transform.position = _player.transform.position + _delta.normalized * dist;
            }
            else
            {
                transform.position = _player.transform.position + _delta;//ī�޶� ������ = �÷��̾� ������ + ���⺤��-->ī�޶� �÷��̾ ���� �̵�
                transform.LookAt(_player.transform);//LookAt()�Լ� : ī�޶� ������ �÷��̾��� ��ǥ�� �ֽ��ϵ��� ��
            }



            
        }

        
    }

    public void SetQuarterView(Vector3 delta)//QuarterView�� �ڵ������ �����ϰ��� �� �� ���
    {
        _mode = Define.CameraMode.QuarterView;
        _delta = delta;
    }
}
