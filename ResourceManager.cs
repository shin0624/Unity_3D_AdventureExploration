using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager 
{
    
    public T Load<T>(string path) where T : Object//�������� �ε��ϴ� �޼���� ���׸�Ÿ��
    {
        return Resources.Load<T>(path);
    }

    public GameObject Instantiate(string path, Transform parent = null)//�������� �ε��ϴ� �޼���
    {
        GameObject prefab = Load<GameObject>($"Prefabs/{path}");//Prefabs���� ���� �ִ� �������� ���������� ����
        //ResourceManager�� �̿��� Instantiate()�� ������ ���� Prefabs/ �� �Ⱥٿ��� �� ��.
        if(prefab== null)
        {
            Debug.Log($"Failed to load prefab : {path}");//���� �������� null�̸� ��ο� �Բ� �α�ǥ��
            return null;
        }
    
        GameObject go = Object.Instantiate(prefab, parent);
        int index = go.name.IndexOf("(Clone)");
        if(index>0)
            go.name = go.name.Substring(0, index);//Substring(0, index) : 0�� ~ index �� ������ ���ڿ��� �ڸ���.

        return go;
    }

    public void Destroy(GameObject go)
    {
        if (go == null)
            return;

        Object.Destroy (go);
    }

    //-->���� �ڵ� �󿡼� ��� �� GameObject Tank;   Tank = Managers.Resource.Instantiate("Tank"); �������� ����ϸ� ��
}
