using UnityEngine;

public class Canon : MonoBehaviour, ICanon
{
    public void SendShot(float damage)
    {
        Debug.Log(string.Format("Send shot. Damage = {0}", damage));


    }
}
