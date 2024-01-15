using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCollision : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"collision! @{collision.gameObject.name}");//�ε��� ������Ʈ�� �̸��� ���
        //ȣ�� ����
        //1. �� Ȥ�� ��뿡�� RigidBody�� �־�� ��(isKinematic : off)
        //2. ������ Collider�� �־�� ��(isTrigger : off)
        //3. ��뿡�� Collider�� �־�� ��(isTrigger : off) 

    }

    private void OnTriggerEnter(Collider other)
        //�浹 ���� ���� ��ü�� �������� �Ǵ��ϴ� ��(������ �������)�� Ʈ����
    {
        Debug.Log($"trigger! @{other.gameObject.name}");
        //ȣ�� ����
        //1. ���� ��뿡�� ��� Collider�� �־�� ��
        //2. �� �� �ϳ��� isTrigger : on
        //3. �� �� �ϳ��� RigidBody�� �־�� ��
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
