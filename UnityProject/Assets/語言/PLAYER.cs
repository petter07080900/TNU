
using UnityEngine;
using UnityEngine.UI;

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
    [Header("音效區域")]
    public AudioSource aud;
    public AudioClip soundDiamond;
    [Header("鑽石區域")]
    public int diamondCurrent;
    public int diamondTotal;
    public Text textDiamond;
    #endregion

    //定義方法
    //語法
    //修飾詞 傳回類型 方法名稱(){}
    //void 無傳回 

    private void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");  // 輸入.取得軸向("水平")左右與AD
        r2d.AddForce(new Vector2(speed * h, 0));
        ani.SetBool("跑步開關", h != 0);        //動畫元件.設定布林值

        //如果按下A或者左右鍵 角度=(0，180，0)

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) transform.eulerAngles = new Vector3(0, 180, 0);
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) transform.eulerAngles = new Vector3(0, 0, 0);

    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround == true)
        {

            isGround = false;   //在地板上=取消
            r2d.AddForce(new Vector2(0, jump)); //鋼體.推力(往上)
            ani.SetTrigger("跳躍觸發");    //動畫元件3設定觸發器("參數")
        }
    }
    private void Dead()
    {

    }

    //事件: 在特定的時間點已指定次數執行
    //更新事件:秒執行約60次 (60FRS)
    private void Start()
    {
        //鑽石總數=尋找所有指定標籤物件("指定標籤").數量
        diamondTotal=GameObject.FindGameObjectsWithTag("鑽石").Length;
        //更新介面
        textDiamond.text="鑽石:0/"+diamondTotal;
    }
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


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "鑽石")
        {  
            aud.PlayOneShot(soundDiamond, 1.5f);
            Destroy(collision.gameObject);
            diamondCurrent ++;
            textDiamond.text = "鑽石:" +diamondCurrent + "/" + diamondTotal;
        }
    }
}
