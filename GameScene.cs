using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
    // "Game" ������ ����� ��ũ��Ʈ
{
    void Start()// GameScene������Ʈ�� ����ִ� ������Ʈ�� off�� ���¿����� ui ���� �۵��ǵ��� �Ϸ��� Start ��� Awake�� ���
    {
        Init();
    }


    protected override void Init()
    {
        base.Init();

        SceneType = Define.Scene.Game;

        Managers.UI.ShowSceneUI<UI_Inven>();//���� ���� �� �⺻ UI�� �ҷ����� �ڵ� ��, ���� �� ������ �׼��� �̰��� �ۼ�


    }

    public override void Clear()
    {
        
    }
}
