namespace MFramework.Extensions.WindowsSystem
{
    public class FileExtension
    {
        public const string AllFileFilter = "所有文件(*.*)\0*.*";
        public const string GraphicFileFilter = "图像文件(*.jpg;*.jpeg;*.png;*.bmp;*.tiff;*.gif;*.svg;*.raw;*.webp)\0*.jpg;*.jpeg;*.png;*.bmp;*.tiff;*.gif;*.svg;*.raw;*.webp";
        public const string VideoFileFilter = "视频文件(*.mkv;*.wmv;*.avi;*.mpeg;*.mpg;*.rmvb;*.flv;*.mp4;*.mov)\0*.mkv;*.wmv;*.avi;*.mpeg;*.mpg;*.rmvb;*.flv;*.mp4;*.mov";
        public const string TextFileFilter = "文本文件(*.txt;*.xml;*.json;*.xlsx;*.xls;*.csv;*.ini;*.config)\0*.txt;*.xml;*.json;*.xlsx;*.xls;*.csv;*.ini;*.config";

        public FileExtensionType extensionType;
        public string fileExtensionName;
        public string fileFilter;



        //图像文件拓展名
        public const string JPEG = "*.jpeg";
        public const string JPG = "*.jpg";
        public const string PNG = "*.png";
        public const string BMP = "*.bmp";
        public const string TIFF = "*.tiff";
        public const string GIF = "*.gif";
        public const string SVG = "*.svg";
        public const string RAW = "*.raw";
        public const string WEBP = "*.webp";

        //图像文件过滤器GRAPHIC_FORMATS


        public const string JPGFilter = "JPG文件(*.jpg;*.jpeg)\0*.jpg;*.jpeg";
        public const string PNGFilter = "PNG文件(*.png)\0*.png";
        public const string BMPFilter = "BMP文件(*.bmp)\0*.bmp";
        public const string TIFFFilter = "TIFF文件(*.tiff)\0*.tiff";
        public const string GIFFilter = "GIF文件(*.gif)\0*.gif";
        public const string SVGFilter = "SVG文件(*.svg)\0*.svg";
        public const string RAWFilter = "RAW文件(*.raw)\0*.raw";
        public const string WEBPFilter = "WEBP文件(*wevp)\0*.webp";


        //视频文件拓展名
        public const string MKV = "*.mkv";
        public const string WMV = "*.wmv";
        public const string AVI = "*.avi";
        public const string MPEG = "*.mpeg";
        public const string MPG = "*.mpg";
        public const string RMVB = "*.rmvb";
        public const string FLV = "*.flv";
        public const string MP4 = "*.mp4";
        public const string MOV = "*.mov";


        public const string MKVFilter = "MKV文件(*mkv)\0*.mkv";
        public const string WMVFilter = "WMV文件(*.wmv)\0*.wmv";
        public const string AVIFilter = "AVI文件(*.avi)\0*.avi";
        public const string MPEGFilter = "MPEG文件(*.mpeg)\0*.mpeg";
        public const string MPGFilter = "MPG文件(*.mpg)\0*.mpg";
        public const string RMVBFilter = "RMVB文件(*.rmvb)\0*.rmvb";
        public const string FLVFilter = "FLV文件(*.flv)\0*.flv";
        public const string MP4Filter = "MP4文件(*.mp4)\0*.mp4";
        public const string MOVFilter = "MOV文件(*mov)\0*.mov";

        //文本文件拓展名
        public const string TXT = "*.txt";
        public const string XML = "*.xml";
        public const string JSON = "*.json";
        public const string XLSX = "*.xlsx";
        public const string XLS = "*.xls";
        public const string CSV = "*.csv";
        public const string INI = "*.ini";
        public const string CONFIG = "*.config";


        public const string TXTFilter = "文本文档(*.txt)\0*.txt";
        public const string XMLFilter = "Xml文档(*.xml)\0*.xml";
        public const string JSONFilter = "Json数据文件(*.json)|\0*.json";
        public const string ExcelFilter = "Excel文件(*.xlsx;*.xls)|\0*.xlsx;*.xls";
        public const string CSVFilter = "Csv文件(*.csv)\0*.csv";
        public const string INIFilter = "Ini文件(*.ini)\0*.ini";
        public const string CONFIGFilter = "Config文件(*.config)\0*.config";
    }
}