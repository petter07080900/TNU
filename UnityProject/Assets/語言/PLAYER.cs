
using UnityEngine;

public class PLAYER : MonoBehaviour
{
    #region 欄位區域
    [Header("速度"), Range(0f, 100f)]
    public float speed = 3.5f; //浮點數 - 結尾要有F
    [Header("跳躍"), Range(150, 300)]
    public int jump = 300;                 // 整數
    [Header("是否在地板上"), Tooltip("用來判定是否在地板上。")]
    public bool isGround = false;                //布林值  true . false
    [Header("姓名")]
    public string name = "slagmale";              //字串 - 需要用雙引號
    [Header("元件")]
    public Rigidbody2D r2d;
    public Animator ani;
    #endregion

     //定義方法
     //語法
     //修飾詞 傳回類型 方法名稱(){}
     //void 無傳回 

     private void Move()
    {
        float h =Input.GetAxisRaw("Horizontal");  // 輸入.取得軸向("水平")左右與AD
        r2d.AddForce(new Vector2( speed * h, 0));
        ani.SetBool("跑步開關", h != 0);
    }
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space)&& isGround==true)
        {
            //在地板上=取消
            isGround = false;
            //鋼體.推力(往上)
            r2d.AddForce(new Vector2(0, jump));
        }
    }
    private void Dead()
    {

    }

    //事件: 在特定的時間點已指定次數執行
    //更新事件:秒執行約60次 (60FRS)
    private void Update()
    {
        Move();
        Jump();
    }    

    //碰撞事件:2D 物件碰撞時執行一次
    //collision 嵾數 : 碰到物件的資訊
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "地板")
        {
            isGround = true;
        }
    }
}
