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
            string text = "����� ��� ���� ������ ����������� �����, �� ����� ���";
            string key = "���������������������������������������������������";
            string expectedResult = "����� ��� ���� ������ ����������� �����, �� ����� ���";

            // act
            string result = VigenereCryptor.Crypt(text, key, CryptorMode.Encrypt);

            // assert
            Assert.AreEqual(expectedResult, result);
        }
        [TestMethod]
        public void Crypt_TextIsPredefined_ReturnsCorrectDecryptedString()
        {
            // arrange
            string text = "����� ��� ���� ������ ����������� �����, �� ����� ���";
            string key = "���������������������������������������������������";
            string expectedResult = "����� ��� ���� ������ ����������� �����, �� ����� ���";

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
            string text = "����� ��� ���� ������ ����������� �����, �� ����� ���";
            string key = "��������� ������ ����� ������� �������� ���� ���� ���� ����"; // �������� � �������� ��� - ������ ����������

            // act
            string result = VigenereCryptor.Crypt(text, key, CryptorMode.Encrypt);

            // assert
            // ��� ����������!!!
        }
    }
}