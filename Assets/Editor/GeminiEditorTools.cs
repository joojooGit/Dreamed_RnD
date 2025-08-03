
using UnityEngine;
using UnityEditor;
using UnityEngine.InputSystem;

public class GeminiEditorTools : EditorWindow
{
    [MenuItem("Gemini Tools/Create Player")]
    private static void CreatePlayer()
    {
        GameObject player = new GameObject("Player");
        player.transform.position = new Vector3(0, 1, 0);

        // Add CharacterController
        CharacterController controller = player.AddComponent<CharacterController>();
        controller.height = 2.0f;
        controller.center = new Vector3(0, 1, 0);

        // Add PlayerMovement and PlayerLook scripts
        player.AddComponent<PlayerMovement>();
        player.AddComponent<PlayerLook>();

        // Add Player Input component and set it up
        UnityEngine.InputSystem.PlayerInput playerInput = player.AddComponent<UnityEngine.InputSystem.PlayerInput>();
        InputActionAsset inputActionAsset = AssetDatabase.LoadAssetAtPath<InputActionAsset>("Assets/InputSystem_Actions.inputactions");
        if (inputActionAsset != null)
        {
            playerInput.actions = inputActionAsset;
            playerInput.notificationBehavior = PlayerNotifications.SendMessages;

            // Find the Player action map and enable it
            playerInput.currentActionMap = playerInput.actions.FindActionMap("Player");
            playerInput.currentActionMap.Enable();
        }
        else
        {
            Debug.LogError("Could not find 'InputSystem_Actions.inputactions' asset. Please make sure it's in the 'Assets' folder.");
        }

        // Create Camera as a child
        GameObject cameraGo = new GameObject("Main Camera");
        cameraGo.transform.SetParent(player.transform);
        cameraGo.transform.localPosition = new Vector3(0, 1.6f, 0);
        Camera camera = cameraGo.AddComponent<Camera>();
        camera.tag = "MainCamera";
        cameraGo.AddComponent<AudioListener>();

        // Assign transforms to PlayerLook
        PlayerLook playerLook = player.GetComponent<PlayerLook>();
        playerLook.playerBody = player.transform;
        playerLook.cameraTransform = cameraGo.transform;

        Selection.activeGameObject = player;
    }

    [MenuItem("Gemini Tools/Create Square Room")]
    private static void CreateSquareRoom()
    {
        GameObject roomParent = new GameObject("Square Room");

        // Floor
        GameObject floor = GameObject.CreatePrimitive(PrimitiveType.Plane);
        floor.name = "Floor";
        floor.transform.SetParent(roomParent.transform);
        floor.transform.position = new Vector3(0, 0, 0);
        floor.transform.localScale = new Vector3(2, 1, 2); // 20x20 size room

        // Walls
        CreateWall("Back Wall", new Vector3(0, 2.5f, 10), new Vector3(20, 5, 0.5f), roomParent.transform);
        CreateWall("Front Wall", new Vector3(0, 2.5f, -10), new Vector3(20, 5, 0.5f), roomParent.transform);
        CreateWall("Left Wall", new Vector3(-10, 2.5f, 0), new Vector3(0.5f, 5, 20), roomParent.transform);
        CreateWall("Right Wall", new Vector3(10, 2.5f, 0), new Vector3(0.5f, 5, 20), roomParent.transform);

        Selection.activeGameObject = roomParent;
    }

    [MenuItem("Gemini Tools/Create Simple Maze")]
    private static void CreateSimpleMaze()
    {
        GameObject mazeParent = new GameObject("Simple Maze");

        // Floor
        GameObject floor = GameObject.CreatePrimitive(PrimitiveType.Plane);
        floor.name = "Floor";
        floor.transform.SetParent(mazeParent.transform);
        floor.transform.position = new Vector3(0, 0, 0);
        floor.transform.localScale = new Vector3(5, 1, 5);

        // Walls
        CreateWall("Back Wall", new Vector3(0, 1, 25), new Vector3(50, 2, 1), mazeParent.transform);
        CreateWall("Front Wall", new Vector3(0, 1, -25), new Vector3(50, 2, 1), mazeParent.transform);
        CreateWall("Left Wall", new Vector3(-25, 1, 0), new Vector3(1, 2, 50), mazeParent.transform);
        CreateWall("Right Wall", new Vector3(25, 1, 0), new Vector3(1, 2, 50), mazeParent.transform);

        // Inner Walls
        CreateWall("Inner Wall 1", new Vector3(0, 1, 10), new Vector3(30, 2, 1), mazeParent.transform);
        CreateWall("Inner Wall 2", new Vector3(15, 1, -5), new Vector3(1, 2, 30), mazeParent.transform);

        Selection.activeGameObject = mazeParent;
    }

    private static void CreateWall(string name, Vector3 position, Vector3 scale, Transform parent)
    {
        GameObject wall = GameObject.CreatePrimitive(PrimitiveType.Cube);
        wall.name = name;
        wall.transform.SetParent(parent);
        wall.transform.position = position;
        wall.transform.localScale = scale;
    }
}
