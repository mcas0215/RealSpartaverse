using System.Collections;
using UnityEngine;

public class SwampyInLoungeController : MonoBehaviour
{
    public float colorChangeDuration = 1f;
    public Color hitColor = Color.black; // �ν����Ϳ��� ����

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
        // 1�� ��� �� ù �̵�
        yield return new WaitForSeconds(1f);
        yield return StartCoroutine(SmoothMove(transform.position, transform.position + Vector3.right * 0.5f, 0.3f));

        // 1.5�� ��� �� �� ��° �̵�
        yield return new WaitForSeconds(1.5f);
        yield return StartCoroutine(SmoothMove(transform.position, transform.position + Vector3.right * 0.5f, 0.3f));

        // 0.6�� ��� �� ������ �̵�
        yield return new WaitForSeconds(0.3f);
        yield return StartCoroutine(SmoothMove(transform.position, transform.position + Vector3.right * -2.5f, 0.5f));

        // �ִϸ��̼� ����
        if (animator != null)
        animator.enabled = false;
        spriteRenderer.sprite = SwampyFinalSprite;

        // ���� õõ�� ����
        Color startColor = spriteRenderer.color;
        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime / colorChangeDuration;
            spriteRenderer.color = Color.Lerp(startColor, hitColor, t);
            yield return null;
        }

        // ��Ȯ�� ���� �� ����
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

        transform.position = end; // ��Ȯ�� ���� ��ġ�� ����
    }
}
