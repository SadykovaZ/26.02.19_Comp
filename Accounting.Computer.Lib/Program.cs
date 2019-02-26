using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accounting.Computer.Lib;
using Accounting.Computer.Lib.Model.Soft;
namespace Accounting.Computer.Lib
{
    class Program
    {
        static void Main(string[] args)
        {
            Equipment eq = new Equipment();
            eq.Name = "Apple";
            eq.Model = "Apple";
            eq.Price = 3000;
            eq.IssueDate = DateTime.Now;
            eq.Garanty = 3;
            ServiceEquipment sq = new ServiceEquipment();
            sq.RegisterError(PrintMessage);
            sq.DBName = @"\\sd\City\SDP-181\Задание 03";
            sq.RegisterMessage(PrintMessage);
            sq.AddEquipment(eq);

            Software software = new Software();
            software.Price = 100;
            software.typeSoftware = TypeSoftware.free;
            software.InstallDate = DateTime.Now;
            if (sq.SearchEquipmemt("Apple") != null)
                software.equipment = sq.SearchEquipmemt("Apple")[0];

            ServiceSoftware ss = new ServiceSoftware();
            ss.DBName = @"\\sd\City\SDP-181\Задание 03";
            ss.RegisterError(PrintMessage);
            ss.RegisterMessage(PrintMessage);
            ss.AddSoftware(software);

        }

        public static void PrintMessage(string str)
        {
            System.Console.ForegroundColor = System.ConsoleColor.Green;
            System.Console.WriteLine(str);
            System.Console.ForegroundColor = System.ConsoleColor.White;

        }

        public static void PrintMessage(Exception ex)
        {
            System.Console.ForegroundColor = System.ConsoleColor.Red;
            System.Console.WriteLine(ex);
            System.Console.ForegroundColor = System.ConsoleColor.White;

        }

        public static void SendNotification(Software sw)
        {

            System.Console.WriteLine("Уведомление об установке отправлено");


        }
    }
}
