using UnityEngine;

public class RandomAnimationPlayer : MonoBehaviour
{
    public Animator animator; // ��������� �� Animator
    public string[] animationNames; // ����� ���� �������

    void Update()
    {
        // ���������� ���������� ������ E
        if (Input.GetKeyDown(KeyCode.E))
        {
            PlayRandomAnimation();
        }
    }

    void PlayRandomAnimation()
    {
        if (animationNames.Length > 0)
        {
            // �������� ���������� ������ � ������
            int randomIndex = Random.Range(0, animationNames.Length);

            // �������� ������� �� ������
            animator.Play(animationNames[randomIndex]);

            Debug.Log("���������� �������: " + animationNames[randomIndex]);
        }
        else
        {
            Debug.LogWarning("����� animationNames �������!");
        }
    }
}