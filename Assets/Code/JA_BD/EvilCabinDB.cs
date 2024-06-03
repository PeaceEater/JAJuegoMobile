using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using System.IO;
using Mono.Data.Sqlite;
using UnityEngine.UI;
using System;

public class EvilCabinDB : MonoBehaviour
{
    string rutaDB;
    string strConexion;
    string DBFileName = "chinook.db";

    IDbConnection dbConnection;
    IDbCommand dbCommand;
    IDataReader reader;

    public int puntuacion;
    public Text text;

    void Start()
    {
        AbrirDB();
        CrearTablaEvilCabin(); // Puedes cambiar este valor por la puntuación que desees
        LeerPuntuacion();
        CerrarDB();

        text.text = puntuacion.ToString();
    }

    void AbrirDB()
    {
        if (Application.platform == RuntimePlatform.WindowsEditor)
        {
            rutaDB = Application.dataPath + "/StreamingAssets/" + DBFileName;
        }
        else if (Application.platform == RuntimePlatform.Android)
        {
            rutaDB = Application.persistentDataPath + "/" + DBFileName;
            if (!File.Exists(rutaDB))
            {
                WWW loadDB = new WWW("jar:file://" + Application.dataPath + DBFileName);
                while (!loadDB.isDone) { }
                File.WriteAllBytes(rutaDB, loadDB.bytes);
            }
        }

        strConexion = "URI=file:" + rutaDB;
        dbConnection = new SqliteConnection(strConexion);
        dbConnection.Open();
    }

    void CerrarDB()
    {
        if (reader != null && !reader.IsClosed) reader.Close();
        if (dbCommand != null) dbCommand.Dispose();
        if (dbConnection != null) dbConnection.Close();
    }

    void CrearTablaEvilCabin()
    {
        dbCommand = dbConnection.CreateCommand();
        string sqlQuery = "CREATE TABLE IF NOT EXISTS EvilCabin (puntuacion INTEGER)";
        dbCommand.CommandText = sqlQuery;
        dbCommand.ExecuteNonQuery();
    }

    void InsertarPuntuacion(int puntuacion)
    {
        AbrirDB();
        dbCommand = dbConnection.CreateCommand();
        string sqlQuery = String.Format("INSERT INTO EvilCabin (puntuacion) VALUES ({0})", puntuacion);
        dbCommand.CommandText = sqlQuery;
        dbCommand.ExecuteNonQuery();
        CerrarDB();
    }

    void LeerPuntuacion()
    {
        AbrirDB();
        dbCommand = dbConnection.CreateCommand();
        string sqlQuery = "SELECT puntuacion FROM EvilCabin";
        dbCommand.CommandText = sqlQuery;

        reader = dbCommand.ExecuteReader();
        while (reader.Read())
        {
            puntuacion = reader.GetInt32(0);
            Debug.Log("Puntuacion: " + puntuacion);
        }
        CerrarDB();
    }

    public void GenerateRandom(){
        puntuacion = UnityEngine.Random.Range(1, 100);
        text.text = puntuacion.ToString();
        InsertarPuntuacion(puntuacion);
    }
}
