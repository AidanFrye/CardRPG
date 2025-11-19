using UnityEngine;

public class EnemyDebug : MonoBehaviour
{
    void Start()
    {
        CheckVisibility();
    }

    public void CheckVisibility()
    {
        // Check Transform
        Debug.Log($"{name} position: {transform.position}, scale: {transform.localScale}, active: {gameObject.activeInHierarchy}");

        // Check Renderer
        Renderer[] renderers = GetComponentsInChildren<Renderer>();
        if (renderers.Length == 0)
        {
            Debug.LogWarning($"{name} has no Renderer components!");
        }
        else
        {
            foreach (var rend in renderers)
            {
                Debug.Log($"{name} Renderer: {rend.name}, enabled: {rend.enabled}, material: {(rend.sharedMaterial != null ? rend.sharedMaterial.name : "None")}");
            }
        }

        // Check Animator
        Animator animator = GetComponent<Animator>();
        if (animator != null)
        {
            Debug.Log($"{name} Animator enabled: {animator.enabled}, speed: {animator.speed}");
        }

        // Check layer & camera visibility
        Camera mainCam = Camera.main;
        if (mainCam != null)
        {
            int layerMask = 1 << gameObject.layer;
            bool camCanSee = (mainCam.cullingMask & layerMask) != 0;
            Debug.Log($"{name} layer: {gameObject.layer}, visible to Main Camera: {camCanSee}");
        }
    }
}