using UnityEngine;
using UnityEngine.UI; // UI 텍스트 쓰려면 필요
using TMPro;

public class MageAnimatorController : MonoBehaviour
{
    private Animator animator;

    

    void Start()
    {
        animator = GetComponent<Animator>();
        Invoke("TriggerHit", 3f);
        Invoke("ShowDialogue", 4.5f); // 3초 + 히트 애니메이션 시간 뒤 대사
    }

    void TriggerHit()
    {
        animator.SetTrigger("Hit");
    }

    
}
