using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameScene : BaseScene
// "Game" ������ ����� ��ũ��Ʈ
{
#if Coroutine
    //Coroutine : �����ƾ�� �Ͻ� �����ϰ� �簳�� �� ���� -->�Ͻ� ���� �� �Լ� �� ������ ����Ǿ��� ���� �״�� �̾���(������� ����)
    //��� 1. ���� �ɸ��� �۾��� ��� ���ų� ���ϴ� Ÿ�ֿ̹� �Լ��� ��� stop/����-->�ð� ������ ����
    // 2. ���ϴ� Ÿ���̳� Ŭ������ return ����

    class CoroutineTest : IEnumerable//�ڷ�ƾ ���� �� �ٿ��־�� �� �������̽� IEnumerable
    {
        public IEnumerator GetEnumerator()
        {//�ڷ�ƾ ���� �� ���̴� yield --> yield return 1,2,3,4.. �� ��� return 1 ���� �� return 2, 3, 4 �ϳ��ϳ��� �����Ͽ� ���� ���·� �Ѿ �� ����.
          // �ڷ�ƾ������ ���� ����� yield break(�Ϲ� �Լ������� return �� �ش�)

            for( int i=0;i<100000;i++)
            {
                if (i % 10000 == 0)
                    yield return null;//100000 �� �ݺ����� 10000��° ���� �޽� �� �Ʒ��� foreach������ ���� �Ѿ. foreach������ ���� ������ ������ �� ���� �� �ٽ� �ڷ�ƾ���� ���ƿ�
            }
           


        }
    }
#endif
    protected override void Init()
    {
        base.Init();

        SceneType = Define.Scene.Game;

        Managers.UI.ShowSceneUI<UI_Inven>();//���� ���� �� �⺻ UI�� �ҷ����� �ڵ� ��, ���� �� ������ �׼��� �̰��� �ۼ�

        StartCoroutine("ExplodeAfterSeconds", 4.0f);//���ϴ� �ڷ�ƾ�� �����ϴ� �Լ�. 4�� �Ŀ� �Ʒ� ��ų �ߵ�
                                                    //���� �ڷ�ƾ�� ����ϰ��� �ϸ� StartCoroutine�� CoroutineŸ���� co�� ����� StopCoroutin(co)�� ����ϸ� ��.

#if coroutineTest
        CoroutineTest test = new CoroutineTest();
        foreach (var t in test)
        {//��ȯ�Ǵ� t�� ������ƮŸ���̹Ƿ�, yield return�� ��� Ÿ���̴� ����(null�� ����).
           
            Debug.Log(t);
        }
#endif

#if StopCoroutine
        Coroutine co;
        co = StartCoroutine("ExplodeAfterSeconds", 4.0f);
        StartCoroutine("CoStopExplode", 2.0f);

        IEnumerator CoStopExplode(float seconds)
        {
            Debug.Log("stop endter");
             yield return new WaitForSeconds(seconds);
             Debug.Log("stop execute!");
             if(co!=null)
             {
             StopCoroutine(co);
             co = null;
             }
         }
    
#endif
    }
    IEnumerator ExplodeAfterSeconds(float seconds)//coroutine����-> ���� �� �Ŀ� �ߵ��ϴ� ��ų
    {
        Debug.Log("explode endter");
        yield return new WaitForSeconds(seconds);//�����ð�(second) ��ŭ ��� �� ����.-->StartCoroutine(������ ��ų, ���ð�)����.
        Debug.Log("explode execute!");
        
    }


    public override void Clear()
    {
        
    }
}
