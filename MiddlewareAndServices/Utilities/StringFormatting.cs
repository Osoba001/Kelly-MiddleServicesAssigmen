namespace MiddlewareAndServices.Utilities
{
    public static class StringFormatting
    {
        public static string formarFileSize(this long size)
        {
            switch (size)
            {
                case <1000: 
                    return string.Format("{0,3}Byte",size);
                case < 1000000:
                    return string.Format("{0,3}KB", (size/1000));
                case < 1000000000:
                    return string.Format("{0,3}MB", (size / 1000000));
                default:
                    throw new Exception("The file is too large");
            }
        }
    }
}
