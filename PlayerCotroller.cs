using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCotroller : MonoBehaviour
{
    [SerializeField]
    float _speed = 10.0f;//���������ڸ� public���� �ϰų� SerializeField�� ����ϸ� �ν����Ϳ��� �ӵ����� ���� ����
                         // float _yAngle = 0.0f;//�����̼� ������ ���� ���� ����

    bool _moveToDest = false;//_desPos ��� ����(�������� �̵��ϴ���)
    Vector3 _destPos;//������


    void Start()
    {
        Managers.Input.KeyAction -= OnKeyboard;//�ߺ� ȣ���� �����ϱ� ���� ���̳ʽ�
        Managers.Input.KeyAction += OnKeyboard;

        Managers.Input.MouseAction -= OnMouseClicked;
        Managers.Input.MouseAction += OnMouseClicked;
    }

    // ������Ʈ �޼���� ������ �� �ѹ���, �� 1/60�ʸ��� �ѹ��� ����ǹǷ�
    //���� ��뿡 ���߱� ���� ���� �����Ӱ� ���� �������� �ð� ����(Time.deltaTime)�� �̿��Ѵ�
    //�ð� * �ӵ� = �Ÿ� �� �̿�
    void Update()
    {

#if WASD_Move_1
        //�����¿� �̵� : new Vector3(0.0f, 0.0f, 1.0f) ��� �Ǵ� ����� ���(������ǥ��)  
        // ���� ��ǥ��(Player�� �ü��� �������� �� �����¿� : transform.TransformDirection(����->����)
        //(����->����) : InverseTransformDirection
        //ex)  transform.position += transform.TransformDirection(Vector3.forward * Time.deltaTime * _speed)(�̵��Ÿ� * ���� �ð��� ����� ��ġ delaTime * �ӵ�)


        //if (Input.GetKey(KeyCode.W))//��
        //     transform.Translate(Vector3.forward * Time.deltaTime * _speed);  //transform.Translate �� ���� �÷��̾� �ü� ���� ��ǥ�̵��� �ٷ� �����ϰ� ����

        // if (Input.GetKey(KeyCode.S))//��
        //    transform.Translate(Vector3.back * Time.deltaTime * _speed);

        //  if (Input.GetKey(KeyCode.A))//��
        //     transform.Translate(Vector3.left * Time.deltaTime * _speed);

        //if (Input.GetKey(KeyCode.D))//��
        //     transform.Translate(Vector3.right * Time.deltaTime * _speed);

        //2. rotation ����  
        //1)���� ȸ���� ����(transform.eulerAngles ���)
        // transform.eulerAngles = new Vector3(0.0f, _yAngle, 0.0f);//���Ϸ� �� ���

        //2) +-delta (transform.Rotate ���)
        //transform.Rotate(new Vector3(0.0f, Time.deltaTime * 100.0f, 0.0f));

        //3)  Quaternion ���--> Vector3 �̿� �� �߻��� �� �ִ� ������ ����
        //ex) transform.rotation = Quaternion.Euler(new Vector3(0.0f, Time.deltaTime * 100.0f, 0.0f));
        //Quaternion.Euler : Vector3��(���Ϸ� ��)�� ������ ���ʹϾ� ������ ��ȯ����

        //-->���ϴ� Ư�� �������� ���ƺ��� �� �� : Quaternion.LookRotation ���
        //-->���ϴ� �������� �ε巴�� ���ƺ��� �� ��, �� �տ��� ������ �� �� x��� y���� �߰��� ���� ���ƺ���
        //-->Quaternion.Slerp ���(�Ű����� : ���ʹϾ� a, b, float c), c���� 0.0f ~ 1.0f ���� ���� �ִµ�, 0.0�� ȸ�� �Ұ�, 1.0�� �ʹ� ���� ȸ���̹Ƿ� �߰� ���� ������ ã�Ƽ� �ִ´�

        //�����¿� GetKey if���� ����

#endif

        if (_moveToDest)
        {
            Vector3 dir = _destPos - transform.position;//Click�� ������ ��ǥ - Player��ǥ = �̵��� ���⺤��(����+�Ÿ�)
            if(dir.magnitude < 0.0001f)
            {
                _moveToDest = false;//Player�� destPos�� �����ϸ� �ٽ� moveToDest�� false�� �ٲ۴�.
            }
            else
            {
                float moveDist = Mathf.Clamp(_speed * Time.deltaTime, 0, dir.magnitude); //-->�����ϴ� �Ÿ���, ���� Player�� destPos �� �Ÿ����� ��������� �����ϴ� Clamp(value, min, max)-->value�� ������ ���� min,max�� �ڵ�����
                //transform.position+= dir.normalized* _speed * Time.deltaTime;//(�Ÿ� = �ӵ�*�ð�)
                transform.position+= dir.normalized* moveDist;


                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 10 * Time.deltaTime);//���� Playerȸ���� �����ٸ� ������� 20������ �ø�

                //transform.LookAt(_destPos);//�̵��� �� destPos �������� �ü� ����
            }
        
        
        }

    }

    void OnKeyboard()
    {
        if (Input.GetKey(KeyCode.W))//��     
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward), 0.1f);
            // transform.rotation = Quaternion.LookRotation(Vector3.forward);
            transform.position += Vector3.forward * Time.deltaTime * _speed;
        }
        if (Input.GetKey(KeyCode.S))//��
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.back), 0.1f);
            transform.position += Vector3.back * Time.deltaTime * _speed;
        }
        if (Input.GetKey(KeyCode.A))//�� 
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.left), 0.1f);
            transform.position += Vector3.left * Time.deltaTime * _speed;
        }
        if (Input.GetKey(KeyCode.D))//��    
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.right), 0.1f);
            transform.position += Vector3.right * Time.deltaTime * _speed;
        }

        _moveToDest = false;//Ű����� ������ ���� ���콺 Ŭ������ �̵�ó�� destPos�� ���ϰ� �������� �����Ƿ� false.

    }

    void OnMouseClicked(Define.MouseEvent evt)//InputManager ��ũ��Ʈ���� Action<Define.MouseEvent> MouseAction ���� �����Ͽ����Ƿ�, ���콺�̺�Ʈ ��ü�� ���ڷ� �Ѱ���
    {
        if (evt != Define.MouseEvent.Click)//���� �̺�Ʈ�� Click�� �ƴϸ� ����
            return;

        //--TestCollision���� �̵��� Raycasting �κ� --->LOLó��, ���콺�� �ٴ��� Ŭ���ϸ� Ŭ���� ���� destPos�� �Ͽ� �װ����� Player�� �����̰� �� ����.

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        Debug.DrawRay(Camera.main.transform.position, ray.direction * 100.0f, Color.red, 1.0f);
        RaycastHit hit;
      
        if (Physics.Raycast(ray, out hit, 100.0f, LayerMask.GetMask("Wall")))//���ڿ� LayerMask�� �ٷ� �߰�
        {
           
            _destPos = hit.point;//hit.point = Ray�� Hit�� �ö��̴��� ������ǥ. �̸� �������� �Ͽ� Player�� �̵���ų ��
            _moveToDest = true;
            //-->Update()���� �������� �̵���Ű�� �ȴ�.
        }


    }
}
