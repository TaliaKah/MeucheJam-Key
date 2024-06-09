using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Le personnage à suivre
    public Vector3 offset;   // Décalage entre la caméra et le personnage
    public float smoothSpeed = 0.125f; // Vitesse de lissage du mouvement

    private void LateUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}
