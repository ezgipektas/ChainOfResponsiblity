using ChainOfResponsiblity.DAL;
using System;

namespace ChainOfResponsiblity.ChainOfResbonsiblity
{
    public class Treasurer : Employee
    {
        Context context = new Context();
        public override void ProcessRequest(Withdraw req)
        {
            if (req.Amount <= 40000)
            {
                ProcessDetail p=new ProcessDetail();
                p.EmployeeName = "Ezgi Pektaş";
                p.EmployeeTitle = "Veznedar";
                p.Description = "Müşterinin talep ettiği tutar ödendi";
                p.Amount=req.Amount;
                context.ProcessDetails.Add(p);
                context.SaveChanges();
                
            }
            else if (NextApprover != null)
            {
                ProcessDetail p = new ProcessDetail();
                p.EmployeeName = "Ezgi Pektaş";
                p.EmployeeTitle = "Veznedar";
                p.Description = "Müşterinin talep ettiği tutar bulunduğum yetki değerini aştığı için müşteriyi Şube Müdür Yardımcımıza yönlendirmiş bulunmaktayım.";
                p.Amount = req.Amount;
                context.ProcessDetails.Add(p);
                context.SaveChanges();

                NextApprover.ProcessRequest(req);
            }
        }

    }
}
