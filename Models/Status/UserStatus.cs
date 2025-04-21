namespace FeedBridge_00.Models.Status
{
    public enum UserStatus
    {
        Active,      // الحساب نشط
        Inactive,    // غير نشط ولكنه لم يُحذف
        Suspended,   // موقوف بشكل مؤقت
        Banned,      // محظور نهائيًا
        Deleted      // تم حذف الحساب
    }
}
