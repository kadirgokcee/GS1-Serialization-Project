using GS1.Core.DTOs;
using GS1.Core.Entities;
using GS1.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GS1.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkOrderController : ControllerBase
    {
        private readonly GS1DbContext _context;

        public WorkOrderController(GS1DbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> CreateWorkOrder(WorkOrderDto dto)
        {
            // Ürünü Ara
            var product = await _context.Products.FindAsync(dto.ProductId);
            if (product == null) return NotFound("Ürün bulunamadı!");

            //İş Emri
            var workOrder = new WorkOrder
            {
                ProductId = dto.ProductId,
                Quantity = dto.Quantity,
                LotNo = dto.LotNo,
                ExpireDate = dto.ExpireDate,
                Status = OrderStatus.Processing,
                OrderCode = "WO-" + DateTime.Now.ToString("mmss")
            };

            // ÜRETİM ALGORİTMASI 
            workOrder.SerialNumbers = new List<SerialNumber>();

            int itemsPerCase = 10; // KURAL: Her 10 ilaç 1 Koli
            SerialNumber currentCase = null;

            for (int i = 0; i < dto.Quantity; i++)
            {
                // YENİ Case 
                if (i % itemsPerCase == 0)
                {
                    
                    string ssccCode = GenerateMockSSCC(); // 18 haneli koli barkodu

                    currentCase = new SerialNumber
                    {
                        SerialNo = "CASE-" + GenerateRandomSerial(5), // KoliSeriNo
                        SSCC = ssccCode,
                        FullGtinCode = $"(00){ssccCode}", // Koli barkodu (00) ile başlar
                        Type = SerialType.Case, // TİP: Koli
                        WorkOrder = workOrder   
                    };

                    // Koliyi listeye ekle
                    workOrder.SerialNumbers.Add(currentCase);
                }

                //İLAÇ ÜRETİMİ
                string serialNo = GenerateRandomSerial(10);
                string sktFormat = dto.ExpireDate.ToString("yyMMdd");

                // İlaç Barkodu: (01)GTIN(17)SKT(10)LOT(21)SN
                string fullGtinString = $"(01){product.GTIN}(17){sktFormat}(10){dto.LotNo}(21){serialNo}";

                var item = new SerialNumber
                {
                    SerialNo = serialNo,
                    FullGtinCode = fullGtinString,
                    Type = SerialType.Item, 
                    WorkOrder = workOrder,

                    // AGREGASYON
                    // bağlama
                    ParentContainer = currentCase
                };

                workOrder.SerialNumbers.Add(item);
            }

            // Transaction
            _context.WorkOrders.Add(workOrder);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                Message = $"{dto.Quantity} ürün ve {Math.Ceiling((double)dto.Quantity / itemsPerCase)} koli başarıyla üretildi ve eşleştirildi.",
                OrderCode = workOrder.OrderCode
            });
        }

      

        // random seriNo
        private string GenerateRandomSerial(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        //  SSCC (Koli Barkodu) 
        
        private string GenerateMockSSCC()
        {
            var random = new Random();
            string randomDigits = "";
            for (int i = 0; i < 17; i++) randomDigits += random.Next(0, 9).ToString();

            return "1" + randomDigits; // 18 hane
        }

        // Detay 
        [HttpGet("{id}")]
        public async Task<ActionResult<WorkOrderDetailDto>> GetWorkOrderDetails(int id)
        {
            var workOrder = await _context.WorkOrders
                .Include(w => w.Product)
                .Include(w => w.SerialNumbers)
                .FirstOrDefaultAsync(w => w.Id == id);

            if (workOrder == null) return NotFound("İş emri bulunamadı.");

            var result = new WorkOrderDetailDto
            {
                OrderCode = workOrder.OrderCode,
                ProductName = workOrder.Product.Name,
                PlannedQuantity = workOrder.Quantity,
                Status = workOrder.Status.ToString(),
                
                ProducedSerials = workOrder.SerialNumbers
                                    .Where(s => s.Type == SerialType.Item)
                                    .Select(s => s.FullGtinCode)
                                    .ToList()
            };

            return Ok(result);
        }
    }
}