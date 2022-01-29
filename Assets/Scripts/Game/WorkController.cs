using UnityEngine;

public class WorkController : MonoBehaviour
{
    public bool isActive = false;
    public float efficiencyLossPerSecond = 0.10f;
    public GameObject[] rooms;
    public Room currentRoom;
    public Transform officeWork;

    private void Awake()
    {
        rooms = Resources.LoadAll<GameObject>("Rooms");
        LoadRoom();
    }

    private void Update()
    {
        if (isActive)
        {
            GameFlow.instance.currentEfficiency = Mathf.Clamp(GameFlow.instance.currentEfficiency - efficiencyLossPerSecond * Time.deltaTime, GameFlow.minEfficiency, GameFlow.maxEfficiency);
            //GameFlow.instance.currentEfficiency -= efficiencyLossPerSecond * Time.deltaTime;
        }
    }

    public void Activate()
    {
        isActive = true;

    }

    public void Deactivate()
    {
        isActive = false;
    }

    public void LoadRoom()
    {
        int ran = Random.Range(0, rooms.Length);
        if (currentRoom != null)
        {
            while ((rooms[ran].name + "(Clone)") == currentRoom.gameObject.name)
            {
                ran = Random.Range(0, rooms.Length);
            }
            Debug.Log("Nombres: " + rooms[ran].name + ", " + currentRoom.gameObject.name + ", " + ran);
            Destroy(currentRoom.gameObject);
        }

        currentRoom = Instantiate(rooms[ran]).GetComponent<Room>();
        currentRoom.transform.SetParent(officeWork);
    }
}
