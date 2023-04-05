using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hyperlinks : MonoBehaviour
{
    void Start()
    {
    
    }
    
    public void OpenURL(string link)
    {
      Application.OpenURL(link);

      // Github - https://github.com/WebTreeHI
      // LinkedIn - https://www.linkedin.com/company/web-tree-hi/
      // Twitter - https://twitter.com/WebTreeHI
    }
}
