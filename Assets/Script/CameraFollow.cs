using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Objek yang akan diikuti oleh kamera
    public float smoothSpeed = 0.125f; // Kecepatan pergerakan kamera
    public Vector3 offset; // Jarak antara kamera dan objek yang diikuti

    public float minX; // Batas kiri pergerakan kamera
    public float maxX; // Batas kanan pergerakan kamera

    private void FixedUpdate() 
    {
        // Mengambil posisi kamera yang diinginkan
        Vector3 desiredPosition = target.position + offset;

        // Menghitung posisi kamera yang diinginkan dengan smoothing
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Membatasi posisi kamera pada batasan minX dan maxX
        float clampedX = Mathf.Clamp(smoothedPosition.x, minX, maxX);

        // Mengatur posisi kamera sesuai dengan yang diinginkan dan batasan
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
    }
}
