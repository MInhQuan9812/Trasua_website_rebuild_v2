using Microsoft.AspNetCore.Hosting;
using System.Security.Cryptography;
using System.Text;
using trasua_web_mvc.Dtos;

namespace trasua_web_mvc.CommonData
{
    public class CommonFunction
    {
        public static byte[] GetHash(string inputString)
        {
            using (HashAlgorithm algorithm = SHA256.Create())
            {
                return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
            }
        }

        public static string GetHashString(string inputString)
        {
            StringBuilder sb=new StringBuilder();
            foreach(byte b in GetHash(inputString))
            {
                sb.Append(b.ToString("X2"));
            }
            return sb.ToString();
        }

        public static string GetDescriptionFromContent(string inputString)
        {
            throw new NotImplementedException();
        }
        public static IFormFile Convert(string content, string fileName)
        {
            // Chuyển đổi nội dung chuỗi thành mảng byte
            byte[] byteArray = Encoding.UTF8.GetBytes(content);

            // Tạo một bộ nhớ đệm từ mảng byte
            using (MemoryStream memoryStream = new MemoryStream(byteArray))
            {
                // Tạo một đối tượng IFormFile từ bộ nhớ đệm và tên tệp
                IFormFile file = new FormFile(memoryStream, 0, byteArray.Length, "file", fileName);
                return file;
            }
        }

       


    }
}
