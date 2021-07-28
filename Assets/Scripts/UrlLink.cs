using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UrlLink : MonoBehaviour
    
{
    public AudioSource trailer;

  
   
        public void OpenURL1()
        {
            Application.OpenURL("http://www.ienstad.se/podcast/frank-hjarta-ella/");
            Debug.Log("is this working?");
       // trailer.Stop();

        }

    public void OpenURL2()
    {
        Application.OpenURL("http://www.ienstad.se/podcast/dromflickan/");
        Debug.Log("is this working?");
       // trailer.Stop();
    }


    public void OpenURL3()
    {
        Application.OpenURL("http://www.ienstad.se/podcast/operation-karleken-feat-sarah-riedel/");
        Debug.Log("is this working?");
       // trailer.Stop();
    }

    public void OpenURL4()
    {
        Application.OpenURL("http://www.ienstad.se/podcast/lisa-larsson/");
        Debug.Log("is this working?");
       // trailer.Stop();
    }

    public void OpenURL5()
    {
        Application.OpenURL("http://www.ienstad.se/podcast/trott-hangig/");
        Debug.Log("is this working?");
       // trailer.Stop();
    }

    public void OpenURL6()
    {
        Application.OpenURL("http://www.ienstad.se/podcast/hemvagen/");
        Debug.Log("is this working?");
      //  trailer.Stop();
    }

    public void OpenUR7()
    {
        Application.OpenURL("http://www.ienstad.se/podcast/resan-till-mamma/");
        Debug.Log("is this working?");
      //  trailer.Stop();
    }

    public void OpenURL8()
    {
        Application.OpenURL("http://www.ienstad.se/podcast/leka-tre/");
        Debug.Log("is this working?");
      //  trailer.Stop();
    }

}