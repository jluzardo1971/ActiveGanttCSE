
namespace AGCSE
{

    public class DeflaterPending : PendingBuffer
    {
        public DeflaterPending()
            : base(DeflaterConstants.PENDING_BUF_SIZE)
        {
        }
    }
}
