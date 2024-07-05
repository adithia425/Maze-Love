using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public CinemachineVirtualCamera cinemachine;
    public Camera mainCamera;

    public ObjectPlayer objectPlayer;
    public GameObject objectPlatform;
    public CanvasManager canvasManager;

    private int sizeCameraPlatform = 8;
    private bool isCameraPlayer = true;

    public bool isPlay;
    public float timer;
    private bool isDie;
    private float counterSizeCamera = 1;

    public int speedRotation;

    private bool rotateLeft = false;
    private bool rotateRight = false;


    [Header("Power")]
    [SerializeField]
    private float currentPowerMap;
    private bool isShowMap;
    private bool powerMapDisable;

    [Header("Food")]
    public bool haveFood;
    public bool isBigger;
    private float counterBigger = 3;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        Invoke("StartGame", 1.25f);
    }

    private void StartGame()
    {
        isPlay = true;
    }
    public float GetPowerMap()
    {
        return currentPowerMap;
    }

    public void CameraPlayer()
    {
        isShowMap = false;
        cinemachine.gameObject.SetActive(true);
    }

    public void CameraPlatform()
    {
        if (powerMapDisable) return;

        isShowMap = true;
        cinemachine.gameObject.SetActive(false);
        mainCamera.transform.position = new Vector3(0, 0, -10);
        mainCamera.orthographicSize = sizeCameraPlatform;

    }

    void Update()
    {

        if(isPlay)
        {
            timer += Time.deltaTime;
            canvasManager.SetTimer((int)timer);
        }

        if(isDie)
        {

            if(counterSizeCamera >= 0.25f)
                counterSizeCamera -= Time.deltaTime;

            cinemachine.m_Lens.OrthographicSize = counterSizeCamera;
            return;
        }

        if (isShowMap)
        {
            currentPowerMap -= Time.deltaTime;
            if(currentPowerMap <= 0)
            {
                isShowMap = false;
                powerMapDisable = true;
                CameraPlayer();
            }
        }

        if(isBigger)
        {
            counterBigger -= Time.deltaTime;

            canvasManager.SetInfoBigger(counterBigger);
            canvasManager.SetPanelBigger(true);
            if (counterBigger <= 0)
            {
                counterBigger = 0;
                isBigger = false;
                canvasManager.SetPanelBigger(false);
                objectPlayer.SetNormal();
            }
        }

        if (Input.GetKey(KeyCode.A))
        {
            RotateLeft();
        }

        if (Input.GetKey(KeyCode.D))
        {
            RotateRight();
        }

        if (rotateLeft)
        {
            RotateLeft();
        }

        if (rotateRight)
        {
            RotateRight();
        }
    }

    #region Control
    public void LeftDown()
    {
        rotateLeft = true;
    }

    public void LeftUp()
    {
        rotateLeft = false;
    }

    public void RightDown()
    {
        rotateRight = true;
    }

    public void RightUp()
    {
        rotateRight = false;
    }

    private void RotateLeft()
    {
        objectPlatform.transform.Rotate(0, 0, speedRotation * Time.deltaTime);
    }

    private void RotateRight()
    {
        objectPlatform.transform.Rotate(0, 0, -speedRotation * Time.deltaTime);
    }

    #endregion

    public void GameGoal()
    {
        isPlay = false;
        objectPlayer.rB.isKinematic = true;
        canvasManager.SetPanelGoal(true);
        canvasManager.GameWin((int)timer);
    }
    public void GameDie()
    {
        isPlay = false;
        isDie = true;
        objectPlayer.rB.isKinematic = true;
        objectPlayer.Die();
        //objectPlayer.rB.bodyType = RigidbodyType2D.Static;
        canvasManager.SetPanelDie(true);
    }

    public void PressButtonMap()
    {
        isCameraPlayer = !isCameraPlayer;

        if(isCameraPlayer)
            CameraPlayer();
        else
            CameraPlatform();
    }


    public void ClaimFood()
    {
        counterBigger = 3;
        haveFood = true;
        canvasManager.SetButtonFood(true);
    }
    public void PressButtonFood()
    {
        SoundManager.instance.PlaySFX(SFX.BIGGER);
        haveFood = false;
        isBigger = true;
        objectPlayer.SetBigger();
        canvasManager.SetButtonFood(false);
    }


}
