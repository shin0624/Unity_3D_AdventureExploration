using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager 
{
    
    public T Load<T>(string path) where T : Object//�������� �ε��ϴ� �޼���� ���׸�Ÿ��
    {
        return Resources.Load<T>(path);
    }

    public GameObject Instantiate(string path, Transform parent = null)
    {
        GameObject prefab = Load<GameObject>($"Prefabs/{path}");//Prefabs���� ���� �ִ� �������� ���������� ����
        //ResourceManager�� �̿��� Instantiate()�� ������ ���� Prefabs/ �� �Ⱥٿ��� �� ��.
        if(prefab== null)
        {
            Debug.Log($"Failed to load prefab : {path}");//���� �������� null�̸� ��ο� �Բ� �α�ǥ��
            return null;
        }
    
        return Object.Instantiate(prefab, parent);//�����հ� �������� �����ؼ� ���� parent�� ����
    }

    public void Destroy(GameObject go)
    {
        if (go == null)
            return;

        Object.Destroy (go);
    }

    //-->���� �ڵ� �󿡼� ��� �� GameObject Tank;   Tank = Managers.Resource.Instantiate("Tank"); �������� ����ϸ� ��
}
