using Cir.Sync.Services.DataContracts;
using Cir.Sync.Services.Edmx;
using Cir.Sync.Services.ErrorHandling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cir.Sync.Services.DAL
{

    public class DAManufacturer
    {
        public static Manufacturer GetManufacturer(int type,int id)
        {
            Manufacturer m = new Manufacturer();
            using (CIM_CIREntities context = new CIM_CIREntities())
            {
                if (type == 1)
                {
                    m = context.BladeManufacturer.Where(x => x.BladeManufacturerId == id).OrderBy(x => x.Name).Select(x => new Manufacturer
                    {
                        Id = x.BladeManufacturerId,
                        Name = x.Name,
                        Contact = x.EmailContactName,
                        Cc = x.Cc,
                        To = x.Email,
                        ManufacturerType = 1

                    }).FirstOrDefault();

                }
                if (type == 2)
                {
                    m = context.GeneratorManufacturer.Where(x => x.GeneratorManufacturerId == id).OrderBy(x => x.Name).Select(x => new Manufacturer
                    {
                        Id = x.GeneratorManufacturerId,
                        Name = x.Name,
                        Contact = x.EmailContactName,
                        Cc = x.Cc,
                        To = x.Email,
                        ManufacturerType = 2

                    }).FirstOrDefault();
                }
                if (type == 3)
                {
                    m = context.GearboxManufacturer.Where(x => x.GearboxManufacturerId == id).OrderBy(x => x.Name).Select(x => new Manufacturer
                    {
                        Id = x.GearboxManufacturerId,
                        Name = x.Name,
                        Contact = x.EmailContactName,
                        Cc = x.Cc,
                        To = x.Email,
                        ManufacturerType = 3

                    }).FirstOrDefault();
                }
                if (type == 4)
                {
                    m = context.TransformerManufacturer.Where(x => x.TransformerManufacturerId == id).OrderBy(x => x.Name).Select(x => new Manufacturer
                    {
                        Id = x.TransformerManufacturerId,
                        Name = x.Name,
                        Contact = x.EmailContactName,
                        Cc = x.Cc,
                        To = x.Email,
                        ManufacturerType = 4
                    }).FirstOrDefault();
                }
                if (type == 5)
                {
                    m = context.OtherManufacturer.Where(x => x.OtherManufacturerId == id).OrderBy(x => x.Name).Select(x => new Manufacturer
                    {
                        Id = x.OtherManufacturerId,
                        Name = x.Name,
                        Contact = x.EmailContactName,
                        Cc = x.Cc,
                        To = x.Email,
                        ManufacturerType = 5

                    }).FirstOrDefault();
                }
            }
            return m;

        }

        public static ManufacturerList GetManufacturerList(int type)
        {
            ManufacturerList mlist = new ManufacturerList();
            using (CIM_CIREntities context = new CIM_CIREntities())
            {
                if (type == 1)
                {
                    mlist = new ManufacturerList() { 
                        ManufacturerType = 1,
                        Manufacturers = context.BladeManufacturer.OrderBy(x => x.Name).Select(x => new Manufacturer
                        {
                            Id = x.BladeManufacturerId,
                            Name = x.Name,
                            Contact = x.EmailContactName,
                            Cc = x.Cc,
                            To = x.Email,
                            ManufacturerType = 1

                        }).ToList()
                     };

                }
                if (type == 2)
                {
                      mlist = new ManufacturerList() { 
                        ManufacturerType = 2,
                        Manufacturers = context.GeneratorManufacturer.OrderBy(x => x.Name).Select(x => new Manufacturer
                        {
                            Id = x.GeneratorManufacturerId,
                            Name = x.Name,
                            Contact = x.EmailContactName,
                            Cc = x.Cc,
                            To = x.Email,
                            ManufacturerType = 2

                        }).ToList()
                      };
                }
                if (type == 3)
                {
                      mlist = new ManufacturerList() { 
                        ManufacturerType = 3,
                        Manufacturers = context.GearboxManufacturer.OrderBy(x => x.Name).Select(x => new Manufacturer
                        {
                            Id = x.GearboxManufacturerId,
                            Name = x.Name,
                            Contact = x.EmailContactName,
                            Cc = x.Cc,
                            To = x.Email,
                            ManufacturerType = 3

                        }).ToList()
                      };
                }
                if (type == 4)
                {
                      mlist = new ManufacturerList() { 
                        ManufacturerType = 4,
                        Manufacturers = context.TransformerManufacturer.OrderBy(x => x.Name).Select(x => new Manufacturer
                        {
                            Id = x.TransformerManufacturerId,
                            Name = x.Name,
                            Contact = x.EmailContactName,
                            Cc = x.Cc,
                            To = x.Email,
                            ManufacturerType = 4

                        }).ToList()
                      };
                }
                if (type == 5)
                {
                    mlist = new ManufacturerList()
                    {
                        ManufacturerType = 5,
                        Manufacturers = context.OtherManufacturer.OrderBy(x => x.Name).Select(x => new Manufacturer
                        {
                            Id = x.OtherManufacturerId,
                            Name = x.Name,
                            Contact = x.EmailContactName,
                            Cc = x.Cc,
                            To = x.Email,
                            ManufacturerType = 5

                        }).ToList()
                    };
                }
            }
            return mlist;

        }

        public static bool DeleteManufacturer(int type, int id)
        {
            try
            {
                using (CIM_CIREntities context = new CIM_CIREntities())
                {
                    if (type == 1)
                    {
                        var m = context.BladeManufacturer.Where(x => x.BladeManufacturerId == id).FirstOrDefault();
                        if (m != null)
                        {
                            context.BladeManufacturer.Remove(m);
                            context.SaveChanges();
                            ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "Blade Manufacturer with Name  " + m.Name + " deleted!", LogType.Information, "");
                        }

                    }
                    if (type == 2)
                    {
                        var m = context.GeneratorManufacturer.Where(x => x.GeneratorManufacturerId == id).FirstOrDefault();
                        if (m != null)
                        {
                            context.GeneratorManufacturer.Remove(m);
                            context.SaveChanges();
                            ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "Generator Manufacturer with Name  " + m.Name + " deleted!", LogType.Information, "");
                        }

                    }
                    if (type == 3)
                    {
                        var m = context.GearboxManufacturer.Where(x => x.GearboxManufacturerId == id).FirstOrDefault();
                        if (m != null)
                        {
                            context.GearboxManufacturer.Remove(m);
                            context.SaveChanges();
                            ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "Gearbox Manufacturer with Name  " + m.Name + " deleted!", LogType.Information, "");
                        }

                    }
                    if (type == 4)
                    {
                        var m = context.TransformerManufacturer.Where(x => x.TransformerManufacturerId == id).FirstOrDefault();
                        if (m != null)
                        {
                            context.TransformerManufacturer.Remove(m);
                            context.SaveChanges();
                            ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "Transformer Manufacturer with Name  " + m.Name + " deleted!", LogType.Information, "");
                        }

                    }
                    if (type == 5)
                    {
                        var m = context.OtherManufacturer.Where(x => x.OtherManufacturerId == id).FirstOrDefault();
                        if (m != null)
                        {
                            context.OtherManufacturer.Remove(m);
                            context.SaveChanges();
                            ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "Other Manufacturer with Name  " + m.Name + " deleted!", LogType.Information, "");
                        }

                    }
                  
                }
            }
            catch(Exception e)
            {
                ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "Error Deleting Manufacturer!" , LogType.Error, e.Message.ToString());
            }
            return true;
        }

        public static bool SaveManufacturer(Manufacturer m)
        {
            try
            {
                if (m.ManufacturerType == 1)
                {
                    SaveBladeManufacturer(m);
                }
                if (m.ManufacturerType == 2)
                {
                    SaveGeneratorManufacturer(m);
                }
                if (m.ManufacturerType == 3)
                {
                    SaveGearboxManufacturer(m);
                }
                if (m.ManufacturerType == 4)
                {
                    SaveTransformerManufacturer(m);
                }
                if (m.ManufacturerType == 5)
                {
                    SaveOtherManufacturer(m);
                }
                        DataContracts.ServiceInformations ServiceInformationsData = new ServiceInformations();                 
                        ServiceInformationsData.Id = 0;
                        ServiceInformationsData.Message = "Manufacturer Master Data has been Updated.Please Refresh Master Data by clicking [Menu > UserName > Sync Master Data]";
                        ServiceInformationsData.SeverityId = 2; //Must Read
                        ServiceInformationsData.CreatedBy = "SYSTEM";
                        ServiceInformationsData.Created = DateTime.Now;
                        ServiceInformationsData.Deleted = false;
                        ServiceInformationsData.StrFromDate = DateTime.Now.ToString();
                        ServiceInformationsData.StrToDate =  DateTime.Now.AddMonths(1).ToString();

                        DAServiceInformations.SaveServiceInformations(ServiceInformationsData);
            }
            catch(Exception e)
            {
                ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "Error Saving Manufacturer with Name  " + m.Name + " !", LogType.Error, e.Message.ToString());
                return false;
            }
            return true;
        }

        public static void SaveBladeManufacturer(Manufacturer manufacturer)
        {
            using (CIM_CIREntities context = new CIM_CIREntities())
            {

                var m = context.BladeManufacturer.Where(x => x.BladeManufacturerId == manufacturer.Id).FirstOrDefault();
                if (m == null)
                {
                    BladeManufacturer bm = new BladeManufacturer();
                    bm.EmailContactName = manufacturer.Contact;
                    bm.Name = manufacturer.Name;
                    bm.Email = manufacturer.To;
                    bm.Cc = manufacturer.Cc;
                    bm.LanguageId = 1;
                    bm.Sort = 1;
                    context.BladeManufacturer.Add(bm);
                    ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "Blade Manufacturer with Name  " + manufacturer.Name + " created!", LogType.Information, "");
                }
                else
                {
                    m.EmailContactName = manufacturer.Contact;
                    m.Name = manufacturer.Name;
                    m.Email = manufacturer.To;
                    m.Cc = manufacturer.Cc;
                    m.LanguageId = 1;
                    m.Sort = 1;
                    ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "Blade Manufacturer with Name  " + manufacturer.Name + " updated!", LogType.Information, "");
                }
                context.SaveChanges();
            }
        }

        public static void SaveGeneratorManufacturer(Manufacturer manufacturer)
        {
            using (CIM_CIREntities context = new CIM_CIREntities())
            {

                var m = context.GeneratorManufacturer.Where(x => x.GeneratorManufacturerId == manufacturer.Id).FirstOrDefault();
                if (m == null)
                {
                    GeneratorManufacturer bm = new GeneratorManufacturer();
                    bm.EmailContactName = manufacturer.Contact;
                    bm.Name = manufacturer.Name;
                    bm.Email = manufacturer.To;
                    bm.Cc = manufacturer.Cc;
                    bm.LanguageId = 1;
                    bm.Sort = 1;
                    ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "Generator Manufacturer with Name  " + manufacturer.Name + " created!", LogType.Information, "");
                    context.GeneratorManufacturer.Add(bm);
                }
                else
                {
                    m.EmailContactName = manufacturer.Contact;
                    m.Name = manufacturer.Name;
                    m.Email = manufacturer.To;
                    m.Cc = manufacturer.Cc;
                    m.LanguageId = 1;
                    m.Sort = 1;
                    ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "Generator Manufacturer with Name  " + manufacturer.Name + " updated!", LogType.Information, "");
                }
                context.SaveChanges();
            }
        }

        public static void SaveGearboxManufacturer(Manufacturer manufacturer)
        {
            using (CIM_CIREntities context = new CIM_CIREntities())
            {

                var m = context.GearboxManufacturer.Where(x => x.GearboxManufacturerId == manufacturer.Id).FirstOrDefault();
                if (m == null)
                {
                    GearboxManufacturer bm = new GearboxManufacturer();
                    bm.EmailContactName = manufacturer.Contact;
                    bm.Name = manufacturer.Name;
                    bm.Email = manufacturer.To;
                    bm.Cc = manufacturer.Cc;
                    bm.LanguageId = 1;
                    bm.Sort = 1;
                    context.GearboxManufacturer.Add(bm);
                    ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "Gear boxManufacturer with Name  " + manufacturer.Name + " created!", LogType.Information, "");
                }
                else
                {
                    m.EmailContactName = manufacturer.Contact;
                    m.Name = manufacturer.Name;
                    m.Email = manufacturer.To;
                    m.Cc = manufacturer.Cc;
                    m.LanguageId = 1;
                    m.Sort = 1;
                    ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "Gea rboxManufacturer with Name  " + manufacturer.Name + " updated!", LogType.Information, "");
                }
                context.SaveChanges();
            }
        }

        public static void SaveTransformerManufacturer(Manufacturer manufacturer)
        {
            using (CIM_CIREntities context = new CIM_CIREntities())
            {

                var m = context.TransformerManufacturer.Where(x => x.TransformerManufacturerId == manufacturer.Id).FirstOrDefault();
                if (m == null)
                {
                    TransformerManufacturer bm = new TransformerManufacturer();
                    bm.EmailContactName = manufacturer.Contact;
                    bm.Name = manufacturer.Name;
                    bm.Email = manufacturer.To;
                    bm.Cc = manufacturer.Cc;
                    bm.LanguageId = 1;
                    bm.Sort = 1;
                    context.TransformerManufacturer.Add(bm);
                    ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "Transforme rManufacturer with Name  " + manufacturer.Name + " created!", LogType.Information, "");
                }
                else
                {
                    m.EmailContactName = manufacturer.Contact;
                    m.Name = manufacturer.Name;
                    m.Email = manufacturer.To;
                    m.Cc = manufacturer.Cc;
                    m.LanguageId = 1;
                    m.Sort = 1;
                    ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "Transformer Manufacturer with Name  " + manufacturer.Name + " updated!", LogType.Information, "");
                }
                context.SaveChanges();
            }
        }

        public static void SaveOtherManufacturer(Manufacturer manufacturer)
        {
            using (CIM_CIREntities context = new CIM_CIREntities())
            {

                var m = context.OtherManufacturer.Where(x => x.OtherManufacturerId == manufacturer.Id).FirstOrDefault();
                if (m == null)
                {
                    OtherManufacturer bm = new OtherManufacturer();
                    bm.EmailContactName = manufacturer.Contact;
                    bm.Name = manufacturer.Name;
                    bm.Email = manufacturer.To;
                    bm.Cc = manufacturer.Cc;
                    bm.LanguageId = 1;
                    bm.Sort = 1;
                    context.OtherManufacturer.Add(bm);
                    ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "Other Manufacturer with Name  " + manufacturer.Name + " created!", LogType.Information, "");
                }
                else
                {
                    m.EmailContactName = manufacturer.Contact;
                    m.Name = manufacturer.Name;
                    m.Email = manufacturer.To;
                    m.Cc = manufacturer.Cc;
                    m.LanguageId = 1;
                    m.Sort = 1;
                    ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "Other Manufacturer with Name  " + manufacturer.Name + " updated!", LogType.Information, "");
                }
                context.SaveChanges();
            }
        }
    }
}