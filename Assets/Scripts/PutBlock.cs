using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PutBlock : MonoBehaviour
{
    public GameObject textObject;
    TextMeshPro scoreMesh;

    public Camera cam;
    public RaycastHit hit;
    public RaycastHit hitShine;
    public float range = 100f;

    int order;
    int place;
    string cubeName0;
    string cubeName1;

    public int line1Count;
    public int line2Count;
    public int line3Count;
    public int line4Count;

    public GameObject[] line1;
    public GameObject[] line2;
    public GameObject[] line3;
    public GameObject[] line4;

    public GameObject[] shelf1;
    public GameObject[] shelf2;
    public GameObject[] shelf3;
    public GameObject[] shelf4;

    int next = 0;
    int t = 0;

    public int score;

    public bool putIsLive = true;

    void Start()
    {
        scoreMesh = textObject.GetComponent<TextMeshPro>();
    }


    void Update()
    {
        if (putIsLive)
        {
            setStats();
            Shine();

            if (Input.GetButtonDown("Fire1"))
            {
                Click();
            }
        }
    }

    void Click()
    {
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            if (hit.transform.tag == "Cubes")
            {
                order = System.Convert.ToInt32(hit.transform.name.Substring(0, 1));
                place = System.Convert.ToInt32(hit.transform.name.Substring(1, 1));

                cubeName0 = hit.transform.name + "0";
                cubeName1 = hit.transform.name.Substring(0, 4);

                if (place == 0)
                {
                    if (order == 1)
                    {
                        line1Count++;
                        foreach (var go in line1)
                        {
                            if (t==0)
                            {
                                if (go.activeSelf==false)
                                {
                                    go.SetActive(true);
                                    t = 1;
                                }
                            }
                        }
                    }

                    else if (order == 2)
                    {
                        line2Count++;
                        foreach (var go in line2)
                        {
                            if (t == 0)
                            {
                                if (go.activeSelf == false)
                                {
                                    go.SetActive(true);
                                    t = 1;
                                }
                            }
                        }
                    }

                    else if (order == 3)
                    {
                        line3Count++;
                        foreach (var go in line3)
                        {
                            if (t == 0)
                            {
                                if (go.activeSelf == false)
                                {
                                    go.SetActive(true);
                                    t = 1;
                                }
                            }
                        }
                    }
                     
                    else if (order == 4)
                    {
                        line4Count++;
                        foreach (var go in line4)
                        {
                            if (t == 0)
                            {
                                if (go.activeSelf == false)
                                {
                                    go.SetActive(true);
                                    t = 1;
                                }
                            }
                        }
                    }
                    else
                    {
                        Debug.Log("Error! order");
                    }

                    t = 0;
                }

                if (place == 1)
                {
                    if (order == 1)
                    {
                        while (next == 0)
                        {
                            if (shelf1[t].activeSelf==false)
                            {
                                shelf1[t].SetActive(true);
                                next = 1;
                            }
                            else
                            {
                                t++;
                            }
                        }
                        line1Count--;
                    }

                    else if (order == 2)
                    {
                        while (next == 0)
                        {
                            if (!shelf2[t].activeSelf)
                            {
                                shelf2[t].SetActive(true);
                                next = 1;
                            }
                            else
                            {
                                t++;
                            }
                        }
                        line2Count--;
                    }

                    else if (order == 3)
                    {
                        while (next == 0)
                        {
                            if (!shelf3[t].activeSelf)
                            {
                                shelf3[t].SetActive(true);
                                next = 1;
                            }
                            else
                            {
                                t++;
                            }
                        }
                        line3Count--;
                    }

                    else if (order == 4)
                    {
                        while (next == 0)
                        {
                            if (!shelf4[t].activeSelf)
                            {
                                shelf4[t].SetActive(true);
                                next = 1;
                            }
                            else
                            {
                                t++;
                            }
                        }
                        line4Count--;
                    }

                    else
                    {
                        Debug.Log("Error! order");
                    }
                    next = 0;
                    t = 0;
                }

                score = (line1Count * 50) + (line2Count * 20) + (line3Count * 10) + (line4Count * 1);
                setStats();

                hit.transform.gameObject.SetActive(false);
            }
        }
    }


    void Shine()
    {
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hitShine, range))
        {
            if (hitShine.transform.tag == "Cubes")
            {
                //
            }
        }
        
    }
    void setStats()
    {
        scoreMesh.text = score.ToString();
    }
}
