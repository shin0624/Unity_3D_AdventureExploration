using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Util//��ɼ� �Լ����� �����ϴ� ��ũ��Ʈ 
{
    //�ֻ��� ��ü�� �̸��� ����, ���� �̸��� �Է����� ������ �̸� ��x, Ÿ�Կ� �ش��ϸ� ����,recursive : �ڽ��� ã�� �� ���� �ڽ� �ϳ��� ã�� ������ �ڽ��� �ڽı��� ��������� ã�� ������ ����
    public static T FindChild<T>(GameObject go, string name = null, bool recursive = false) where T : UnityEngine.Object//����Ƽ������Ʈ�� ã�� ������ �������� ����
    {// T : Button, Text �� ã�����ϴ� ������Ʈ
        if (go == null)//�ֻ��� ��ü�� null�� ��=null ����
            return null;

        if (recursive == false)//���� �ڽ� �ϳ��� Ž��
        {
            for(int i = 0; i < go.transform.childCount; i++)// childCount�� ����Ͽ� �ֻ�����ü�� �ڽ� ������ŭ ���� �� GetChild(i)�� �����´�.
            {
              Transform transform =   go.transform.GetChild(i);//Transform���� ���� : GameObject�� Transform�� ���� �Դٰ��� �� �� �ִ� ����
                if (string.IsNullOrEmpty(name) || transform.name == name)//�̸� �Է� ���ο� ��ġ ���� Ȯ��
                {
                    T component = transform.GetComponent<T>();//�̸� ���α��� ����ߴٸ� ������Ʈ ������ Ȯ��
                    if (component != null)//������Ʈ�� �ִٸ� ����
                        return component;
                }
            }
        }
        else//�ڽ��� �ڽı��� ��� Ž��
        {
            foreach(T component in go.GetComponentsInChildren<T>())// GetComponentsInChildren���� ���� ������Ʈ�� �����ִ� T Ÿ�� ������Ʈ�� �ϳ��ϳ� ��ĵ
            {
                if (string.IsNullOrEmpty(name) || component.name == name)//Ȥ�� �̸��� �Է����� ���� ���, ������ TŸ�� �ϳ��� ã���� ��ȯ�ǵ��� isNullOrEmpty�� �̿�. name�� Empty�̰ų� ���� ã�� name�̸� ���ϵǵ���
                    return component;
            }
        }
        return null;//ã�� ���� ��� null ����
    }
}