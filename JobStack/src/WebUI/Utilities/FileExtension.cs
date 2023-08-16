namespace JobStack.WebUI.Utilities
{
    public static class FileExtension
    {
        public static string RootPath = "";

        public static void UpdateSaveFile(this IFormFile file, string path)
        {
            path = Path.Combine(RootPath, path);
            using (var writer = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(writer);
            }
        }
        public static string CutFileName(this IFormFile file, int maxSize = 60)
        {
            if (file.FileName.Length > maxSize)
            {
                return file.FileName.Substring(file.FileName.Length - maxSize);
            }
            return file.FileName;
        }
        public static bool CheckSize(this IFormFile file, int kb)
        {
            if (file.Length / 1024 > kb) return true;
            return false;
        }
        public static bool CheckType(this IFormFile file, string type)
        {
            if (file.ContentType.Contains(type)) return true;
            return false;
        }
        public static string SaveFile(this IFormFile file, string savePath)
        {
            string fileName = Guid.NewGuid().ToString() + file.FileName;
            string path = Path.Combine(savePath, fileName);
            using (FileStream fileStream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
            string rootFolder = @"wwwroot\";
            string returnPath = path.Substring(path.IndexOf(rootFolder, StringComparison.OrdinalIgnoreCase) + rootFolder.Length).Replace("\\", "/");
            return fileName;
        }
    }
}
