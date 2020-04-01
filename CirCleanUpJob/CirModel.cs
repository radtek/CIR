using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CirCleanUpJob
{
    class CirModel
    {
        public dynamic data { get; set; }
        public dynamic schema { get; set; }
        public List<CirImageReferences> imageReferences { get; set; }
        public string createdBy { get; set; }
        public int cirId { get; set; }
        public string id { get; set; }
        public int processed { get; set; }
    }

    public class CirImageReferences
    {
        public string imageId { get; set; }
        public string blobGuid { get; set; }
        public string cirId { get; set; }
        public string templateId { get; set; }
        public string url { get; set; }
        public string binaryDataUrl { get; set; }
        public string binaryData { get; set; }
        public string contentType { get; set; }
        public string binaryContentType { get; set; }
    }

    public class ImagecomponentKey
    {
        public bool withPlatePicture { get; set; }
        public string reason { get; set; }
        public Sections sections { get; set; }
        public Plate plate { get; set; }
        public List<UploadedImagesCache> uploadedImagesCache { get; set; }
    }

    public class Plate
    {
        public FileInfo fileInfo { get; set; }
        public string imageId { get; set; }
    }

    public class UploadedImagesCache
    {
        public string imageId { get; set; }
        public string damageType { get; set; }
        public bool damageIdentified { get; set; }
    }

    public class Sections
    {
        public Section1 section1 { get; set; }
        public Section2 section2 { get; set; }
        public Section3 section3 { get; set; }
        public Section4 section4 { get; set; }
        public Section5 section5 { get; set; }
        public Section6 section6 { get; set; }
        public Section7 section7 { get; set; }
        public Section8 section8 { get; set; }
        public Section9 section9 { get; set; }
        public Section10 section10 { get; set; }
        public Section11 section11 { get; set; }
        public Section12 section12 { get; set; }
    }

    public class Section1
    {
        public List<Images> images { get; set; }
    }
    public class Section2
    {
        public List<Images> images { get; set; }
    }
    public class Section3
    {
        public List<Images> images { get; set; }
    }
    public class Section4
    {
        public List<Images> images { get; set; }
    }
    public class Section5
    {
        public List<Images> images { get; set; }
    }
    public class Section6
    {
        public List<Images> images { get; set; }
    }
    public class Section7
    {
        public List<Images> images { get; set; }
    }
    public class Section8
    {
        public List<Images> images { get; set; }
    }
    public class Section9
    {
        public List<Images> images { get; set; }
    }
    public class Section10
    {
        public List<Images> images { get; set; }
    }
    public class Section11
    {
        public List<Images> images { get; set; }
    }
    public class Section12
    {
        public List<Images> images { get; set; }
    }
    public class Images
    {
        public FileInfo fileInfo { get; set; }
        public string imageId { get; set; }
        public string damagePlacement { get; set; }
        public string radius { get; set; }
        public string damageDescription { get; set; }
        public int number { get; set; }
        public string side { get; set; }
        public bool damageIdentified { get; set; }
        public int damageSeverity { get; set; }
        public System.Guid FormIOImageGUID { get; set; }
    }

    public class ImageInfo
    {
        public string description { get; set; }
        public string imageId { get; set; }
        public FileInfo fileInfo { get; set; }
    }

    public class FileInfo
    {
        public string name { get; set; }
    }
}
