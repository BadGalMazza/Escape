/************************************************************
  FileName: Watch.cs
  Author:ĩ��       Version :1.0          Date: 2018-7-19
  Description:�����϶�
************************************************************/

using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveCompass : MonoBehaviour
{
    public GameObject numbershow;
    public float speed;
    public Transform pointerM;
    public Transform pointerH;


    private float angleM;
    private Vector3 oldVector_M;

    public float Mrotatevalue = 100;
    public float Hrotatevalue = 200;

    public bool isgrag = false;
    public bool isgetbuttery = false;
    bool isGet = false;

    public AudioClip successSound;
    private AudioSource audioSource;


    private void Start()
    {
        // ???????????????
        audioSource = GetComponent<AudioSource>();
        SceneManager.sceneLoaded += OnSceneLoaded;
     
    }

    private void OnDestroy()
    {
        // ????????
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // ???????? numbershow ????
        if (isGet)
        {
            numbershow.SetActive(true);
        }
    }

    void Update()
    {
        if (isgrag)
        {
            if (!isGet)
                Debug.Log("Mrotatevalue" + pointerM.eulerAngles.z + "Hrotatevalue" + pointerH.eulerAngles.z);

            if (Mathf.Abs(Mathf.Abs(pointerM.eulerAngles.z) - Mrotatevalue) < 10 && Mathf.Abs(Mathf.Abs(pointerH.eulerAngles.z) - Hrotatevalue) < 10 && !isGet)
            {
                isGet = true;
                ValueTrigger();
                Debug.Log(isGet);
                numbershow.SetActive(true);
                audioSource.PlayOneShot(successSound);

            }

            oldVector_M = pointerM.localEulerAngles;

            if (Input.mousePosition.x >= Screen.width / 2)
            {
                angleM = 360 - Vector3.Angle(new Vector3(0, 1, 0), new Vector3(Input.mousePosition.x - Screen.width / 2, Input.mousePosition.y - Screen.height / 2, 0));
            }
            else
            {
                angleM = Vector3.Angle(new Vector3(0, 1, 0), new Vector3(Input.mousePosition.x - Screen.width / 2, Input.mousePosition.y - Screen.height / 2, 0));
            }

            pointerM.localEulerAngles = new Vector3(0, 0, angleM);

            if (Mathf.Abs(pointerM.localEulerAngles.z - oldVector_M.z) < 180)
            {
                pointerH.localEulerAngles += new Vector3(0, 0, (pointerM.localEulerAngles.z - oldVector_M.z) / 12);
            }
            else
            {
                if (Input.mousePosition.x > Screen.width / 2)
                {
                    pointerH.localEulerAngles += new Vector3(0, 0, (pointerM.localEulerAngles.z - oldVector_M.z - 360) / 12);
                }
                else
                {
                    pointerH.localEulerAngles += new Vector3(0, 0, (pointerM.localEulerAngles.z - oldVector_M.z + 360) / 12);
                }
            }
        }
    }

    public void ValueTrigger()
    {
        // ?????????

    }

    public void DrugEvent()
    {
        if (isgetbuttery)
        {
            isgrag = true;
        }
    }

    public void relased()
    {
        isgrag = false;
    }
}