using UnityEngine;
using System.Collections;

public class Stage1Scratch : MonoBehaviour
{

    public Texture backwalltext;
    public Texture2D crosshair;
    public GameObject robotarms;
    public GameObject fpc;
    public GameObject graphics;
    public GameObject mainCam;
    public RuntimeAnimatorController robotanim;
    public AudioClip mkExcel;
    public AudioClip torture;
    // Use this for initialization
    void Start()
    {
        //Back Wall 1
        GameObject cube1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube1.name = "Back Wall 1";
        cube1.transform.localScale = new Vector3(18.40298F, 40, 1);
        cube1.transform.position = new Vector3(10.54097F, 20, 24.60629F);
        cube1.renderer.material.mainTexture = backwalltext;

        //Initialization
        this.gameObject.AddComponent("CursorTime");
        this.gameObject.transform.position = new Vector3(12.52164F, 61.42303F, -8.017669F);
        this.gameObject.GetComponent<CursorTime>().cursorImage = crosshair;
        this.gameObject.GetComponent<BoxCollider>().isTrigger = true;
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        this.gameObject.GetComponent<MeshRenderer>().enabled = false;

        //Arm Camera
        GameObject armCam = new GameObject("Arm Camera");
        armCam.AddComponent("Camera");
        armCam.GetComponent<Camera>().clearFlags = CameraClearFlags.Depth;
        armCam.GetComponent<Camera>().cullingMask = 256; //Arms Layer
        armCam.GetComponent<Camera>().nearClipPlane = 0.01F;
        armCam.GetComponent<Camera>().farClipPlane = 9.7F;
        armCam.GetComponent<Camera>().depth = 1;
        armCam.transform.localRotation = Quaternion.Euler(0, 179.7852F, 0);
        armCam.transform.position = new Vector3(1.097979F, 11.44633F, -9.883818F);


        //Main Camera
        mainCam.name = "Main Camera";
        mainCam.AddComponent("Camera");
        mainCam.AddComponent("GUILayer");
        mainCam.AddComponent("FlareLayer");
        mainCam.AddComponent("MouseLook");
        mainCam.GetComponent<Camera>().nearClipPlane = 0.01F;
        mainCam.GetComponent<MouseLook>().axes = MouseLook.RotationAxes.MouseY;
        mainCam.GetComponent<MouseLook>().sensitivityX = 10;
        mainCam.GetComponent<MouseLook>().sensitivityY = 10;
        mainCam.GetComponent<MouseLook>().minimumX = 0;
        mainCam.tag = "MainCamera";

        /*/Robot Arms
        GameObject robo = Instantiate (robotarms,transform.position, transform.rotation) as GameObject;
        robo.name = "Robo_Arm10";
        robo.layer = 8; //Arms Layer
        robo.transform.Rotate (new Vector3 (0, -179.7853F, 0));
        robo.transform.position = new Vector3 (1.08997F, 7.021096F, -12.21104F);
        robo.GetComponent <Animator> ().runtimeAnimatorController = robotanim;	 
        robo.AddComponent ("MeshCollider");
        robo.AddComponent ("WalkingAnimation");
        robo.transform.parent = GameObject.Find ("Main Camera").transform;*/

        //Robot Arms Again
        //GameObject robo = Instantiate (robotarms,transform.position, transform.rotation) as GameObject;
        //robotarms.transform.localRotation = Quaternion.Euler (0, 179.7853F, 0);
        //robotarms.transform.position = new Vector3 (1.08997F, 7.021096F, -12.21104F);
        //robotarms.GetComponent <Animator> ().runtimeAnimatorController = robotanim;	 
        //robotarms.AddComponent ("MeshCollider");
        //robotarms.AddComponent ("WalkingAnimation");


        //First Person Controller
        fpc.AddComponent("MouseLook");
        fpc.AddComponent("CharacterMotor");
        fpc.AddComponent("FPSInputController");
        fpc.AddComponent("codingUI");
        fpc.AddComponent("AudioSource");
        fpc.AddComponent("TortureRoom");
        fpc.AddComponent("RunMaybeCrouch");
        fpc.GetComponent<MouseLook>().axes = MouseLook.RotationAxes.MouseX;
        fpc.GetComponent<MouseLook>().sensitivityX = 5;
        fpc.GetComponent<MouseLook>().sensitivityY = 0;
        fpc.GetComponent<MouseLook>().minimumY = 0;
        fpc.GetComponent<MouseLook>().maximumY = 0;
        fpc.GetComponent<CharacterMotor>().movement.maxForwardSpeed = 15;
        fpc.GetComponent<CharacterMotor>().movement.maxSidewaysSpeed = 15;
        fpc.GetComponent<CharacterMotor>().movement.maxBackwardsSpeed = 15;
        fpc.GetComponent<CharacterMotor>().movement.maxGroundAcceleration = 100;
        fpc.GetComponent<CharacterMotor>().movement.maxAirAcceleration = 15;
        fpc.GetComponent<CharacterMotor>().movement.gravity = 20;
        fpc.GetComponent<CharacterMotor>().jumping.extraHeight = 1;
        fpc.GetComponent<CharacterMotor>().sliding.slidingSpeed = 10;
        fpc.GetComponent<codingUI>().missionComplete = mkExcel;
        fpc.GetComponent<codingUI>().cursorImage = crosshair;
        fpc.GetComponent<TortureRoom>().tortureSound = torture;
        fpc.GetComponent<RunMaybeCrouch>().walk = 15;
        fpc.GetComponent<RunMaybeCrouch>().sprint = 30;

        //Graphics
        graphics.AddComponent("MeshRenderer");
        graphics.GetComponent<MeshRenderer>().castShadows = false;
        graphics.GetComponent<MeshRenderer>().receiveShadows = false;

        //Build the First Person Controller
        armCam.transform.parent = mainCam.transform;
        mainCam.transform.parent = fpc.transform;
        graphics.transform.parent = fpc.transform;

        //Cylinder 1 object
        GameObject cyl1 = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        cyl1.name = "Cylinder";
        cyl1.transform.position = new Vector3(0.3197579F, 39.42297F, 8.588956F);
        cyl1.transform.localRotation = Quaternion.Euler(90, 90, 0);
        cyl1.transform.localScale = new Vector3(0.4F, 5, 0.4F);

        //Point Light
        GameObject pointLight = new GameObject("Point Light");
        pointLight.transform.position = new Vector3(0.01269168F, 37.27597F, 8.988342F);
        pointLight.transform.localRotation = Quaternion.Euler(90, 0, 0);
        pointLight.transform.localScale = new Vector3(1.666667F, 1.333333F, 2);
        pointLight.AddComponent("Light");
        pointLight.GetComponent<Light>().range = 50;
        pointLight.GetComponent<Light>().intensity = 2.94F;
        pointLight.AddComponent("FlickeringLight");
        pointLight.GetComponent<FlickeringLight>().flickeringLightStyle = FlickeringLight.flickerinLightStyles.Fluorescent;
        pointLight.GetComponent<FlickeringLight>().CampfireRangeBaseValue = 12.43F;
        pointLight.GetComponent<FlickeringLight>().CampfireRangeFlickerValue = 1.9F;
        pointLight.GetComponent<FlickeringLight>().CampfireSineCycleIntensitySpeed = 5.19F;
        pointLight.GetComponent<FlickeringLight>().FluorescentFlickerMin = 0.14F;
        pointLight.GetComponent<FlickeringLight>().FluorescentFlickerMax = 0.34F;
        pointLight.GetComponent<FlickeringLight>().FluorescentFlicerPercent = 0.85F;

        //Cylinder 2 object
        GameObject cyl2 = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        cyl2.name = "Cylinder";
        cyl2.transform.position = new Vector3(0.3232401F, 39.42297F, 9.118229F);
        cyl2.transform.localRotation = Quaternion.Euler(90, 90, 0);
        cyl2.transform.localScale = new Vector3(0.4F, 5, 0.4F);

        //Build Light
        pointLight.transform.parent = cyl1.transform;
        cyl2.transform.parent = cyl1.transform;



    }

    // Update is called once per frame
    void Update()
    {

    }
}
