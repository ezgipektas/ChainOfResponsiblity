using ChainOfResponsiblity.DAL;

namespace ChainOfResponsiblity.ChainOfResbonsiblity
{
    public class Manager : Employee

    {
        Context context = new Context();
        public override void ProcessRequest(Withdraw req)
        {
            if (req.Amount <= 150000)
            {
                ProcessDetail p = new ProcessDetail();
                p.EmployeeName = "Pınar Öztürk";
                p.EmployeeTitle = "Şube Müdür";
                p.Description = "Müşterinin talep ettiği tutar ödendi";
                p.Amount = req.Amount;
                context.ProcessDetails.Add(p);
                context.SaveChanges();

            }
            else if (NextApprover != null)
            {
                ProcessDetail p = new ProcessDetail();
                p.EmployeeName = "Pınar Öztürk";
                p.EmployeeTitle = "Şube Müdür";
                p.Description = "Müşterinin talep ettiği tutar bulunduğum yetki değerini aştığı için müşteriyi Bölge Müdürümüze yönlendirmiş bulunmaktayım.";
                p.Amount = req.Amount;
                context.ProcessDetails.Add(p);
                context.SaveChanges();

                NextApprover.ProcessRequest(req);
            }
        }
    }
}
