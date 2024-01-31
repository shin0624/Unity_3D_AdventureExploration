using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;

//�������� --> 1) Button�� Onclick ���� �� ���̾��Ű���� ���ڸ� �巡�׵���ϴ� ��Ȳ
// --> ���̾��Ű�� ������Ʈ �̸��� �ǳ��ָ� �ڵ����� Onclick���� ���εǵ��� �ڵ�ȭ ->void Bind()�� �ڵ�ȭ �� ��

// 2) Text ��� �� SerializeField�� �ϳ��ϳ� ���� ���� �� �ν����Ϳ��� �����ϴ� ��Ȳ

public class UI_Button : MonoBehaviour
{
#if UI�������޿���
    //[SerializeField]
    //Text _text;
    //TextMeshProUGUI _text;//��ư Ŭ�� �� canvas ���� Text ���ڰ� �����ϵ��� �ϱ� ����, ����Ƽ ������ ���ڸ� �Ѱ��� �ؽ�Ʈ ������ ����
    //TextMeshPro�� ����ϹǷ�, TextŸ�� ���ڴ� �ν����Ϳ��� �Ѱ��� �� ����-->TMPro ���ӽ����̽��� �����ϰ�, �ؽ�Ʈ�� TextMeshProUGUI  Ÿ������ �����ؾ� ��.
#endif

    //�������� Type�� �־����� Dictionary�� ����. ButtonŸ��, TextŸ���� ����Ƽ���� ������Ʈ�� ����Ʈ�� ������
    Dictionary<Type, UnityEngine.Object[]> _objects = new Dictionary<Type, UnityEngine.Object[]>();


    enum Buttons 
    {
         PointButton
    }

    enum Texts
    {
        PointText,
        ScoreText,
    }

    private void Start()
    {
        Bind<Button>(typeof(Buttons));//Buttons����ü ������ �ѱ�ڴٰ� ȣ��-->Buttons ����ü Ÿ���� Button�̶�� ������Ʈ�� ã�� �ش��ϴ� ���� �����Ѵ�
        Bind<Text>(typeof(Texts));//Texts����ü ������ �ѱ�ڴٰ� ȣ��
    }

    void Bind<T>(Type type) where T : UnityEngine.Object//Buttons���� �Ѱ��ָ� ���� ��ġ�� ������Ʈ�� �ڵ� �����ϵ��� �ϴ� �Լ�. Reflection�� �̿��� ��
    {
        //Button �Ǵ� Text�� �ڽ����� �ΰ� �ִ� ������Ʈ�� ã�ƾ� �ϹǷ�, Bind �Լ��� ���׸����� ����
       string[] names  =  Enum.GetNames(type);//C#���� �ִ� ���. ����ü �׸��� string �迭�� ��ȯ�� �� �ִ�.

        UnityEngine.Object[] objects = new UnityEngine.Object[names.Length];//����ü �׸��� string���� ��ȯ������ dictionary�� �ֱ� ���� key, value�� �ʿ�->key�� ���׸�Ÿ��, value�� ������Ʈ �迭
        _objects.Add(typeof(T), objects);

        //��������(1)�� �ڵ�ȭ�� ���� ���� ����
        for(int i=0;i<names.Length;i++)
        {
            objects[i] = Util.FindChild<T>(gameObject, names[i], true);//�ֻ��� �θ�, �̸��� ���ڷ� �ִ´�.
            //������ ���� ã�� ������Ʈ �̸��� objects�迭�� �־���� ��-->GameObject�� ������ �� ������ �̿��Ͽ� �ֻ��� ��ü(UI_Button)�� �ڽ� �� ���� �̸��� �ִ� �� ã�ƾ� ��
          
        }
    }


    int _score = 0;

  public void OnButtonClicked()//�� public���� ���־�� UI���� �����
    {
       
        _score++;
        //_text.text = $"Score : {_score}"; 
    }
}
