using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;
namespace Accounting.Computer.Lib
{
    public delegate void PrintMessage(string str);
    public delegate void ShowError(Exception ex);
    public struct ServiceEquipment
    {

        //public ServiceEquipment(string dbName)
        //{
        //    DBName = dbName;
        //}

        PrintMessage printMessage;
        ShowError showError;

        public void RegisterMessage(PrintMessage printMessage)
        {
            this.printMessage = printMessage;
        }

        public void RegisterError(ShowError showError)
        {
            this.showError = showError;
        }


        public string DBName { get; set; }
        public void AddEquipment(Equipment eq)
        {

            try
            {
                if (string.IsNullOrEmpty(DBName))
                    throw new Exception("Строка подключения к базе данных не должна быть пустой");
                using (LiteDatabase db = new LiteDatabase(DBName))
                {
                    var equipments = db.GetCollection<Equipment>("Equipment");
                    equipments.Insert(eq);
                }
                if (printMessage != null)
                {
                    printMessage.Invoke("Запись добавлена успешно");
                }
            }
            catch (Exception ex)
            {
                if (showError != null)
                {
                    showError.Invoke(ex);
                }

            }
        }

        public void EditEqupment(Equipment eq)
        {

            try
            {
                if (string.IsNullOrEmpty(DBName))
                    throw new Exception("Строка подключения к базе данных не должна быть пустой");
                using (LiteDatabase db = new LiteDatabase(DBName))
                {
                    var equipments = db.GetCollection<Equipment>("Equipment");
                    equipments.Update(eq);
                }
                if (printMessage != null)
                {
                    printMessage.Invoke("Запись изменена успешно");
                }
            }
            catch (Exception ex)
            {
                if (showError != null)
                {
                    showError.Invoke(ex);
                }

            }
        }

        public void DeleteEquipment(int id)
        {

            try
            {
                if (string.IsNullOrEmpty(DBName))
                    throw new Exception("Строка подключения к базе данных не должна быть пустой");
                using (LiteDatabase db = new LiteDatabase(DBName))
                {
                    var equipments = db.GetCollection<Equipment>("Equipment");
                    equipments.Delete(id);
                }
                if (printMessage != null)
                {
                    printMessage.Invoke("Запись удалена успешно");
                }
            }
            catch (Exception ex)
            {
                if (showError != null)
                {
                    showError.Invoke(ex);
                }

            }
        }

        public List<Equipment> SearchEquipmemt(string name)
        {
            List<Equipment> listEquipment = null;
            try
            {
                if (string.IsNullOrEmpty(DBName))
                    throw new Exception("Строка подключения к базе данных не должна быть пустой");
                using (LiteDatabase db = new LiteDatabase(DBName))
                {
                    var equipments = db.GetCollection<Equipment>("Equipment");
                    listEquipment= equipments.Find(x=>x.Name.Equals(name)).ToList();


                }
                return listEquipment;
            }
            catch (Exception ex)
            {
                if (showError != null)
                {
                    showError.Invoke(ex);
                }

                return listEquipment;
            }
        }
    }
}
