
using UnityEngine;

public class PLAYER : MonoBehaviour
{
    [Header("速度"),Range(0f, 100f)]
    public float speed = 3.5f; //浮點數 - 結尾要有F
    [Header("跳躍"),Range(10,100)]
    public int jump = 300;                 // 整數
    [Header("是否在地板上"),Tooltip("用來判定是否在地板上。")]
    public bool isGround = false;                //布林值  true . false
   [Header("姓名")]
    public string name = "slagmale";              //字串 - 需要用雙引號
}
