using System.Collections;
using UnityEngine;

public class SwampyInLoungeController : MonoBehaviour
{
    public float colorChangeDuration = 1f;
    public Color hitColor = Color.black; // 인스펙터에서 설정

    private Animator animator;
    private SpriteRenderer spriteRenderer;
    public Sprite SwampyFinalSprite;

    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(DeathSequence());
    }

    IEnumerator DeathSequence()
    {
        // 1초 대기 후 첫 이동
        yield return new WaitForSeconds(1f);
        yield return StartCoroutine(SmoothMove(transform.position, transform.position + Vector3.right * 0.5f, 0.3f));

        // 1.5초 대기 후 두 번째 이동
        yield return new WaitForSeconds(1.5f);
        yield return StartCoroutine(SmoothMove(transform.position, transform.position + Vector3.right * 0.5f, 0.3f));

        // 0.6초 대기 후 마지막 이동
        yield return new WaitForSeconds(0.3f);
        yield return StartCoroutine(SmoothMove(transform.position, transform.position + Vector3.right * -2.5f, 0.5f));

        // 애니메이션 멈춤
        if (animator != null)
        animator.enabled = false;
        spriteRenderer.sprite = SwampyFinalSprite;

        // 색상 천천히 변경
        Color startColor = spriteRenderer.color;
        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime / colorChangeDuration;
            spriteRenderer.color = Color.Lerp(startColor, hitColor, t);
            yield return null;
        }

        // 정확한 최종 색 고정
        spriteRenderer.color = hitColor;
    }

    IEnumerator SmoothMove(Vector3 start, Vector3 end, float duration)
    {
        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime / duration;
            transform.position = Vector3.Lerp(start, end, t);
            yield return null;
        }

        transform.position = end; // 정확히 도착 위치에 고정
    }
}
