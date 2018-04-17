using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour, IShip
{
    #region Public variables

    public GameObject DeathScreen;
    public GameObject target = null;
    public float ShipHealth = 100f;
    public float ShipDamage = 0.1f;
    public float MoveSpeed = 5f;
    public float Drag = 0.5f;
    public float TerminalRotationSpeed = 25.0f;
    public int score = 0;

    public Vector3 MoveVector { get; set; }

    public JoystickController joystick;

    [SerializeField]
    public bool canMove = true;

    #endregion

    #region Private variables

    private Rigidbody2D rigidBody;

    #endregion

    #region Implementation of IShip

    private List<IPart> PartList = new List<IPart>();

    public List<IPart> GetPartList()
    {
        return PartList;
    }

    #endregion

    #region Unity Methods

    private void Start()
    {

        rigidBody = gameObject.GetComponent<Rigidbody2D>();
        rigidBody.gravityScale = 0f;
        //rigidBody.angularVelocity = TerminalRotationSpeed;
        rigidBody.drag = Drag;
    }
    private void FixedUpdate()
    {
        if (canMove)
            MoveUpdate();

    }

    #endregion

    #region Private Methods

    private void MoveUpdate()
    {
        MoveVector = PoolInput();
        rigidBody.AddForce((MoveVector * MoveSpeed));
        float rotation = MoveVector.y * 15f;
        rotation *= Time.deltaTime;
        transform.Rotate(0, 0, -rotation);
    }

    private Vector3 PoolInput()
    {
        Vector3 result = Vector3.zero;

        result.x = joystick.GetHorizontal();
        result.y = joystick.GetVertical();

        if (result.magnitude > 1)
            result.Normalize();

        return result;
    }
    public void GetDamage(float damage)
    {
        ShipHealth -= damage;
    }

    public void SendDamage(float damage, GameObject target)
    {
        StartCoroutine(AttackDelay(target));
    }
    public void Death()
    {
        DeathScreen.SetActive(true);
        StartCoroutine(Deathframe());
    }

    IEnumerator Deathframe()
    {
        yield return new WaitForSeconds(5f);
        Loading.Load(LoadingScene.Main);
    }

    IEnumerator AttackDelay(GameObject target)
    {
        yield return new WaitForSeconds(1f);
        target.GetComponent<AiController>().ShipHealth -= ShipDamage;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy") SendDamage(ShipDamage, collision.gameObject);

        #endregion
    }
}
