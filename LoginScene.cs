using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginScene : BaseScene
{
    //Login ������ ����� ��ũ��Ʈ. login ������ Ư�� �׼� �ߵ� �� Game������ �Ѿ���� ���� / ����Ƽ File->BuildSetting �ʼ�

    protected override void Init()
    {
        base.Init();
        SceneType = Define.Scene.Login;

       
            
    }

    private void Update()
    {
        //Ư�� Ű �Է� �� ���� ������ �̵�
        if (Input.GetKeyDown(KeyCode.Return))
        {
            // SceneManager.LoadScene("Game");//LoadScene : ������ ���� Scene�� ������ ������ Scene�� ���ʷ� �ε�-->�� �Ը�� ���ð��� �����

            Managers.Scene.LoadScene(Define.Scene.Game);//SceneManangerEX���� ���� ������ LoadScene(���� : Define enum)���
            //*Async �Լ� ���� �̿��ϸ� �α��� â�������� ��׶���� ���� �� ���ҽ��� ���ݾ� �ε��� �� �����Ƿ� �����ϰ� ��� ����
        }
    }


    public override void Clear()
    {
        Debug.Log("Login Scene Clear");
    }

}
