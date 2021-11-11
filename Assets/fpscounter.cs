using UnityEngine;
using UnityEngine.UI;
 
public class fpscounter : MonoBehaviour
{

    [SerializeField] private float _hudRefreshRate = 1f;
 
    private float _timer;
 
    private void Update()
    {
        if (Time.unscaledTime > _timer)
        {
            int fps = (int)(1f / Time.unscaledDeltaTime);
            Debug.Log(fps);
            _timer = Time.unscaledTime + _hudRefreshRate;

        }
    }
}