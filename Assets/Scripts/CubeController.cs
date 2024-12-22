using UnityEngine;
using DG.Tweening;

public class CubeController : MonoBehaviour
{
    [Header("Rotation Settings")]
    [SerializeField] private float rotationDuration = 1f;
    [SerializeField] private Ease rotationEase = Ease.InOutBounce;

    [Header("Scale Settings")]
    [SerializeField] private float scaleDuration = 0.5f; 
    [SerializeField] private Vector3 increasedScale = new Vector3(1, 1, 1); 
    [SerializeField] private Ease scaleEase = Ease.OutElastic;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log($"<color=blue>Button: 1</color> - <color=green>Rotating cube</color>");
            RotateCube();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log($"<color=blue>Button: 2</color> - <color=green>Punch scaling cube</color>");
            AnimateScale();
        }
    }

    private void RotateCube()
    {
        transform.DORotate(new Vector3(0, 360, 0), rotationDuration, RotateMode.FastBeyond360)
            .SetEase(rotationEase)
            .OnComplete(() => Debug.Log("<color=green>Rotation complete!</color>"));
    }

    private void AnimateScale()
    {
        
        transform.DOScale(increasedScale, scaleDuration)
            .SetEase(scaleEase)
            .OnComplete(() =>
            {
                transform.DOScale(Vector3.one, scaleDuration)
                    .SetEase(scaleEase)
                    .OnComplete(() => Debug.Log("<color=green>Scale animation complete!</color>"));
            });
    }
}
