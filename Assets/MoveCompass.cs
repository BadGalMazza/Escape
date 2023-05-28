/************************************************************
  FileName: Watch.cs
  Author:ĩ��       Version :1.0          Date: 2018-7-19
  Description:�����϶�
************************************************************/

using UnityEngine;

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
     void Update()
    {
        if(isgrag)
        {
            if (!isGet)
            Debug.Log("Mrotatevalue" + pointerM.eulerAngles.z+ "Hrotatevalue" + pointerH.eulerAngles.z);

            if(Mathf.Abs(Mathf.Abs(pointerM.eulerAngles.z)- Mrotatevalue)<10 && Mathf.Abs(Mathf.Abs(pointerH.eulerAngles.z) - Hrotatevalue) < 10 && !isGet)
            {

                isGet = true;
                ValueTrigger();
                Debug.Log(isGet);//do you want do
                numbershow.SetActive(true);

            }
        
            oldVector_M = pointerM.localEulerAngles;

            //ͨ�����λ�þ����Ƕȣ���ΪVector3.Angle�������180��
            if (Input.mousePosition.x >= Screen.width / 2)
            {
                angleM = 360 - Vector3.Angle(new Vector3(0, 1, 0), new Vector3(Input.mousePosition.x - Screen.width / 2, Input.mousePosition.y - Screen.height / 2, 0));
            }
            else
            {
                angleM = Vector3.Angle(new Vector3(0, 1, 0), new Vector3(Input.mousePosition.x - Screen.width / 2, Input.mousePosition.y - Screen.height / 2, 0));
            }

            pointerM.localEulerAngles = new Vector3(0, 0, angleM);

            if (Mathf.Abs(pointerM.localEulerAngles.z - oldVector_M.z) < 180)//�ж��Ƿ񾭹�12
            {
                pointerH.localEulerAngles += new Vector3(0, 0, (pointerM.localEulerAngles.z - oldVector_M.z) / 12);
            }
            else
            {
                if (Input.mousePosition.x > Screen.width / 2)//˳ʱ�뾭��
                {
                    pointerH.localEulerAngles += new Vector3(0, 0, (pointerM.localEulerAngles.z - oldVector_M.z - 360) / 12);
                }
                else//��ʱ�뾭��
                {
                    pointerH.localEulerAngles += new Vector3(0, 0, (pointerM.localEulerAngles.z - oldVector_M.z + 360) / 12);
                }
            }


        
    }
    }

    public void ValueTrigger()
    {
        

    }

    public void DrugEvent()
{
        if(isgetbuttery)
        {
            isgrag = true;
        }
  

}
    public void relased()
    {
        isgrag = false;

    }
}