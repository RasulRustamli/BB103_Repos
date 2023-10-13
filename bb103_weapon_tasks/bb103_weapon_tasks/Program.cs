using System;

namespace bb103_weapon_tasks
{


    class Program
    {
        static void Main()
        {
            Weapon weapon = new Weapon(40, 25);
            bool check = true;
            do
            {
                Console.WriteLine("-0 Informasiya almaq ucun");
                Console.WriteLine("-1 Ates acmaq ucun");
                Console.WriteLine("-2 Daragin dolmasi ucun lazim olan gulle miqdari");
                Console.WriteLine("-3 Daragi deyismek");
                Console.WriteLine("-4 Atis modunu deyismek");
                Console.WriteLine("-5 Exit");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "0":
                        Console.WriteLine($"silah daraginin tutumu {weapon.MagazineCapacity} hal hazirki gulle sayi {weapon.Bullets} hal ahzirki ates modu {weapon.FireMode}");
                        break;
                    case "1":
                        weapon.Shoot();
                        break;
                    case "2":
                        weapon.GetRemainBulletCount();
                        break;
                    case "3":
                        weapon.Reload();
                        break;
                    case "4":
                        weapon.ChangeFireMode();
                        break;
                    case "5":
                        check = false;
                        break;
                }

            } while (check);


        }
    }
}
