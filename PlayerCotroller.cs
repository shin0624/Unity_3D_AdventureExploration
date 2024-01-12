using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCotroller : MonoBehaviour
{
    [SerializeField]
    float _speed = 10.0f;//���������ڸ� public���� �ϰų� SerializeField�� ����ϸ� �ν����Ϳ��� �ӵ����� ���� ����
   // float _yAngle = 0.0f;//�����̼� ������ ���� ���� ����
    
    void Start()
    {
        Managers.Input.KeyAction -= OnKeyboard;//�ߺ� ȣ���� �����ϱ� ���� ���̳ʽ�
        Managers.Input.KeyAction += OnKeyboard;
    }

    // ������Ʈ �޼���� ������ �� �ѹ���, �� 1/60�ʸ��� �ѹ��� ����ǹǷ�
    //���� ��뿡 ���߱� ���� ���� �����Ӱ� ���� �������� �ð� ����(Time.deltaTime)�� �̿��Ѵ�
    //�ð� * �ӵ� = �Ÿ� �� �̿�
    void Update()
    {
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
    }
}
