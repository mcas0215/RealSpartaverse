using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WizardEndGame : MonoBehaviour
{
    public TextMeshProUGUI interactionText; // "F Ű�� ���� ����" ���� ���� ǥ�ÿ�
    private bool playerInRange = false;

    void Start()
    {
        if (interactionText != null)
            interactionText.gameObject.SetActive(false); // ó���� ����
    }

    void Update()
    {
        if (playerInRange = true && Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("���� ����!");
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Ʈ���� ����: " + other.name);

        if (interactionText == null)
        {
            Debug.LogWarning("interactionText�� Inspector���� ������� �ʾҽ��ϴ�!");
            return;
        }

        interactionText.gameObject.SetActive(true);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Ʈ���� ���: " + other.name);

        if (interactionText == null)
        {
            Debug.LogWarning("interactionText�� Inspector���� ������� �ʾҽ��ϴ�!");
            return;
        }

        interactionText.gameObject.SetActive(false);
    }

}
