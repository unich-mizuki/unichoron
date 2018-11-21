using System.Collections;
using UnityEngine;

public class CursorManageScript : MonoBehaviour {
    private bool isTransparent = false;
    private Color appearColor = new Color(0.5F, 0.9F, 0.9F, 1F);
    private Color disappearColor = new Color(0.5F, 0.9F, 0.9F, 0F);

    void Update()
    {
        //カメラからマウスがある場所に向かってRayを発射
        RaycastHit hit;
        //layer8と9の"Player"と"Attack"には当たらないためのマスク
        int layerMask = ~(1 << 9 | 1 << 10 | 1 << 11);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            if (!isTransparent) {
                if (GetComponent<Renderer>().material.HasProperty("_Color")) {
                    GetComponent<Renderer>().material.SetColor("_Color", appearColor);
                }
            } else {
                isTransparent = false;
            }
            //Rayが当たった所にカーソルを移動させる
            transform.position = hit.point;
        } else {
            if (isTransparent) {
                if (GetComponent<Renderer>().material.HasProperty("_Color")) {
                    GetComponent<Renderer>().material.SetColor("_Color", disappearColor);
                }
            } else {
                isTransparent = true;
            }
        }

    }
}
