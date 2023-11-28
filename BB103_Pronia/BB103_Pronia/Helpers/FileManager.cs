using Microsoft.AspNetCore.Http;

namespace BB103_Pronia.Helpers;

public static class FileManager
{

    public static string UploadFile(this IFormFile file,string envPath,string folderName)
    {

        string filname = file.FileName.Length > 64 ? file.FileName.Substring(file.FileName.Length - 64, 64) : file.FileName;

        filname = Guid.NewGuid().ToString() + filname;
        //string path = @"C:\Users\rasul\OneDrive\Masaüstü\BB103_Pronia\BB103_Pronia\wwwroot\UploadImages\SliderImg\" + filname;
        string path = envPath + folderName+filname;


        using (FileStream stream = new FileStream(path, FileMode.Create))
        {
            file.CopyTo(stream);
        }



        return filname;
    }
    public static bool CheckContent(this IFormFile file,string content)
    {
        return file.ContentType.Contains(content);
    }
    public static bool CheckLenght(this IFormFile file, int lenght)
    {
        return file.Length <= lenght;
    }
    public static void RemoveFile(this string filename,string rootEnv,string folder)
    {
        string path = rootEnv+folder+filename;
        if(File.Exists(path))
        {
            File.Delete(path);
        }
    }
}
