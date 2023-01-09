using ChainOfResponsiblity.DAL;

namespace ChainOfResponsiblity.ChainOfResbonsiblity
{
    public class ManagerAsistant:Employee
    {
            Context context = new Context();
            public override void ProcessRequest(Withdraw req)
            {
                if (req.Amount <= 70000)
                {
                    ProcessDetail p = new ProcessDetail();
                    p.EmployeeName = "Esin Kayalı";
                    p.EmployeeTitle = "Şube Müdür Yardımcısı";
                    p.Description = "Müşterinin talep ettiği tutar ödendi";
                    p.Amount = req.Amount;
                    context.ProcessDetails.Add(p);
                    context.SaveChanges();

                }
                else if (NextApprover != null)
                {
                    ProcessDetail p = new ProcessDetail();
                    p.EmployeeName = "Esin Kayalı";
                    p.EmployeeTitle = "Şube Müdür Yardımcısı";
                    p.Description = "Müşterinin talep ettiği tutar bulunduğum yetki değerini aştığı için müşteriyi Şube Müdürümüze yönlendirmiş bulunmaktayım.";
                    p.Amount = req.Amount;
                    context.ProcessDetails.Add(p);
                    context.SaveChanges();

                    NextApprover.ProcessRequest(req);
                }
            }
        }
}
