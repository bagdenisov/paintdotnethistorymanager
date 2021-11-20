using Microsoft.Win32;
using System.Windows.Forms;

namespace paintdotnetHistoryManager
{
    class RegistryWork
    {
        public static string[,] GetList() { // получаем список из реестра
            RegistryKey Reg = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Paint.NET");
            string[,] list = new string[10, 2];
            if (Reg == null) {
                MessageBox.Show("Директория Paint.NET в реестре не найдена! Возможны ошибки в работе программы", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            for (int i = 0; i < 10; i++) {
                for (int ii = 0; ii !=2 ; ii++) {
                    list[i, ii] = Reg == null ? "" : Reg.GetValue($"File/MostRecent/{(ii == 1 ? "Thumbnail" : "Path")}{i}").ToString();
                }
            }
            if (Reg != null) {Reg.Close();}
            return list;
        }

        public static string[,] Sort(string[,] listin, bool[] info) { // сортируем по порядку и убираем лишнее
            // info - информация о том, какие элементы удалить, а какие оставить. true - удалить
            string[,] listout = new string[10, 2];
            int curr = 0; // служит для определения порядка записи
            for (int i = 0; i < 10; i++)
            {
                if (!info[i]) { // значит, что если мы не отмечаем, что это надо удалить, то мы копируем элемент
                    for (byte i1 = 0; i1 != 2; i1++) {
                        listout[curr, i1] = listin[i, i1];
                    }
                    curr++;
                }
            }
            while (curr < 10)
            { // нужно забить остальные элементы пустыми строками
                for (byte i1 = 0; i1 != 2; i1++)
                {
                    listout[curr, i1] = "";
                }
                curr++;
            }
            return listout;
        }

        public static void Write(string[,] list) // пишем
        {
            RegistryKey Reg = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Paint.NET"); //не спрашивайте почему тут именно Create
            for (int i = 0; i < 10; i++)
            {
                for (int ii = 0; ii != 2; ii++)
                {
                    Reg.SetValue($"File/MostRecent/{ (ii == 1 ? "Thumbnail" : "Path") }{i}", list[i, ii]);
                }
            }
            Reg.Close();
        }
    }
}
