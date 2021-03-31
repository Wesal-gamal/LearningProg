using System;
using System.Collections.Generic;
using System.Text;

namespace Attendleave.Erp.Core.APIUtilities
{
    public static class ResponseActionMessages
    {
      static Language lang = Language.English;
        public static string GetMesage(ResponseMessages msg, Language la)
        {
            lang =  la;
           if ( msg == ResponseMessages.Created) return Created;
            else if (msg == ResponseMessages.Updated) return Updated;
            else if (msg == ResponseMessages.NotFound) return NotFound;
            else if (msg == ResponseMessages.Deleted) return Deleted;
            else if (msg == ResponseMessages.Blocked)  return Blocked;
            else if (msg == ResponseMessages.UnBlocked) return UnBlocked;
            else if (msg == ResponseMessages.Return) return Return;
            else if (msg == ResponseMessages.Error) return Error;
            else if (msg == ResponseMessages.BadRequest) return BadRequest;
            else if (msg == ResponseMessages.BadBlockRole) return BadBlockRole;
            else if (msg == ResponseMessages.WrongUser) return WrongUser;
            else if (msg == ResponseMessages.BlockedUser) return BlockedUser;
            else if (msg == ResponseMessages.NotAllowUserAccess) return NotAllowUserAccess;
            else if (msg == ResponseMessages.EmployeeExisted) return EmployeeExisted;
            else if (msg == ResponseMessages.CustomerNameExisted) return CustomerNameExisted;
            else if (msg == ResponseMessages.ImportScussfully) return ImportScussfully;
            else if (msg == ResponseMessages.UpdateFileScussfully) return UpdateFileScussfully;
            else if (msg == ResponseMessages.UpdateFileWithErrors) return UpdateFileWithErrors;
            else if (msg == ResponseMessages.EmptyFile) return EmptyFile;
            else if (msg == ResponseMessages.ModelTypeExist) return ModelTypeExistErrors;

            return " no message matched";
            
        }
        public static string Created { get { return lang == Language.English ? "Save data successfully" : "تم حفظ البيانات بنجاح"; } }
        public static string Updated { get { return lang == Language.English ? "Update data successfully" : "تم تعديل البيانات بنجاح"; } }
        public static string NotFound { get { return lang == Language.English ? "Not found" : "غير موجود"; } }
        public static string Deleted { get { return lang == Language.English ? "Remove data successfully" : "تم حذف البيانات بنجاح"; } }
        public static string Blocked { get { return lang == Language.English ? "Blocked successfully" : "تم وقف الحساب بنجاح"; } }
        public static string UnBlocked { get { return lang == Language.English ? "UnBlocked successfully" : "تم إعادة تشغيل الحساب بنجاح"; } }
        public static string Return { get { return lang == Language.English ? "Return data successfully" : "تم استرجاع البيانات بنجاح"; } }
        public static string Error { get { return lang == Language.English ? "Something went error" : "حدث خطأ"; } }
        public static string ShouldEnterTime { get { return lang == Language.English ? "You Should Enter Time For the End of Next Day " : "يجب ادخال وقت نهاية الدوام"; } }
        public static string BadRequest { get { return lang == Language.English ? "Bad request" : "عملية خاطئة"; } }
        public static string BadBlockRole { get { return lang == Language.English ? "Can not block this role as has children" : "لا يمكن حذف هذه الصلاحية لان هناك صلاحيات اخرى معتمدة عليها"; } }
        public static string WrongUser { get { return lang == Language.English ? "Wrong username or password" : "اسم المستخدم او كلمة المرور خاطئة"; } }
        public static string BlockedUser { get { return lang == Language.English ? "This user is blocked" : "هذا الحساب موقوف"; } }
        public static string NotAllowUserAccess{ get { return lang == Language.English ? "This user has not allow access" : "هذا الحساب ممنوع من الدخول"; } }
        public static string EmployeeExisted{ get { return lang == Language.English ? "This employee registed before" : "هذا الموظف لديه حساب بالفعل "; } }
        public static string CustomerNameExisted { get { return lang == Language.English ? "This customer name existed" : "اسم هذا العميل موجود بالفعل "; } }
        public static string ImportScussfully { get { return lang == Language.English ? "Import data successfully" : "تم استيراد البيانات  بنجاح "; } }
        public static string ImportWithErrors { get { return lang == Language.English ? "Can't Import data as there exist some errors" : "لا يمكن استيراد البينانات لوجود اخطاء"; } }

        public static string UpdateFileScussfully { get { return lang == Language.English ? "Export data successfully" : "تم تحديث البيانات  بنجاح "; } }
        public static string UpdateFileWithErrors { get { return lang == Language.English ? "Can't Export data as there exist some errors" : "لا يمكن تحديث البينانات لوجود اخطاء"; } }
        public static string EmptyFile { get { return lang == Language.English ? "file empty" : "الملف فارغ"; } }
    
        public static string ModelTypeExistErrors { get { return lang == Language.English ? "model type price list exist before" : "تم ادخال قاتمة اسعار لهذا الصنف"; } }
    }
}
