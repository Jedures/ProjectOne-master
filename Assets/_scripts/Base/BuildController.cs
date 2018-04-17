using UnityEngine;

public class BuildController : MonoBehaviour
{
    #region TEST CODE DELETE

    public bool BuildMode = false;

    public GameObject BuildOnButton;
    public GameObject BuildOffButton;

    public GameObject Player;
    public GridController Grid;
    public GameObject TestPartPrefabObject;

    private void Update()
    {
       
    }

    private void PlaceCubeNear(Vector3 clickPoint)
    {
        var finalPosition = Grid.GetNearestPointOnGrid(clickPoint);

        var part = Instantiate(TestPartPrefabObject);
        part.transform.position = new Vector3(finalPosition.x, finalPosition.y, Player.transform.position.z);
        part.transform.SetParent(Player.transform);

       // Player.GetComponent<ShipController>().GetPartList().Add(part.GetComponent<ShipPart>());
    }

    public void BuildOnButtonClick()
    {
        BuildMode = true;
        Player.GetComponent<ShipController>().canMove = false;
        BuildOnButton.SetActive(false);
        BuildOffButton.SetActive(true);
    }

    public void BuildOffButtonClick()
    {
        BuildMode = false;
        Player.GetComponent<ShipController>().canMove = true;
        BuildOnButton.SetActive(true);
        BuildOffButton.SetActive(false);
    }

    #endregion
}
