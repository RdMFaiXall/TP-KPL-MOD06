using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPMOD06_1302220093
{
    public class SayaTubeVideo_1302220093
    {
        private int id;
        private string title;
        private int playCount;

        public SayaTubeVideo_1302220093(string title)
        {
            // Kode tersebut menggunakan kelas Random untuk menghasilkan angka acak antara 9999 dan 100001,
            // yang kemudian disimpan dalam variabel "id".
            Random acak = new Random();
            id = acak.Next(9999, 100001);

            //  Precondition
            // Memastikan bahwa panjang string title tidak lebih dari 100 karakter dan
            // bahwa title tidak null sebelum mengatur nilainya.
            Debug.Assert(title.Length <= 100 && title != null);
            this.title = title;

            // state awal playCount bernilai 0
            this.playCount = 0;
        }

        public void IncreasePlayCount(int count)
        {
            Contract.Requires(count > 0 && count <= 10000000, "Input penambahan play count maximal 10.000.000 play count");
            Contract.Ensures(playCount <= int.MaxValue - count, "Penambahan play count melebihi maximal.");

            try
            {
                checked
                {
                    playCount += count;
                }
            }
            catch (OverflowException)
            {
                Console.WriteLine("Error: Penambahan play count melebihi batas maksimal, yakni melebihi 10.000.000.");
            }
        }

        // Print detail informasi dari Video
        public void PrintVideoDetails()
        {
            Console.WriteLine($"Video ID: {id}");
            Console.WriteLine($"Title: {title}");
            Console.WriteLine($"Play Count: {playCount}");
        }
    }
}