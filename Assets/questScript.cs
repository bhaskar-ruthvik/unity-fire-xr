using UnityEngine;
using UnityEngine.UI;

public class questScript : MonoBehaviour
{
    [SerializeField] private Camera uiCamera;
    private Vector3 targetPosition;
    private RectTransform pointerRectTransform;
    private Canvas canvas;

    private void Start()
    {
        targetPosition = new Vector3(-13.54184f, -3.92f, -44.26543f);

        Transform questPointerTransform = GameObject.Find("QuestPointer")?.transform;
        Transform pointerTransform = questPointerTransform?.Find("Pointer");

        if (pointerTransform == null)
        {
            Debug.LogError("Pointer Transform is null!");
            return;
        }

        pointerRectTransform = pointerTransform.GetComponent<RectTransform>();
        canvas = pointerRectTransform.GetComponentInParent<Canvas>();

        if (canvas == null)
        {
            Debug.LogError("No Canvas found! Make sure the pointer is inside a Canvas.");
        }
    }

    private void Update()
    {
        if (pointerRectTransform == null || canvas == null)
        {
            return;
        }

        // Convert target world position to screen position
        Vector3 targetScreenPos = Camera.main.WorldToScreenPoint(targetPosition);
        bool isOffScreen = targetScreenPos.x <= 0 || targetScreenPos.x >= Screen.width ||
                           targetScreenPos.y <= 0 || targetScreenPos.y >= Screen.height;

        // If the target is off-screen, clamp the position to screen bounds
        if (isOffScreen)
        {
            targetScreenPos.x = Mathf.Clamp(targetScreenPos.x, 50, Screen.width - 50);
            targetScreenPos.y = Mathf.Clamp(targetScreenPos.y, 50, Screen.height - 50);
        }

        // Convert screen position to UI position (only if using Screen Space - Camera or Overlay)
        Vector2 uiPosition;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, targetScreenPos, uiCamera, out uiPosition);
        pointerRectTransform.anchoredPosition = uiPosition;

        // Rotate the pointer to face the target
        Vector3 direction = (targetPosition - Camera.main.transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        pointerRectTransform.localEulerAngles = new Vector3(0, 0, angle);
    }
}
