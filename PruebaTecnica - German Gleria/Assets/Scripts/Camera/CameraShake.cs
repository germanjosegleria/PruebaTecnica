using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public IEnumerator Sacudir(float duracion, float magnitud)
    {
        Vector3 posicionOriginal = transform.localPosition;

        float tiempoTranscurrido = 0.0f;

        while (tiempoTranscurrido < duracion)
        {
            float x = Random.Range(-1f, 1f) * magnitud;
            float y = Random.Range(-1f, 1f) * magnitud;

            transform.localPosition = new Vector3(posicionOriginal.x + x, posicionOriginal.y + y, posicionOriginal.z);

            tiempoTranscurrido += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = posicionOriginal; 
    }
}
