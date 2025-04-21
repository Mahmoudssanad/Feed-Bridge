namespace FeedBridge_00.Models.Status
{
    public enum SupportStatus
    {
        Pending,   // قيد الانتظار
        Success,   // ناجح
        Failed,    // فشل الدفع
        Canceled,  // تم إلغاؤه
    }
}
