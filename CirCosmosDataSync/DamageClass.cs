using Cir.Data.Access.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CirCosmosDataSync
{
    public class DamageClass
    {
        public int value { get; set; }
        public string label { get; set; }
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

    public class Brand
    {
        public string name { get; set; }
    }

    public class CirData
    {        
        public dynamic data { get; set; }
        public dynamic schema { get; set; }
        public CirState state { get; set; }
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
        public List<damageDetail> damageDetails { get; set; }
        public System.Guid FormIOImageGUID { get; set; }
        public List<Observation> observations { get; set; }
    }
    public class damageDetail
    {
        public string damageId { get; set; }
        public Guid damageGuid { get; set; }
    }
    public class Observation
    {
        public string findingType { get; set; }
    }

    public class DynamicFields
    {
        public string A1 { get; set; }
        public string A2 { get; set; }
        public string A3 { get; set; }
        public string A4 { get; set; }
        public string A5 { get; set; }
        public string A6 { get; set; }
        public string A7 { get; set; }
        public string A8 { get; set; }
        public string A9 { get; set; }
        public string A10 { get; set; }
        public string A11 { get; set; }
        public string A12 { get; set; }
        public string A13 { get; set; }
        public string A14 { get; set; }
        public string B1 { get; set; }
        public string B2 { get; set; }
        public string B3 { get; set; }
        public string B4 { get; set; }
        public string B5 { get; set; }
        public string B6 { get; set; }
        public string B7 { get; set; }
        public string B8 { get; set; }
        public string B9 { get; set; }
        public string B10 { get; set; }
        public string B11 { get; set; }
        public string B12 { get; set; }
        public string B13 { get; set; }
        public string B14 { get; set; }
        public string C1 { get; set; }
        public string C2 { get; set; }
        public string C3 { get; set; }
        public string C4 { get; set; }
        public string C5 { get; set; }
        public string C6 { get; set; }
        public string C7 { get; set; }
        public string C8 { get; set; }
        public string C9 { get; set; }
        public string C10 { get; set; }
        public string C11 { get; set; }
        public string C12 { get; set; }
        public string C13 { get; set; }
        public string C14 { get; set; }
        public string D1 { get; set; }
        public string D2 { get; set; }
        public string D3 { get; set; }
        public string D4 { get; set; }
        public string D5 { get; set; }
        public string D6 { get; set; }
        public string D7 { get; set; }
        public string D8 { get; set; }
        public string D9 { get; set; }
        public string D10 { get; set; }
        public string D11 { get; set; }
        public string D12 { get; set; }
        public string D13 { get; set; }
        public string D14 { get; set; }
        public string E1 { get; set; }
        public string E2 { get; set; }
        public string E3 { get; set; }
        public string E4 { get; set; }
        public string E5 { get; set; }
        public string E6 { get; set; }
        public string E7 { get; set; }
        public string E8 { get; set; }
        public string E9 { get; set; }
        public string E10 { get; set; }
        public string E11 { get; set; }
        public string E12 { get; set; }
        public string E13 { get; set; }
        public string E14 { get; set; }
        public string F1 { get; set; }
        public string F2 { get; set; }
        public string F3 { get; set; }
        public string F4 { get; set; }
        public string F5 { get; set; }
        public string F6 { get; set; }
        public string F7 { get; set; }
        public string F8 { get; set; }
        public string F9 { get; set; }
        public string F10 { get; set; }
        public string F11 { get; set; }
        public string F12 { get; set; }
        public string F13 { get; set; }
        public string F14 { get; set; }
    }
}
