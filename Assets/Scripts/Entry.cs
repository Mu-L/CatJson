﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CatJson;
using UnityEngine.Profiling;
using LitJson;
using Newtonsoft.Json;

public class Entry : MonoBehaviour
{
    public TextAsset json1;
    public TextAsset json2;
    public TextAsset json3;
    public TextAsset json4;

    private string json1Text;
    private string json2Text;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 30;

        json1Text = json1.text;
        json2Text = json2.text;

        //Test2();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            TestDeserializeJsonObject();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            TestDeserializeJsonObject2();
        }
    }

    private void Test()
    {
        JsonObject obj = JsonParser.ParseJson(json4.text);
        Debug.Log(obj);

        //Debug.Log(obj["array"]);
        //Debug.Log(obj["type"]);
        //Debug.Log(obj["null"]);
        //Debug.Log(obj["number"]);
        //Debug.Log(obj["object"]);
        //Debug.Log(obj["string"]);

    }

    private void Test2()
    {
        Json1_Root result1 = JsonParser.ParseJson<Json1_Root>(json1.text);
        Debug.Log(result1);

        Json2_Root result2 = JsonParser.ParseJson<Json2_Root>(json2.text,false);
        Debug.Log(result2);

        Json3_Root result3 = JsonParser.ParseJson<Json3_Root>(json3.text);
        Debug.Log(result3);
    }

    /// <summary>
    /// 测试反序列化json数据对象，统一基于反射
    /// </summary>
    private void TestDeserializeJsonObject()
    {
        Profiler.BeginSample("Cat Json");
        for (int i = 0; i < 1000; i++)
        {
            Json2_Root result2 = JsonParser.ParseJson<Json2_Root>(json2Text);
        }
        Profiler.EndSample();

        Profiler.BeginSample("Lit Json");
        for (int i = 0; i < 1000; i++)
        {
            Json2_Root result2 = JsonMapper.ToObject<Json2_Root>(json2Text);
        }
        Profiler.EndSample();


        Profiler.BeginSample("Newtonsoft Json");
        for (int i = 0; i < 1000; i++)
        {
            Json2_Root result2 = JsonConvert.DeserializeObject<Json2_Root>(json2Text);
        }
        Profiler.EndSample();
    }

    /// <summary>
    /// 测试反序列化json数据对象，CatJson基于预生成代码，其他库基于反射
    /// </summary>
    private void TestDeserializeJsonObject2()
    {
        Profiler.BeginSample("Cat Json");
        for (int i = 0; i < 1000; i++)
        {
            Json2_Root result2 = JsonParser.ParseJson<Json2_Root>(json2Text,false);
        }
        Profiler.EndSample();

        Profiler.BeginSample("Lit Json");
        for (int i = 0; i < 1000; i++)
        {
            Json2_Root result2 = JsonMapper.ToObject<Json2_Root>(json2Text);
        }
        Profiler.EndSample();


        Profiler.BeginSample("Newtonsoft Json");
        for (int i = 0; i < 1000; i++)
        {
            Json2_Root result2 = JsonConvert.DeserializeObject<Json2_Root>(json2Text);
        }
        Profiler.EndSample();
    }

}
