using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager//�̱������� ������ Managers�� �̹� �����Ƿ� InputManager�� �Ϲ� ��ũ��Ʈ�� ����
{
    public Action KeyAction = null;//��������Ʈ -->������Ʈ���� ��ǲ�Ŵ����� �Է��� üũ�ϰ� �Է��� �ִٸ� ������

  
    public void OnUpdate()
    {
        if (Input.anyKey == false)
        {
            return;
        }
        if (KeyAction != null)
        {
            KeyAction.Invoke();
        }
    }
}
