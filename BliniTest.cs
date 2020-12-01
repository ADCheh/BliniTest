using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BliniTest : MonoBehaviour
{
    public GameObject[] firstArray;
    public GameObject[] secondArray;

    private void Start()
    {
        BliniTestMethod(firstArray, secondArray);
    }
    void BliniTestMethod(GameObject[] firstArray, GameObject[] secondArray)
    {
        var firstArrayNull = new List<int>(); //Список пустых мест в первом массиве
        var secondArrayElements = new List<int>(); //Список элементов из второго массива, которые еще не использованы

        for(int i = 0; i < firstArray.Length; i++) //Заполнение первого списка
        {
            if (firstArray[i] == null)
                firstArrayNull.Add(i);
        }

        for (int i = 0; i < secondArray.Length; i++) //Заполнение второго списка
        {
            secondArrayElements.Add(i);
        }

        while (firstArrayNull.Count != 0 && secondArrayElements.Count != 0)
        {
            Debug.Log(firstArrayNull.Count+"   "+ secondArrayElements.Count);
            var rndFirst = Random.Range(0, firstArrayNull.Count - 1); //Выбор случайного пустого места в первом массиве
            var rndSecond = Random.Range(0, secondArrayElements.Count - 1); // Выбор случайного элеммента из второго массива

            firstArray[firstArrayNull[rndFirst]] = secondArray[secondArrayElements[rndSecond]]; //Заполнение пустого места в первом массиве элементом из второго

            firstArrayNull.RemoveAt(rndFirst); //Вытаскиваем из списка пустых мест запись о заполненном элементе
            secondArrayElements.RemoveAt(rndSecond); //Добавляем во второй список информацию о использованном элементе второго массива 
        }
        Debug.Log("OK");
        
    }
}
