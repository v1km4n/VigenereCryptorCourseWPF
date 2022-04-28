using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;


namespace VigenereCryptorCourse.UnitTests
{
    [TestClass]
    public class VigenereCryptorTests
    {
        [TestMethod]
        public void Crypt_TextIsEmpty_ReturnsEmptyString()
        {
            // arrange
            string key = "abdc";

            // act
            string result = VigenereCryptor.Crypt("", key, CryptorMode.Encrypt);

            // assert
            Assert.AreEqual("", result);
        }
        [TestMethod]
        public void Crypt_TextIsPredefined_ReturnsCorrectEncryptedString()
        {
            // arrange
            string text = "съешь ещЄ этих м€гких французских булок, да выпей чаю";
            string key = "рандомныйключикчтобытекстикпомешалотудасюдатудасюда";
            string expectedResult = "вътьк сжб жэфу дзнвыд хлттбеъъхшд ншдоц, тт х€пцз ыар";

            // act
            string result = VigenereCryptor.Crypt(text, key, CryptorMode.Encrypt);

            // assert
            Assert.AreEqual(expectedResult, result);
        }
        [TestMethod]
        public void Crypt_TextIsPredefined_ReturnsCorrectDecryptedString()
        {
            // arrange
            string text = "съешь ещЄ этих м€гких французских булок, да выпей чаю";
            string key = "рандомныйключикчтобытекстикпомешалотудасюдатудасюда";
            string expectedResult = "бъчфн шлк узэч хцшуцж ухнилвхиащж фоуо€, хн очпул уал";

            // act
            string result = VigenereCryptor.Crypt(text, key, CryptorMode.Decrypt);

            // assert
            Assert.AreEqual(expectedResult, result);
        }
        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void Crypt_KeyContainsCharsNotFromAlphabet_ThrowAnException()
        {
            // arrange
            string text = "съешь ещЄ этих м€гких французских булок, да выпей чаю";
            string key = "рандомный ключик чтобы текстик помешало туда сюда туда сюда"; // пробелов в алфавите нет - кидаем исключение

            // act
            string result = VigenereCryptor.Crypt(text, key, CryptorMode.Encrypt);

            // assert
            // ждЄм исключени€!!!
        }
    }
}