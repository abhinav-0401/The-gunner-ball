using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class POPUPtextGenerator : MonoBehaviour
{   
    
    // Vector3 randompos;
    
    
    public static void POPuptext(string text, GameObject hitObject, GameObject indicator){
        indicator.GetComponent<TMP_Text>().text = text;
        
        
        
        Vector3 pop_up_text_position = hitObject.transform.position + new Vector3(0.0f,1.2f,0.0f);
        Debug.Log(hitObject.transform.position);
        
        GameObject pop_up_text = Instantiate(indicator, pop_up_text_position, Quaternion.identity);
        Vector3 move_up_position = pop_up_text_position + new Vector3(0.0f,3.0f,0.0f);
        
        
        Debug.Log("text position"+pop_up_text.transform.position);
        Destroy(pop_up_text, 2f);
    }
}
