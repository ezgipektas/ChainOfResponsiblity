using ChainOfResponsiblity.DAL;

namespace ChainOfResponsiblity.ChainOfResbonsiblity
{
    public class AreaManager:Employee
    {
        Context context = new Context();
        public override void ProcessRequest(Withdraw req)
        {
            if (req.Amount <= 200000)
            {
                ProcessDetail p = new ProcessDetail();
                p.EmployeeName = "Leyla Çınar";
                p.EmployeeTitle = "Bölge Müdür";
                p.Description = "Müşterinin talep ettiği tutar ödendi";
                p.Amount = req.Amount;
                context.ProcessDetails.Add(p);
                context.SaveChanges();

            }
            else 
            {
                ProcessDetail p = new ProcessDetail();
                p.EmployeeName = "Leyla Çınar";
                p.EmployeeTitle = "Bölge Müdür";
                p.Description = "Müşterinin talep ettiği tutar banka limitlerinin üzerinde olduğu için müşteriye ödeme yapılamadı.";
                p.Amount = req.Amount;
                context.ProcessDetails.Add(p);
                context.SaveChanges();


            }
        }
    }
}
