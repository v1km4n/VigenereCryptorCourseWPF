using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VigenereCryptorCourse
{
    public class VigenereCryptor
    {
        public static string Crypt(string text, string key, CryptorMode mode)
        {
            string result = "";
            string alphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
            int keySymbolIndex = 0; // номер символа в ключе, который используется для шифрования текущего символа текста
            for (int i = 0; i < text.Length; i++)
            {
                int keyIndex = alphabet.IndexOf(key[keySymbolIndex]); // сдвиг по символу ключа
                if (keyIndex == -1)
                {
                    throw new FormatException("В ключе обнаружены символы, не входящие в алфавит, на котором производится шифрование.");
                }
                int textIndex = alphabet.IndexOf(text[i]); // сдвиг по символу текста
                if (textIndex == -1) // если символа в алфавите нет, игнорируем его
                {
                    result += text[i];
                    continue;
                }

                int encryptedIndex; // вычисляем индекс символа алфавита, который пойдёт в результат
                if (mode == CryptorMode.Encrypt)
                {
                    encryptedIndex = (textIndex + keyIndex) % alphabet.Length;
                }
                else
                {
                    encryptedIndex = (textIndex - keyIndex + alphabet.Length) % alphabet.Length; // плюсану ещё длину алфавита, чтобы в минус не улетало
                }

                result += alphabet[encryptedIndex];

                keySymbolIndex++; // обновляем сдвиг по ключу
                if (keySymbolIndex == key.Length)
                {
                    keySymbolIndex -= key.Length;
                }
            }
            return result;
        }
    }
}
