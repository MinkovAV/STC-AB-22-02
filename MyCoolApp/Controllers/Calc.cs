using Microsoft.AspNetCore.Mvc;
using MyAPI.Model;
using MyCoolApp.Metods;

namespace MyCoolApp.Controllers
{
    [ApiController]
    public class Calc
    {

        private readonly DB_Context _dbContext;

        public Calc(DB_Context dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("CalKulate")]
        public calcResult Get(double a, double b, string action)
        {
            History table = new History();
            table.A = a;
            table.B = b;
            table.date = DateTime.Now.ToString("yy/MM/dd");
            
            double ActionResult;

            switch (action)
            {
                case "add":
                    ActionResult = a + b;
                    table.action = "+";
                    break;
                case "minus":
                    ActionResult = a - b;
                    table.action = "-";
                    break;
                case "mult":
                    ActionResult = a * b;
                    table.action = "*";
                    break;
                case "div":
                    ActionResult = a / b;
                    table.action = "/";
                    break;
                default:
                    ActionResult = a + b;
                    table.action = "+";
                    break;
            }

            table.result = ActionResult;

            _dbContext.history.Add(table);
            _dbContext.sys_logs.Add(new sys_logs
            {
                Date = DateTime.Now.ToUniversalTime(),
                logs = "sfsfgsfsfdsf"
            });

            _dbContext.SaveChanges();

            return new calcResult
            {
                ActionResultSend = ActionResult

            };

        }
    }
}
