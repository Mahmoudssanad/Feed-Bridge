namespace FeedBridge_00.Models.Status
{
    public enum ReviewStatus
    {
        Pending,      // التقييم ينتظر الموافقة
        Approved,     // التقييم تم قبوله ونشره
        Rejected,     // التقييم تم رفضه
        Flagged,      // التقييم مُعلّم كمسيء أو غير لائق
        Edited        // تم تعديل التقييم بعد نشره
    }
}
