using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bb103_weapon_tasks
{
    public class Weapon
    {
        public int MagazineCapacity { get; set; }
        public int Bullets { get; set; }
        public string FireMode { get; set; }
        public Weapon(int magazineCapacity, int bulletsInMagazine)
        {
            MagazineCapacity = magazineCapacity;
            Bullets = bulletsInMagazine;
            FireMode = "Single";
        }


        public void Shoot()
        {
            if(Bullets>0)
            {
                if (FireMode == "Single")
                {
                    Bullets--;
                    Console.WriteLine("!Bang");
                }
                else
                {
                    //Bullets = 0;//bu sekildede olar
                    while (Bullets > 0)
                    {
                        Bullets--;
                        Console.WriteLine("!Bang");
                    }

                }
            }
            else
            {
                Console.WriteLine("Zehmet olmasa daragi doldurun");
            }
          
        }
        public void GetRemainBulletCount()
        {
            Console.WriteLine($"Daragin tam dolmasi ucun lazim olan gulle miqdari{MagazineCapacity-Bullets}");
        }
        public void Reload()
        {
            if(Bullets!=MagazineCapacity)
            {
                Bullets = MagazineCapacity;
                Console.WriteLine("Darag tam doldu");
            }
            else
            {
                Console.WriteLine("Darag zaten doludur");
            }
           
        }
        public void ChangeFireMode()
        {
            if(FireMode=="Single")
            {
                FireMode = "Avtomatic";
            }
            else
            {
                FireMode = "Single";
            }
            Console.WriteLine($"Atis modu deyisdir hal hazirki mod {FireMode}");

        }







    }
}
