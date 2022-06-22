using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PengelolaSoal : MonoBehaviour
{
    public TextAsset AssetSoal;

    private string[] soal;

    private string [,] soalBag;

    int indexSoal;
    int maxSoal;
    bool ambilSoal;
    char kunciJ;

    // Komponent UI
    public Text txtSoal, txtOpsiA,txtOpsiB,txtOpsiC,txtOpsiD;

    bool isHasil;
    private float durasi;
    public float durasiPenilaian;


    // Start is called before the first frame update
    void Start()
    {
        durasi = durasiPenilaian;
        //Memanggil soal
        soal = AssetSoal.ToString().Split('#');

        soalBag =new string[soal.Length,6 ];
        maxSoal = soal.Length;
        OlahSoal();

        ambilSoal = true;
        TampilkanSoal();

        print(soalBag[1, 3]);
    }
    
    private void OlahSoal()
    {
        for(int i=0; i<soal.Length; i++)
        {
            string[] tempSoal = soal[i].Split('+');
            for(int j=0; j<tempSoal.Length;j++)
            {
                soalBag[i, j]= tempSoal[j];
                continue;
            }
            continue;
        }
    }

    private void TampilkanSoal()
    {
        if (ambilSoal)
        {
            txtSoal.text = soalBag[indexSoal, 0];
            txtOpsiA.text = soalBag[indexSoal, 1];
            txtOpsiB.text = soalBag[indexSoal, 2];
            txtOpsiC.text = soalBag[indexSoal, 3];
            txtOpsiD.text = soalBag[indexSoal, 4];
            kunciJ = soalBag[indexSoal, 5][0];

            ambilSoal = false;
        }
    }

    public GameObject panel;
    int counter;
    public void hidepanel()
    {
        counter++;
        if(counter % 2 == 1)
        {
            panel.gameObject.SetActive(false);
        }
        else
        {
            panel.gameObject.SetActive(true);
        }
    }
    
    
    public void Opsi(string opsiHuruf)
    {
        CheckJawaban(opsiHuruf[0]);

        if(isHasil)
        {
            //Do Not
        }
        else
        {
            panel.SetActive(true);

        }
       

        // ganti soal
        indexSoal++;
        ambilSoal=true;
        TampilkanSoal();
    }

    public Text txtPenilaian;

    // cek jawaban benar
    private void CheckJawaban (char huruf)
    {
        string penilaian;

        if(huruf.Equals(kunciJ))
        {
            penilaian = "Benar!";
        }
        else
        {
            penilaian = "Salah!";
        }
        txtPenilaian.text = penilaian;
    }
    

    // Update is called once per frame
    void Update()
    {
        if(panel.activeSelf)
        {
            durasiPenilaian -= Time.deltaTime;
            
            if (durasiPenilaian <= 0)
            {
                panel.SetActive(false);
                durasiPenilaian = durasi;

                TampilkanSoal();
            }
        }
        
    }

}
