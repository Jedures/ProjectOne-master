using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region Public Variables

    public static GameManager Instance = null;

    public GameObject TestObjForStorate;

    #endregion

    #region Unity Methods

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        // get score from save
        Storage.Score = 100;
    }

    private void Start()
    {
        TestObjForStorate = GameObject.Find("Score");
    }

    private void Update()
    {
        if (TestObjForStorate != null)
            TestObjForStorate.GetComponent<Text>().text = string.Format("Score: {0}", Storage.Score);
    }

    #endregion

}
