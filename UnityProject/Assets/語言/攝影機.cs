using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 攝影機 : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("跟隨目標")]
    public Transform target;
    [Header("跟隨速度"), Range(0f, 100f)]
    public float speed = 1.5f;
    /// <summary>
    /// 跟隨目標功能
    /// </summary>>
    private void Track()
    { 
        float limitY = Mathf.Clamp(target.position.y, 0.5f, 1f);
    
        Vector3 targetPos = new Vector3(target.position.x, limitY, -10);
        //攝影機.座標= 三維向量.插值(攝影機.座標.目標.座標，百分比)
        transform.position = Vector3.Lerp(transform.position, targetPos, 0.3f * speed * Time.deltaTime);
    }
    //在Update 執行後才執行 LateUpdate，適用於跟隨
    private void LateUpdate()
    {
        Track();
    }

}
