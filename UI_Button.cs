using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;

//�������� --> 1) Button�� Onclick ���� �� ���̾��Ű���� ���ڸ� �巡�׵���ϴ� ��Ȳ
// --> ���̾��Ű�� ������Ʈ �̸��� �ǳ��ָ� �ڵ����� Onclick���� ���εǵ��� �ڵ�ȭ ->void Bind()�� �ڵ�ȭ �� ��

// 2) Text ��� �� SerializeField�� �ϳ��ϳ� ���� ���� �� �ν����Ϳ��� �����ϴ� ��Ȳ

public class UI_Button : UI_Base
{
#if UI�������޿���
    //[SerializeField]
    //Text _text;
    //TextMeshProUGUI _text;//��ư Ŭ�� �� canvas ���� Text ���ڰ� �����ϵ��� �ϱ� ����, ����Ƽ ������ ���ڸ� �Ѱ��� �ؽ�Ʈ ������ ����
    //TextMeshPro�� ����ϹǷ�, TextŸ�� ���ڴ� �ν����Ϳ��� �Ѱ��� �� ����-->TMPro ���ӽ����̽��� �����ϰ�, �ؽ�Ʈ�� TextMeshProUGUI  Ÿ������ �����ؾ� ��.
#endif
    enum Buttons 
    {
         PointButton
    }

    enum Texts
    {
        PointText,
        ScoreText,
    }

    enum GameObjects //Bind ��� �� ������Ʈ Ÿ�� �Ӹ� �ƴ϶�, ���ӿ�����Ʈ ��ü(ex GameObject obj)�� �Ѱ��ְ��� �� ���� ���Ͽ� �ۼ�
    { 
        TestObject,
    }

    private void Start()
    {
        Bind<Button>(typeof(Buttons));//Buttons����ü ������ �ѱ�ڴٰ� ȣ��-->Buttons ����ü Ÿ���� Button�̶�� ������Ʈ�� ã�� �ش��ϴ� ���� �����Ѵ�
        Bind<TextMeshProUGUI>(typeof(Texts));//Texts����ü ������ �ѱ�ڴٰ� ȣ��
        Bind<GameObject>(typeof(GameObjects));

        //Get<TextMeshProUGUI>((int)Texts.ScoreText).text = "Bind Test";//TextMeshPro�� ����ϹǷ�, TextŸ�� ���ڴ� �ν����Ϳ��� �Ѱ��� �� ����-->TMPro ���ӽ����̽��� �����ϰ�, �ؽ�Ʈ�� TextMeshProUGUI  Ÿ������ �����ؾ� ��.
        GetText((int)Texts.ScoreText).text = "BindTest";
    }

    int _score = 0;

  public void OnButtonClicked()//�� public���� ���־�� UI���� �����
    {  
        _score++;
        //_text.text = $"Score : {_score}"; 
    }
}
