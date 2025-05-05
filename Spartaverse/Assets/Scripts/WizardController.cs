using UnityEngine;
using UnityEngine.UI; // UI �ؽ�Ʈ ������ �ʿ�
using TMPro;

public class MageAnimatorController : MonoBehaviour
{
    private Animator animator;

    

    void Start()
    {
        animator = GetComponent<Animator>();
        Invoke("TriggerHit", 3f);
        Invoke("ShowDialogue", 4.5f); // 3�� + ��Ʈ �ִϸ��̼� �ð� �� ���
    }

    void TriggerHit()
    {
        animator.SetTrigger("Hit");
    }

    
}
