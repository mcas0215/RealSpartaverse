using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WizardEndGame : MonoBehaviour
{
    public TextMeshProUGUI interactionText; // "F 키를 눌러 종료" 같은 문구 표시용
    private bool playerInRange = false;

    void Start()
    {
        if (interactionText != null)
            interactionText.gameObject.SetActive(false); // 처음엔 숨김
    }

    void Update()
    {
        if (playerInRange = true && Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("게임 종료!");
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("트리거 진입: " + other.name);

        if (interactionText == null)
        {
            Debug.LogWarning("interactionText가 Inspector에서 연결되지 않았습니다!");
            return;
        }

        interactionText.gameObject.SetActive(true);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("트리거 벗어남: " + other.name);

        if (interactionText == null)
        {
            Debug.LogWarning("interactionText가 Inspector에서 연결되지 않았습니다!");
            return;
        }

        interactionText.gameObject.SetActive(false);
    }

}
