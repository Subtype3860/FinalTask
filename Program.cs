using System.Runtime.Serialization.Formatters.Binary;
using System;
using System.Text;

namespace FinalTask
{
    class Program
    {
        private const string SettingsFileName = "Students.dat";

        //Obsolete – позволяет пометить элемент программы как устаревший.
        [Obsolete("Obsolete")]
        public static async Task Main()
        {
            var ds = Deserialize(SettingsFileName);
            await CreateGroupStudent(ds);
        }
        /// <summary>
        /// Чтение бинарногофайла Students.dat
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        /// <returns>Десериализация файла в массив</returns>
        [Obsolete("Obsolete")]
        private static Student[] Deserialize(string path)
        {
            Student[]? student;
            var formatter = new BinaryFormatter();
            using var fs = new FileStream(path, FileMode.OpenOrCreate);
            //Deserialize является устаревшей и больше не поддерживается в новых версиях NET начиная с версии 7.0
            student = (Student[])formatter.Deserialize(fs);
            return student;
        }
        /// <summary>
        /// Создание папки с файлами групп студентов
        /// </summary>
        /// <param name="students">Массив классов Student</param>
        [Obsolete("Obsolete")]
        private static async Task CreateGroupStudent(Student[] students)
        {
            var pathDesktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var path = $"{pathDesktop}/Students";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            foreach (var student in students)
            {
                var pathFile = Path.Combine(path, $"{student.Group}.txt");
                await using var streamWriter = new StreamWriter(pathFile, File.Exists(pathFile));
                await streamWriter.WriteLineAsync($"{student.Name}, {student.DateOfBirth:dd.MM.yyyy}");
            }
        }
    }
}

