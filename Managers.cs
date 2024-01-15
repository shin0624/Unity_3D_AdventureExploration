using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Managers : MonoBehaviour
{
    static Managers s_instance;//���ϼ� ���� ������ �̱���
    static Managers Instance { get { Init();   return s_instance; } }//�ܺο��� GetInstance ȣ�� �� Init()���� ��üũ �� ��ü�� ����� ��ȯ�ϴ� ���·� ���ư� ��
                                                                      //�ܺο��� Manager�ν��Ͻ��� ������ �� �� ����ϰ� �� �Լ�

    InputManager _input = new InputManager();//��ǲ�Ŵ��� ������ ����
    public static InputManager Input { get { return Instance._input; } }

    ResourceManager _resource = new ResourceManager();//���ҽ��Ŵ��� ������ ����
    public static ResourceManager Resource { get { return Instance._resource; } }

    //GetInstance()�� property�������� �ٲٰ��� �ϸ�
    //public static Managers Instance { get{Init(); return s_instance;} } �� �ٲ� �� Player���� Managers mg = Mangers.Instance �������� ȣ���ϸ� ��


    void Start()
    {
        //instance = this;//�ν��Ͻ��� �ڱ� �ڽ�(ó���� ������ �Ŵ����� ������Ʈ)���� ä���-->managers��ũ��Ʈ�� ������ �����Ǿ��� �� ���� �߻�(�������� instance�� ������ manager��ũ��Ʈ�� instance ���� ������� ����
        //-->�ذ�� : 

       // GameObject go = GameObject.Find("@Managers");
       // Managers mg = go.GetComponent<Managers>();//�������� instance�� ����Ǵ� ���� @Managers �� �ϳ��� �� ��

        //-->���� @Managers ������Ʈ�� �����Ǿ��ٸ�?
        //-->instance������ null�� ����, PlayerŬ�������� GetInstance()�� ȣ������ �� null���� ���޵� �� ���� �ٷ� ��� ���� �߻�
        //instance���� null�̶��, ��Ե� @Manangers�� ã�ų� ���� ����������-->Init()����
        Init();
    }

   
    void Update()
    {
        _input.OnUpdate();// Managers�� ���콺, Ű���� ���� �Է� üũ�� ����
    }

    static void Init()
    {
        if (s_instance == null)//�ν��Ͻ� ���� null�϶�
        {
            GameObject go = GameObject.Find("@Managers");// --> @Managers ������Ʈ�� ã�ƺ���
            if(go==null)//@Managers ������Ʈ�� ���ٸ�
            {
                go = new GameObject { name = "@Managers" };// ������Ʈ�� ���� �����
               go.AddComponent<Managers>();//���� ���� ������Ʈ�� Managers ��ũ��Ʈ�� �ٿ��ش�
            }

            DontDestroyOnLoad(go);//���� ������Ʈ�� ������� �����Ǿ�� �ȵǱ� ������ ����.
            s_instance = go.GetComponent<Managers>();
             //���� @Manager������Ʈ�� �߰��ߴٸ� Managers ��ũ��Ʈ�� �����´�
        }
    }
}
