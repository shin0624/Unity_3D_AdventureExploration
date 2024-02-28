using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class SoundManager //������ҽ� : mp3�÷��̾�, �����Ŭ�� : mp3����, ����������� : ��
{
    AudioSource[] _audioSources = new AudioSource[(int)Define.Sound.MaxCount];//���Ŀ� �з��� �ʿ��� �� ������ BGM��, EFFECT�� �ΰ� ����

    Dictionary<string, AudioClip> _audioClips = new Dictionary<string, AudioClip>();//Effectȿ���� �ݺ��� ���� ��ųʸ�<���, �����Ŭ��>
    //-->������ : SoundManager�� Managers �Ʒ��� �־�, Don`t Destroy�� ��޵Ǿ� �޸𸮰� ����� ��.
    //-->�ذ� : Clear()�� �̿��Ͽ� �� �̵��ø��� �޸𸮸� �������

    public void Init()//_audioSources �迭�� ä��� ���ؼ�, �� ���� ������Ʈ�� ������ �� AudioSource������Ʈ�� �ٿ��� ��
    {
        GameObject root = GameObject.Find("@Sound");
        if(root == null)
        {
            root = new GameObject { name = "@Sound" };
            Object.DontDestroyOnLoad(root);// �� �̵� �Ŀ��� �������� �ʰ� �ǵ���

            string[] soundNames = System.Enum.GetNames(typeof(Define.Sound));//���÷����� �̿��Ͽ� Sound�� �ִ� �̸��� ����
            for(int i = 0; i < soundNames.Length - 1; i++)//Sounds�� �������� MaxCount�� ���ʿ��ϹǷ� -1
            {
                GameObject go = new GameObject { name = soundNames[i] };
                _audioSources[i] = go.AddComponent<AudioSource>();//������ҽ� ������Ʈ�� ���� �� sources �迭�� �ִ´�.
                go.transform.parent = root.transform;//root�� Ʈ���������� �θ� ����
            }

            _audioSources[(int)Define.Sound.Bgm].loop = true;//��������� loop�� true�� �Ͽ� �ݺ����
        }
    }

    public void Clear()//_audioClips�� �޸𸮸� ���� �Լ�
    {
        foreach(AudioSource audioSource in _audioSources)
        {
            audioSource.clip = null;
            audioSource.Stop();
        }
        _audioClips.Clear();     
    }

    //audioClip�� �޴� Play��, path�� �޴� play �� 2���� ������ ����--> path�� �޴� ���� ������ �ٸ� ������ ȣ���ϵ��� �Ͽ�, �ڵ� �߰����� �� �߻��� �� �ִ� ������ ����.

    public void Play( string path, Define.Sound type = Define.Sound.Effect,  float pitch = 1.0f)//string���� AudioSource ��θ� �ް�, pitch�� �ӵ�����. type�� �⺻���� Effectfh
    {

#if �����Ŭ������κ�_�ߺ�����
            AudioSource audioSource = _audioSources[(int)Define.Sound.Bgm];
            if (audioSource.isPlaying)//�̹� Bgm�� �������̶��, Stop�� �� �ٸ� Bgm���� ������ �� �ֵ��� �Ѵ�.
                audioSource.Stop();

            audioSource.pitch = pitch;
            audioSource.clip = audioClip;//Load()�� ������ �����Ŭ�� ��ü�� audioSource�� clip���� ����
            audioSource.Play();//������ Bgm�� Loop�� true�� ���־�����, Play()�� ����� �����ָ� ��
#endif

#if �����Ŭ������κ�_�ߺ�����
            AudioSource audioSource = _audioSources[(int)Define.Sound.Effect];
            audioSource.pitch = pitch;
            audioSource.PlayOneShot(audioClip);
#endif
        AudioClip audioClip = GetOrAddAudioClip(path, type);

        Play(audioClip, type, pitch);
    }

    public void Play(AudioClip audioClip, Define.Sound type = Define.Sound.Effect, float pitch = 1.0f)//�����Ŭ���� ���� audioClip���� �޴� ������ Play()-->������ ��θ� �־� �����ϴ� ���� ���ŷӴٸ� ���
    {
        if (audioClip == null)
            return;

        if (type == Define.Sound.Bgm)
        {
            AudioSource audioSource = _audioSources[(int)Define.Sound.Bgm];
            if (audioSource.isPlaying)//�̹� Bgm�� �������̶��, Stop�� �� �ٸ� Bgm���� ������ �� �ֵ��� �Ѵ�.
                audioSource.Stop();

            audioSource.pitch = pitch;
            audioSource.clip = audioClip;//Load()�� ������ �����Ŭ�� ��ü�� audioSource�� clip���� ����
            audioSource.Play();//������ Bgm�� Loop�� true�� ���־�����, Play()�� ����� �����ָ� ��
        }

        else
        {

            AudioSource audioSource = _audioSources[(int)Define.Sound.Effect];
            audioSource.pitch = pitch;
            audioSource.PlayOneShot(audioClip);
        }

    }
          
    AudioClip GetOrAddAudioClip(string path, Define.Sound type = Define.Sound.Effect)//�����Ŭ���� �ִٸ� �߰�, ���ٸ� ���� �� �߰�
    {
        if (path.Contains("Sounds/") == false)//���� Sounds/�� �����ϴ� ��ΰ� ���ٸ� ��θ� ��������
            path = $"Sounds/{path}";

        AudioClip audioClip = null;

        if (type == Define.Sound.Bgm)
        {
           audioClip = Managers.Resource.Load<AudioClip>(path);//�����Ŭ�� ��ü�� �����Ͽ� Load��ɾ�� �����Ŭ���� �����´�.
            
        }
        else//�ݺ��Ͽ� �����Ŭ����  Load�ϴ� �� ����, ��ųʸ��� ����Ͽ� ĳ���Ѵ�
        {
            // AudioClip audioClip = Managers.Resource.Load<AudioClip>(path);//�����Ŭ�� ��ü�� �����Ͽ� Load��ɾ�� �����Ŭ���� �����´�.
            if (_audioClips.TryGetValue(path, out audioClip) == false)//ĳ���ϰ� �ִ� path�� Ű�� �Ͽ� audioClip�� ������ return�Ѵ�. 
            {
                audioClip = Managers.Resource.Load<AudioClip>(path);// false�̸�(�����Ŭ���� ���ٸ�) Load()�Ͽ� ��ųʸ��� {Ű : path, value : �����Ŭ��}���� �־��ش�.
                _audioClips.Add(path, audioClip);
            }
        }
        if (audioClip == null)//�����Ŭ�� ������ Ȯ��
        
            Debug.Log($"AudioClip Missing {path}");
        

        return audioClip;
    }
}
