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
        //RayCasting

        //Vector3.forward�� ���� z���� �ѹ������θ� Ray�� �߻�ǹǷ�, Player�� �ٶ󺸴� �������� Ray�� ��� ���� ������ǥ�� ������ǥ�� ��ȯ�غ���
        //transform.TransformDirection�� ����Ͽ� ���� ������ Player �ü����� ���ش�
        Vector3 look = transform.TransformDirection(Vector3.forward);
        Debug.DrawRay(transform.position + Vector3.up, look * 10, Color.red);


        //Debug.DrawRay(transform.position + Vector3.up, transform.forward*10, Color.red);
        //DrawRay ���� : ������ġ Start, Rayũ�� Start+direction, Ray�� �÷�-->Start+dir �̱⶧���� ����� ũ�� ��� ���(forward�������� ũ�� = 1)
        //�׳� transform.position�� ������ Player�� ���� �Ʒ�(�߿� �ش�)���� Ray�� ���۵ǹǷ� up (0,1,0)���� ������ġ�� �÷��ش�


       RaycastHit hit;//Ray�� ���� ��ü�� ������ ����-->outŸ������ ����� ��.

                       //if( Physics.Raycast(transform.position, Vector3.forward, out hit, 10 ))
                       //Vector3.origin : ������ǥ-->Player�� ��ġ / Vector3.direction : ���� ���ϴ� ����-->forward�ܹ��� / Maxdistance : �ִ� �� �� �ִ� �Ÿ�
                       //bool���� ������-->Ray�� ���� �� ��ü�� ������� true

       if (Physics.Raycast(transform.position + Vector3.up, look, out hit, 10))
       {
            Debug.Log($"RayCast{hit.collider.gameObject.name}!");
            //Ray�� �浹�� ��ü�� hit��� �ϰ�, �̰��� �ö��̴��� ����� ���ӿ�����Ʈ�� �̸��� ǥ���ϵ���
        }
     
        //�� ���� ���� �� ��ü�� �����ϴ� Ray�� ���� �� :

        //RaycastHit[] hits; //����ĳ��Ʈ �迭 ���
       // hits = Physics.RaycastAll(transform.position + Vector3.up, look, 10);
       // foreach(RaycastHit hit in hits)
       // {
       //     Debug.Log($"RayCast{hit.collider.gameObject.name}!");
        //}
    //RayCast ���� : Player�� ī�޶� ���̰� ������ �������� ��-->Ray�� ��� ���� ������ ī�޶� ��ġ�� ������ Player���� ������ �� �� ���� 
    }
}
