using UnityEngine;

public class Canon : MonoBehaviour, ICanon
{
    public void SendShot(float damage)
    {
        // play all animation and audio

        // DO shot with damage

        Debug.Log(string.Format("Send shot. Damage = {0}", damage));
    }
}
